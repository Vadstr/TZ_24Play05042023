using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> cubes = new List<GameObject>();

    [SerializeField]
    private GameObject cubePickup;
    [SerializeField]
    private GameObject cubeHolder;
    [SerializeField]
    private GameObject stickman;
    [SerializeField]
    private GameObject stickmanPref;
    [SerializeField]
    private GameObject spawnEffect;
    [SerializeField]
    private GameObject scoreEffect;

    public static GameObject highestCube;

    private void Start()
    {
        PlayController.NewGameEvent += NewGame;
        CubesBehaviour.AddCubeEvent += Add;
        CubesBehaviour.RemoveCubeEvent += Remove;
        highestCube = cubes[0];
    }

    private void NewGame()
    {
        if (cubes.Count > 1)
            foreach (var cube in cubes)
            {
                if (cube.transform == highestCube.transform)
                    continue;

                Destroy(cube.gameObject);
            }
        else if (cubes.Count == 0)
            Add(new GameObject());
        
        cubes.Clear();
        cubes.Add(highestCube);

        highestCube.transform.SetParent(cubeHolder.transform);
        highestCube.transform.localPosition = Vector3.zero;
    }

    private void Add(GameObject gameObject)
    {
       
        Destroy(gameObject);
        var newCube = Instantiate(cubePickup);
        cubes.Add(newCube);
        newCube.transform.parent = cubeHolder.transform;
        newCube.transform.localPosition = new Vector3(0, cubes.Count - 1f, 0);
        
        highestCube = newCube;
        stickman.transform.parent = highestCube.transform;
        stickman.transform.localPosition = new Vector3(0, 0.5f, 0);

        Instantiate(spawnEffect, highestCube.transform);
    }

    private void Remove(Transform transform, Transform transformParrent)
    {
        if (transform == stickman.transform)
        {
            PlayController.EndGame();
            return;
        }

        GameObject cubeToDelete;
        foreach (var cube in cubes)
            if (cube.transform == transform)
            {
                if (cube == highestCube)
                {
                    PlayController.EndGame();
                    break;
                }
                cube.transform.parent = transformParrent;
                cubeToDelete = cube;
                cube.GetComponent<BoxCollider>().isTrigger = false;
                cubes.Remove(cubeToDelete);
                break;
            }
    }
}
