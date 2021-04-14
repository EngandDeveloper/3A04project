using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{

    public Text timerText;

    public static float t;
    private float startTime;



    void Start()
    {
        startTime = Time.time;
   
    }

    void Update(){
        t = Time.time - startTime;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = "Time: " + minutes + ":" + seconds;
    }

    
}
