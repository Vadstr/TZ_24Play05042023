using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScorreEffectMove : MonoBehaviour
{
    [SerializeField]
    private float textSpeed;
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    private Color start;
    [SerializeField]
    private Color finish;
    [SerializeField]
    private float timeToFade = 3;

    private float time;

    private void Start()
    {
        time = timeToFade;
    }

    void Update()
    {
        time -= Time.deltaTime;
        transform.Translate(0, Time.deltaTime * textSpeed, 0);
        text.color = Color.Lerp(finish, start, time/timeToFade);
        if(time < 0)
            Destroy(gameObject);
    }
}
