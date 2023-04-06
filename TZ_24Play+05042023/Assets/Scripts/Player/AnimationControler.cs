using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private Collider[] allCollider;
    private List<Rigidbody> ragdollRigidBodies = new List<Rigidbody>();

    void Start()
    {
        CubesBehaviour.AddCubeEvent += PlayAnimationJump;
        PlayController.EndGameEvent += PlayerDeath;
        PlayController.NewGameEvent += PlayerAlive;
        Init();
    }

    private void Init()
    {
        allCollider = GetComponentsInChildren<Collider>(true);
        foreach (var collider in allCollider)
        {
            if (collider.transform != transform)
            {
                var rag_rb = collider.GetComponent<Rigidbody>();
                if (rag_rb)
                {
                    ragdollRigidBodies.Add(rag_rb);
                }
            }
        }
    }

    private void PlayerAlive()
    {
        EnableRagdoll(false);
    }

    private void PlayerDeath()
    {
        EnableRagdoll(true);
    }

    private void PlayAnimationJump(GameObject gameObject)
    {
        animator.SetBool("Jump", true);
    }

    public void EnableRagdoll(bool enableRagdoll)
    {
        animator.enabled = !enableRagdoll;
        foreach (Collider item in allCollider)
        {
            item.enabled = enableRagdoll;
        }

        foreach (var ragdollRigidBody in ragdollRigidBodies)
        {
            ragdollRigidBody.useGravity = enableRagdoll;
            ragdollRigidBody.isKinematic = !enableRagdoll;
        }

        GetComponent<Collider>().enabled = !enableRagdoll;
    }
}
