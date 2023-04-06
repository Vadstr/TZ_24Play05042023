using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesBehaviour : MonoBehaviour
{
    public bool isWall;

    public delegate void AddCube(GameObject gameObject);
    public delegate void RemoveCube(Transform transform, Transform transformParent);

    public static event AddCube AddCubeEvent;
    public static event RemoveCube RemoveCubeEvent;


    private void OnTriggerEnter(Collider other)
    {
        if (isWall)
            RemoveCubeEvent.Invoke(other.transform, transform);
        else
            AddCubeEvent.Invoke(gameObject);
    }
}
