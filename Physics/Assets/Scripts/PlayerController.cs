using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject donutPrefab;
    public Material material;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp = Instantiate(donutPrefab, new Vector3(Random.Range(-5.35f, 6.5f), Random.Range(6.2f, -3.9f), -6.5f), Random.rotation);
            temp.GetComponent<MeshRenderer>().material = material;
            temp.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Random.ColorHSV(1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f));
        }
    }

    private void Update()
    {
    }
}