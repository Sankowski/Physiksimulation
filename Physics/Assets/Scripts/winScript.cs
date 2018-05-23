using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class winScript : MonoBehaviour
{
    public AudioClip audioSound;

    public GameObject donutPrefab;

    public static int donutsCount;
    private float timer;

    private void Start()
    {
    }

    private void Update()
    {
        if (donutsCount == 5)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 1.5f)
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
            donutPrefab.GetComponent<Rigidbody>().mass = 15;
            donutsCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spike"))
        {
            donutPrefab.GetComponent<Rigidbody>().mass = 1;
            donutsCount--;
        }
    }
}