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
            temp.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Random.ColorHSV(0f, 1f, 1f, 1f, 0.8f, 1f, 1f, 1f));
        }
    }

    public Rigidbody projectile;
    public float projectileSpeed = 75;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody clone;
            clone = Instantiate(projectile, new Vector3(-3.068f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.up * projectileSpeed);
            StartCoroutine(destroyProjectile(clone));
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Rigidbody clone;
            clone = Instantiate(projectile, new Vector3(3.09f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.up * projectileSpeed);
            StartCoroutine(destroyProjectile(clone));
        }
    }

    private IEnumerator destroyProjectile(Rigidbody rb)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(rb.gameObject);
    }
}