using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    public GameObject bubblePrefab;

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Instantiate(bubblePrefab, new Vector3(Random.Range(-23.82f, 23.13f), Random.Range(11.48f, -12.54f), 0f), Quaternion.Euler(Random.Range(0, 360), 90, 0));
        }
    }
}