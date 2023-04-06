using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TextEffectController : MonoBehaviour
{
    [SerializeField]
    private GameObject scoreEffect;

    void Start()
    {
        CubesBehaviour.AddCubeEvent += ScoreEffect;
    }

    private void ScoreEffect(GameObject gameObject)
    {
        var score = Instantiate(scoreEffect);
        score.transform.position = CubeManager.highestCube.transform.position;
        score.transform.SetParent(transform, true);
    }
}
