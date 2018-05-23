using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text newTime;
    private float startCounter;

    private void Start()
    {
        startCounter = Time.time;
    }

    private void Update()
    {
        float t = Time.time - startCounter;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        newTime.text = minutes + ":" + seconds;

        newTime.text = startCounter.ToString();
    }
}