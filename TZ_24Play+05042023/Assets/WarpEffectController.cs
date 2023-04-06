using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpEffectController : MonoBehaviour
{
    [SerializeField]
    private GameObject warpEffect;

    private void Start()
    {
        warpEffect.SetActive(false);
        PlayController.NewGameEvent += WarpEnable;
        PlayController.EndGameEvent += WarpDisable;
    }

    private void WarpEnable() 
    {
        warpEffect.SetActive(true);
    }

    private void WarpDisable() 
    {
        warpEffect.SetActive(false);
    }
}
