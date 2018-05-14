using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleRotationScript : MonoBehaviour
{
    public float speed = 15;

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(5 * speed * Time.deltaTime, 0, 0);
    }
}