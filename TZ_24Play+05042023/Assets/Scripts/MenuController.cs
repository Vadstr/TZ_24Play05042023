using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject startMenu;
    [SerializeField]
    private GameObject restartMenu;

    [SerializeField]
    private Button restartButton;

    void Start()
    {
        startMenu.SetActive(true);
        restartMenu.SetActive(false);

        PlayController.NewGameEvent += NewGame;
        PlayController.EndGameEvent += EndGame;

        restartButton.onClick.AddListener(RestartGame);
    }

    private void NewGame() 
    {
        startMenu.SetActive(false);
        restartMenu.SetActive(false);
    }
    
    private void EndGame() 
    {
        restartMenu.SetActive(true);
    }

    private void RestartGame() 
    {
        PlayController.NewGame();
    }
}
