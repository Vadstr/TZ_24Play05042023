using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField]
    private bool isVibrationOn;
    [SerializeField]
    private bool isCameraShakingOn;

    [SerializeField]
    private float duration;
    [SerializeField]
    private float magnitude;

    void Start()
    {
        CubesBehaviour.RemoveCubeEvent += PlayEffect;
    }

    private void PlayEffect(Transform transform, Transform transformParent)
    {
        if (isVibrationOn) 
        {
            
        }

        if (isCameraShakingOn) 
        {
            StartCoroutine(Shake());
        }
    }

    public IEnumerator Shake()
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude + orignalPosition.x;
            float y = Random.Range(-1f, 1f) * magnitude + orignalPosition.y;

            transform.position = new Vector3(x, y, -20);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    }
}
