using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackFiller : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> walls = new List<GameObject>();
    [SerializeField]
    private GameObject stackedCube;

    public void FillTreack(Transform treackTransform) 
    {
        var wallIndex = Random.Range(0, 4);
        var wall = Instantiate(walls[wallIndex]);
        wall.transform.parent = treackTransform; 
        wall.transform.localScale = new Vector3(1 / treackTransform.lossyScale.x, 1 / treackTransform.lossyScale.y, 1 / treackTransform.lossyScale.z);
        wall.transform.localPosition = new Vector3(0, 0, 0.45f);

        for (int i = 0; i < 3; i++)
        {
            var cubepos = Random.Range(-5, 5);
            var cube = Instantiate(stackedCube);
            cube.transform.parent = treackTransform;
            cube.transform.localScale = new Vector3(1 / treackTransform.lossyScale.x, 1 / treackTransform.lossyScale.y, 1 / treackTransform.lossyScale.z);
            cube.transform.localPosition = new Vector3((cubepos/5.0f) * cube.transform.localScale.x, 0.1f, - 0.2f + 0.2f * i);
        }
    }
}
