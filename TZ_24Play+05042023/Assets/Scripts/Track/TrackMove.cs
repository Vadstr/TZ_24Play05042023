using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TrackMove : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void FixedUpdate()
    {
        if (!PlayController.IsPlayed)
            return;

        if (transform.position.z <= -25)
            Destroy(gameObject);

        transform.Translate(0, 0, -speed/10);
    }
}
