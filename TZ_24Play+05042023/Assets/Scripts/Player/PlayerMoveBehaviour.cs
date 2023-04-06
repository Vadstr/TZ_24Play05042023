using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveBehaviour : MonoBehaviour
{
    private GameObject Player;
    public bool isWaitToPlay;

    private void Start()
    {
        Player = this.gameObject;
        isWaitToPlay = false;

        PlayController.NewGameEvent += Restart;
        PlayController.EndGameEvent += WaitUntilRestart;
    }

    void FixedUpdate()
    {
        if (!isWaitToPlay && Input.touchCount > 0 && !PlayController.IsPlayed)
            PlayController.NewGame();

        float xPos = Player.transform.position.x;
        if (Input.touchCount > 0 && PlayController.IsPlayed)
        {
            

            var touch = Input.GetTouch(0);
            xPos = (touch.position.x - Screen.width / 2) * 10 / Screen.width;
            if (xPos <= -2)
                Player.transform.position = new Vector3(-2, Player.transform.position.y, Player.transform.position.z);
            else if (xPos >= 2)
                Player.transform.position = new Vector3(2, Player.transform.position.y, Player.transform.position.z);
            else
                Player.transform.position = new Vector3(xPos, Player.transform.position.y, Player.transform.position.z);
        }
    }

    private void WaitUntilRestart() 
    {
        isWaitToPlay = true;
    }
    
    private void Restart() 
    {
        isWaitToPlay = false;
        Player.transform.position = Vector3.zero;
    }
}
