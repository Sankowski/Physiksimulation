using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winScript : MonoBehaviour
{
    public AudioClip audioSound;

    public static int donutsCount;
    private float timer;

    private void Update()
    {
        if (donutsCount == 5)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 3)
        {
            donutsCount = 0;
            SceneManager.LoadScene("Winning Screen");
            AudioChangerScript.changeMusic(audioSound);
        }
        if (donutsCount != 5)
        {
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spike"))
        {
            donutsCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spike"))
        {
            donutsCount--;
        }
    }
}