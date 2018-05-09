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

    public Rigidbody projectile;
    // public Rigidbody bubble;

    public Slider leftSlider;
    public Slider rightSlider;

    public float ForceSidewardsRightX = -0.5f;
    public float ForceSidewardsLeftX = 0.5f;
    public float ForceSidewardsY = 0.5f;

    private float horizontalMovement;
    private float sliderLeft = 0;
    private float sliderRight = 0;
    private float eyeTimer = 2;

    private bool sliderLeftBool = true;
    private bool sliderRightBool = true;
    private bool shaker = true;

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
    }

    private void Update()
    {
        eyelidMover();
        leftEye.transform.LookAt(spike.transform.position);
        rightEye.transform.LookAt(spike.transform.position);

        spikeController();
        projectilePrefab();

        if (Input.GetKeyDown(KeyCode.Q) && shaker)
        {
            StartCoroutine(levelShaker(level, -0.01f));
        }

        if (Input.GetKeyDown(KeyCode.E) && shaker)
        {
            StartCoroutine(levelShaker(level, 0.01f));
        }

        leftSlider.value = sliderLeft;
        rightSlider.value = sliderRight;
    }

    private IEnumerator destroyProjectile(Rigidbody rb)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(rb.gameObject);
    }

    private IEnumerator levelShaker(GameObject level, float moveDistance)
    {
        shaker = false;
        for (int i = 0; i < 25; i++)
        {
            yield return null;
            sliderUiRight.GetComponent<RectTransform>().Translate(0, -moveDistance * 37.05f, 0);
            sliderUiLeft.GetComponent<RectTransform>().Translate(0, -moveDistance * 37.05f, 0);
            level.transform.Translate(moveDistance, 0, 0);
        }
        for (int i = 0; i < 25; i++)
        {
            yield return null;
            sliderUiRight.GetComponent<RectTransform>().Translate(0, moveDistance * 37.05f, 0);
            sliderUiLeft.GetComponent<RectTransform>().Translate(0, moveDistance * 37.05f, 0);
            level.transform.Translate(-moveDistance, 0, 0);
        }
        shaker = true;
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

    private void spikeController()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        spike.transform.Translate(horizontalMovement * 0.15f, 0, 0);

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
            Rigidbody projectileCloneOne;
            Rigidbody projectileCloneTwo;
            Rigidbody projectileCloneThree;
            Rigidbody projectileCloneFour;
            Rigidbody projectileCloneFive;
            Rigidbody projectileCloneSix;
            Rigidbody projectileCloneSideWartsOne;
            Rigidbody projectileCloneSideWartsTwo;
            Rigidbody projectileCloneSideWartsThree;
            Rigidbody projectileCloneSideWartsFour;
            Rigidbody projectileCloneSideWartsFive;
            // Rigidbody bubbleClone;

            //  for (int i = 0; i < 8; i++)
            //  {
            //      bubbleClone = Instantiate(bubble, new Vector3(-3.068f + i, -7.37f, -6.8f), transform.rotation) as Rigidbody;
            //      bubbleClone.AddForce(Vector3.up * sliderLeft, ForceMode.Impulse);
            //      StartCoroutine(destroyBubble(bubbleClone));
            //  }

            projectileClone = Instantiate(projectile, new Vector3(-3.068f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneOne = Instantiate(projectile, new Vector3(-4.57f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneTwo = Instantiate(projectile, new Vector3(-4.07f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneThree = Instantiate(projectile, new Vector3(-3.57f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneFour = Instantiate(projectile, new Vector3(-2.57f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneFive = Instantiate(projectile, new Vector3(-2.07f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneSix = Instantiate(projectile, new Vector3(-1.57f, -7.37f, -6.281f), transform.rotation) as Rigidbody;

            projectileCloneSideWartsOne = Instantiate(projectile, new Vector3(-7.256f, -4.856f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneSideWartsTwo = Instantiate(projectile, new Vector3(-6.7f, -5.356f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneSideWartsThree = Instantiate(projectile, new Vector3(-6.256f, -5.856f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneSideWartsFour = Instantiate(projectile, new Vector3(-5.756f, -6.356f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneSideWartsFive = Instantiate(projectile, new Vector3(-5.256f, -6.856f, -6.281f), transform.rotation) as Rigidbody;

            projectileClone.AddForce(Vector3.up * sliderLeft, ForceMode.Impulse);
            projectileCloneOne.AddForce(Vector3.up * sliderLeft, ForceMode.Impulse);
            projectileCloneTwo.AddForce(Vector3.up * sliderLeft, ForceMode.Impulse);
            projectileCloneThree.AddForce(Vector3.up * sliderLeft, ForceMode.Impulse);
            projectileCloneFour.AddForce(Vector3.up * sliderLeft, ForceMode.Impulse);
            projectileCloneFive.AddForce(Vector3.up * sliderLeft, ForceMode.Impulse);
            projectileCloneSix.AddForce(Vector3.up * sliderLeft, ForceMode.Impulse);

            projectileCloneSideWartsOne.AddForce(new Vector3(ForceSidewardsLeftX, ForceSidewardsY, 0) * sliderLeft, ForceMode.Impulse);
            projectileCloneSideWartsTwo.AddForce(new Vector3(ForceSidewardsLeftX, ForceSidewardsY, 0) * sliderLeft, ForceMode.Impulse);
            projectileCloneSideWartsThree.AddForce(new Vector3(ForceSidewardsLeftX, ForceSidewardsY, 0) * sliderLeft, ForceMode.Impulse);
            projectileCloneSideWartsFour.AddForce(new Vector3(ForceSidewardsLeftX, ForceSidewardsY, 0) * sliderLeft, ForceMode.Impulse);
            projectileCloneSideWartsFive.AddForce(new Vector3(ForceSidewardsLeftX, ForceSidewardsY, 0) * sliderLeft, ForceMode.Impulse);

            //StartCoroutine(destroyProjectile(projectileClone));

            StartCoroutine(destroyProjectile(projectileClone));
            StartCoroutine(destroyProjectile(projectileCloneOne));
            StartCoroutine(destroyProjectile(projectileCloneTwo));
            StartCoroutine(destroyProjectile(projectileCloneThree));
            StartCoroutine(destroyProjectile(projectileCloneFour));
            StartCoroutine(destroyProjectile(projectileCloneFive));
            StartCoroutine(destroyProjectile(projectileCloneSix));

            StartCoroutine(destroyProjectile(projectileCloneSideWartsOne));
            StartCoroutine(destroyProjectile(projectileCloneSideWartsTwo));
            StartCoroutine(destroyProjectile(projectileCloneSideWartsThree));
            StartCoroutine(destroyProjectile(projectileCloneSideWartsFour));
            StartCoroutine(destroyProjectile(projectileCloneSideWartsFive));
            sliderLeft = 0;
        }

        if (Input.GetButton("Fire2"))
        {
            sliderFunctionRight();
        }

        if (Input.GetButtonUp("Fire2"))
        {
            Rigidbody projectileClone;
            Rigidbody projectileCloneOne;
            Rigidbody projectileCloneTwo;
            Rigidbody projectileCloneThree;
            Rigidbody projectileCloneFour;
            Rigidbody projectileCloneFive;
            Rigidbody projectileCloneSix;
            Rigidbody projectileCloneSideWartsOne;
            Rigidbody projectileCloneSideWartsTwo;
            Rigidbody projectileCloneSideWartsThree;
            Rigidbody projectileCloneSideWartsFour;
            Rigidbody projectileCloneSideWartsFive;

            projectileClone = Instantiate(projectile, new Vector3(1.58f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneOne = Instantiate(projectile, new Vector3(2.08f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneTwo = Instantiate(projectile, new Vector3(2.58f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneThree = Instantiate(projectile, new Vector3(3.08f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneFour = Instantiate(projectile, new Vector3(3.58f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneFive = Instantiate(projectile, new Vector3(4.08f, -7.37f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneSix = Instantiate(projectile, new Vector3(4.58f, -7.37f, -6.281f), transform.rotation) as Rigidbody;

            projectileCloneSideWartsOne = Instantiate(projectile, new Vector3(7.233f, -4.856f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneSideWartsTwo = Instantiate(projectile, new Vector3(6.73f, -5.36f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneSideWartsThree = Instantiate(projectile, new Vector3(6.23f, -5.86f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneSideWartsFour = Instantiate(projectile, new Vector3(5.73f, -6.36f, -6.281f), transform.rotation) as Rigidbody;
            projectileCloneSideWartsFive = Instantiate(projectile, new Vector3(5.73f, -6.36f, -6.281f), transform.rotation) as Rigidbody;

            projectileClone.AddForce(Vector3.up * sliderRight, ForceMode.Impulse);
            projectileCloneOne.AddForce(Vector3.up * sliderRight, ForceMode.Impulse);
            projectileCloneTwo.AddForce(Vector3.up * sliderRight, ForceMode.Impulse);
            projectileCloneThree.AddForce(Vector3.up * sliderRight, ForceMode.Impulse);
            projectileCloneFour.AddForce(Vector3.up * sliderRight, ForceMode.Impulse);
            projectileCloneFive.AddForce(Vector3.up * sliderRight, ForceMode.Impulse);
            projectileCloneSix.AddForce(Vector3.up * sliderRight, ForceMode.Impulse);

            projectileCloneSideWartsOne.AddForce(new Vector3(ForceSidewardsRightX, ForceSidewardsY, 0) * sliderRight, ForceMode.Impulse);
            projectileCloneSideWartsTwo.AddForce(new Vector3(ForceSidewardsRightX, ForceSidewardsY, 0) * sliderRight, ForceMode.Impulse);
            projectileCloneSideWartsThree.AddForce(new Vector3(ForceSidewardsRightX, ForceSidewardsY, 0) * sliderRight, ForceMode.Impulse);
            projectileCloneSideWartsFour.AddForce(new Vector3(ForceSidewardsRightX, ForceSidewardsY, 0) * sliderRight, ForceMode.Impulse);
            projectileCloneSideWartsFive.AddForce(new Vector3(ForceSidewardsRightX, ForceSidewardsY, 0) * sliderRight, ForceMode.Impulse);

            StartCoroutine(destroyProjectile(projectileClone));
            StartCoroutine(destroyProjectile(projectileCloneOne));
            StartCoroutine(destroyProjectile(projectileCloneTwo));
            StartCoroutine(destroyProjectile(projectileCloneThree));
            StartCoroutine(destroyProjectile(projectileCloneFour));
            StartCoroutine(destroyProjectile(projectileCloneFive));
            StartCoroutine(destroyProjectile(projectileCloneSix));

            StartCoroutine(destroyProjectile(projectileCloneSideWartsOne));
            StartCoroutine(destroyProjectile(projectileCloneSideWartsTwo));
            StartCoroutine(destroyProjectile(projectileCloneSideWartsThree));
            StartCoroutine(destroyProjectile(projectileCloneSideWartsFour));
            StartCoroutine(destroyProjectile(projectileCloneSideWartsFive));
            sliderRight = 0;
        }
    }

    //  private IEnumerator destroyBubble(Rigidbody bubbleClone)
    //  {
    //      yield return new WaitForSeconds(5f);
    //      Destroy(bubbleClone.gameObject);
    //  }

    private void eyeLookForward()
    {
        if (Input.GetAxis("Horizontal") == 0)
        {
            eyeTimer += Time.deltaTime;
        }
        if (eyeTimer >= 1)
        {
            leftEye.transform.GetChild(0).localPosition = Vector3.MoveTowards(leftEye.transform.GetChild(0).localPosition, new Vector3(0, 0, 0), 0.05f);
            rightEye.transform.GetChild(0).localPosition = Vector3.MoveTowards(rightEye.transform.GetChild(0).localPosition, new Vector3(0, 0, 0), 0.05f);
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            leftEye.transform.GetChild(0).localPosition = Vector3.MoveTowards(leftEye.transform.GetChild(0).localPosition, new Vector3(0, 0, 0.8f), 0.05f);
            rightEye.transform.GetChild(0).localPosition = Vector3.MoveTowards(rightEye.transform.GetChild(0).localPosition, new Vector3(0, 0, 0.8f), 0.05f);

            eyeTimer = 0;
        }
    }

    private void eyelidMover()
    {
        if (Input.GetAxis("Horizontal") == 0)
        {
            eyeTimer += Time.deltaTime;
        }
        if (eyeTimer >= 1)
        {
            // leftLid.transform.rotation = Quaternion.Euler(Vector3.MoveTowards(leftLid.transform.rotation.eulerAngles, new Vector3(0, 0, 0), 1)); //(92, 0, 0);
            leftLid.transform.rotation = Quaternion.Euler(92, 0, 0);
            rightLid.transform.rotation = Quaternion.Euler(92, 0, 0);
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            // leftLid.transform.rotation = Quaternion.Euler(Vector3.MoveTowards(leftLid.transform.rotation.eulerAngles, new Vector3(0, 0, 180), 1)); //(92, 0, 0);
            leftLid.transform.rotation = Quaternion.Euler(85, 0, 0);
            rightLid.transform.rotation = Quaternion.Euler(85, 0, 0);
            eyeTimer = 0;
        }
    }
}