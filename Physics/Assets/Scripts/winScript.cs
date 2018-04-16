using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winScript : MonoBehaviour
{
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
            Debug.Log("Winner");
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