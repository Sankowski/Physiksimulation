using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject donutPrefab;
    public Material material;
    public Rigidbody projectile;
    public GameObject level;

    public float slider = 0;
    private bool counter = true;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp = Instantiate(donutPrefab, new Vector3(Random.Range(-5.35f, 6.5f), Random.Range(6.2f, -3.9f), -6.5f), Random.rotation);
            temp.GetComponent<MeshRenderer>().material = material;
            temp.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Random.ColorHSV(0f, 1f, 1f, 1f, 0.8f, 1f, 1f, 1f));
        }
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            sliderFunction();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Rigidbody clone;
            clone = Instantiate(projectile, new Vector3(-3.068f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
            clone.AddForce(Vector3.up * slider, ForceMode.Impulse);
            StartCoroutine(destroyProjectile(clone));
            slider = 0;
        }

        if (Input.GetButton("Fire2"))
        {
            sliderFunction();
        }
        if (Input.GetButtonUp("Fire2"))
        {
            Rigidbody clone;
            clone = Instantiate(projectile, new Vector3(3.08f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
            clone.AddForce(Vector3.up * slider, ForceMode.Impulse);
            StartCoroutine(destroyProjectile(clone));
            slider = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(levelShaker(level, 0.1f));
        }
        if (Input.GetButtonUp("Jump"))
        {
            StartCoroutine(levelShaker(level, -0.1f));
        }
    }

    private IEnumerator levelShaker(GameObject level, float moveDistance)
    {
        for (int i = 0; i < 5; i++)
        {
            yield return null;
            level.transform.Translate(moveDistance, 0, 0);
        }
    }

    private IEnumerator destroyProjectile(Rigidbody rb)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(rb.gameObject);
    }

    private void sliderFunction()
    {
        if (slider <= 65 && counter)
        {
            slider += Time.deltaTime * 70;
        }
        else if (slider >= 65 && counter)
        {
            counter = false;
        }
        if (slider >= 65 && !counter)
        {
            slider -= Time.deltaTime * 70;
        }
        else if (slider <= 0 && !counter)
        {
            counter = true;
        }
    }
}