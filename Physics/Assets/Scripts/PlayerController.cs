using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject donutPrefab;

    public GameObject spike;
    public GameObject level;

    public GameObject sliderUiRight;
    public GameObject sliderUiLeft;
    public GameObject rightEye;
    public GameObject leftEye;
    public GameObject leftLid;
    public GameObject rightLid;

    public Material material;

    public Text newTimeText;
    public Text oldTimeText;

    public Rigidbody bubblePrefab;
    public Rigidbody projectile;

    public Slider leftSlider;
    public Slider rightSlider;

    public float forceSidewardsRightX = -0.5f;
    public float forceSidewardsLeftX = 0.5f;
    public float forceSidewardsY = 0.5f;

    private float sliderLeft = 0;
    private float sliderRight = 0;
    private float eyeTimer = 2;
    private float timeCounter;
    private float currentTime;
    private float bestTime;

    private bool sliderLeftBool = true;
    private bool sliderRightBool = true;
    private bool gameStart = false;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp = new GameObject();
            switch (i)
            {
                case 0:
                    temp = Instantiate(donutPrefab, new Vector3(Random.Range(-2.846334f, -0.35f), Random.Range(2.52f, 5.27f), -6.5f), Random.rotation);
                    break;

                case 1:
                    temp = Instantiate(donutPrefab, new Vector3(Random.Range(1.37f, 4.69f), Random.Range(6.55f, 1.87f), -6.5f), Random.rotation);
                    break;

                case 2:
                    temp = Instantiate(donutPrefab, new Vector3(Random.Range(3.26f, 6.83f), Random.Range(0.69f, -3.56f), -6.5f), Random.rotation);
                    break;

                case 3:
                    temp = Instantiate(donutPrefab, new Vector3(Random.Range(0.01f, -4.94f), Random.Range(-3.56f, 0.09f), -6.5f), Random.rotation);
                    break;

                case 4:
                    temp = Instantiate(donutPrefab, new Vector3(Random.Range(0.85f, -4.5f), Random.Range(-0.23f, -4.45f), -6.5f), Random.rotation);
                    break;
            }
            temp.GetComponent<MeshRenderer>().material = material;
            temp.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Random.ColorHSV(0f, 1f, 1f, 1f, 0.8f, 1f, 1f, 1f));
        }
        float timeOld = 0;

        if (PlayerPrefs.HasKey("timeOld"))
        {
            timeOld = PlayerPrefs.GetFloat("timeOld");
            oldTimeText.text = string.Format("Old: {0,6:0.0} sec.", timeOld);
        }
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("timeOld", Time.time - timeCounter);
        PlayerPrefs.Save();

        if (!gameStart)
        {
            gameStart = true;
            timeCounter = Time.time;
        }
        if (gameStart)
        {
            newTimeText.text = string.Format("Time: {0,6:0.0} sec.", Time.time - timeCounter);
        }

        eyelidMover();
        leftEye.transform.LookAt(spike.transform.position);
        rightEye.transform.LookAt(spike.transform.position);

        mouseMovementSpike();
        projectilePrefab();

        leftSlider.value = sliderLeft;
        rightSlider.value = sliderRight;
    }

    private IEnumerator destroyProjectile(Rigidbody rb)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(rb.gameObject);
    }

    private IEnumerator destroyBubble(Rigidbody rb)
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(rb.gameObject);
    }

    private void sliderFunctionLeft()
    {
        if (sliderLeft <= 65 && sliderLeftBool)
        {
            sliderLeft += Time.deltaTime * 200;
        }
        else if (sliderLeft >= 65 && sliderLeftBool)
        {
            sliderLeftBool = false;
        }
        if (sliderLeft >= 0 && !sliderLeftBool)
        {
            sliderLeft -= Time.deltaTime * 200;
        }
        else if (sliderLeft <= 0 && !sliderLeftBool)
        {
            sliderLeftBool = true;
        }
    }

    private void sliderFunctionRight()
    {
        if (sliderRight <= 65 && sliderRightBool)
        {
            sliderRight += Time.deltaTime * 200;
        }
        else if (sliderRight >= 65 && sliderRightBool)
        {
            sliderRightBool = false;
        }
        if (sliderRight >= 0 && !sliderRightBool)
        {
            sliderRight -= Time.deltaTime * 200;
        }
        else if (sliderRight <= 0 && !sliderRightBool)
        {
            sliderRightBool = true;
        }
    }

    public float mouseSpeed;

    public void mouseMovementSpike()
    {
        if (Input.GetAxis("Mouse X") < 0)
        {
            spike.transform.Translate(-1 * mouseSpeed * Time.deltaTime, 0, 0f);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            spike.transform.Translate(1 * mouseSpeed * Time.deltaTime, 0, 0f);
        }
        spike.transform.position = new Vector3(Mathf.Min(spike.transform.position.x, 5.5f), spike.transform.position.y, spike.transform.position.z);
        spike.transform.position = new Vector3(Mathf.Max(spike.transform.position.x, -5.5f), spike.transform.position.y, spike.transform.position.z);
        eyeLookForward();
    }

    private void projectilePrefab()
    {
        if (Input.GetButton("Fire1"))
        {
            sliderFunctionLeft();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            Rigidbody projectileClone;
            Rigidbody projectileCloneSideWartsOne;
            Rigidbody bubbleClone;
            Rigidbody bubbleCloneSidewards;

            for (int x = 0; x <= 7; x++)
            {
                projectileClone = Instantiate(projectile, new Vector3(x * 0.41f - 4.57f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
                projectileClone.AddForce(Vector3.up * sliderLeft, ForceMode.Impulse);
                StartCoroutine(destroyProjectile(projectileClone));
                for (int y = 0; y < 1; y++)
                {
                    bubbleClone = Instantiate(bubblePrefab, new Vector3(y * 1 - 3.04f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
                    StartCoroutine(destroyBubble(bubbleClone));
                    bubbleCloneSidewards = Instantiate(bubblePrefab, new Vector3(y * 1 - 5.98f, -6f, -6.281f), transform.rotation) as Rigidbody;
                    StartCoroutine(destroyBubble(bubbleCloneSidewards));
                }
            }

            for (int y = 0; y <= 4; y++)
            {
                projectileCloneSideWartsOne = Instantiate(projectile, new Vector3(y * 0.41f - 7.256f, y * -0.41f - 4.856f, -6.281f), transform.rotation) as Rigidbody;
                projectileCloneSideWartsOne.AddForce(new Vector3(forceSidewardsLeftX, forceSidewardsY, 0) * sliderLeft, ForceMode.Impulse);
                StartCoroutine(destroyProjectile(projectileCloneSideWartsOne));
            }

            sliderLeft = 0;
        }

        if (Input.GetButton("Fire2"))
        {
            sliderFunctionRight();
        }

        if (Input.GetButtonUp("Fire2"))
        {
            Rigidbody projectileClone;
            Rigidbody projectileCloneSideWards;
            Rigidbody bubbleClone;
            Rigidbody bubbleCloneSidewards;

            for (int x = 0; x <= 7; x++)
            {
                projectileClone = Instantiate(projectile, new Vector3(x * 0.41f + 1.58f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
                projectileClone.AddForce(Vector3.up * sliderRight, ForceMode.Impulse);
                StartCoroutine(destroyProjectile(projectileClone));
                for (int y = 0; y < 1; y++)
                {
                    bubbleClone = Instantiate(bubblePrefab, new Vector3(y * 1 + 3.04f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
                    StartCoroutine(destroyBubble(bubbleClone));
                    bubbleCloneSidewards = Instantiate(bubblePrefab, new Vector3(y * 1 + 5.98f, -6f, -6.281f), transform.rotation) as Rigidbody;
                    StartCoroutine(destroyBubble(bubbleCloneSidewards));
                }
            }
            for (int y = 0; y <= 4; y++)
            {
                projectileCloneSideWards = Instantiate(projectile, new Vector3(y * 0.41f + 5.59f, y * 0.41f - 6.5f, -6.281f), transform.rotation) as Rigidbody;
                projectileCloneSideWards.AddForce(new Vector3(forceSidewardsRightX, forceSidewardsY, 0) * sliderRight, ForceMode.Impulse);
                StartCoroutine(destroyProjectile(projectileCloneSideWards));
            }

            sliderRight = 0;
        }
    }

    private void eyeLookForward()
    {
        if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Mouse X") == 0)
        {
            eyeTimer += Time.deltaTime;
        }
        if (eyeTimer >= 1)
        {
            leftEye.transform.GetChild(0).localPosition = Vector3.MoveTowards(leftEye.transform.GetChild(0).localPosition, new Vector3(0, 0, 0), 0.05f);
            rightEye.transform.GetChild(0).localPosition = Vector3.MoveTowards(rightEye.transform.GetChild(0).localPosition, new Vector3(0, 0, 0), 0.05f);
        }
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Mouse X") != 0)
        {
            leftEye.transform.GetChild(0).localPosition = Vector3.MoveTowards(leftEye.transform.GetChild(0).localPosition, new Vector3(0, 0, 0.8f), 0.05f);
            rightEye.transform.GetChild(0).localPosition = Vector3.MoveTowards(rightEye.transform.GetChild(0).localPosition, new Vector3(0, 0, 0.8f), 0.05f);

            eyeTimer = 0;
        }
    }

    private void eyelidMover()
    {
        if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Mouse X") == 0)
        {
            eyeTimer += Time.deltaTime;
        }
        if (eyeTimer >= 1)
        {
            leftLid.transform.rotation = Quaternion.Euler(92, 0, 0);
            rightLid.transform.rotation = Quaternion.Euler(92, 0, 0);
        }
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Mouse X") != 0)
        {
            leftLid.transform.rotation = Quaternion.Euler(85, 0, 0);
            rightLid.transform.rotation = Quaternion.Euler(85, 0, 0);
            eyeTimer = 0;
        }
    }
}