using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public delegate void EndGameDelegate();
    public delegate void NewGameDelegate();

    public static event EndGameDelegate EndGameEvent;
    public static event NewGameDelegate NewGameEvent;

    private static bool isPlayed;
    public static bool IsPlayed { get { return isPlayed; } }

    public static void EndGame() 
    {
        EndGameEvent.Invoke();
        isPlayed = false;
    }
    
    public static void NewGame() 
    {
        NewGameEvent.Invoke();
        isPlayed= true;
    }
}
