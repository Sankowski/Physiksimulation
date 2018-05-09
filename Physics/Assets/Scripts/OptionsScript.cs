using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    public static bool OptionsIsActivatet = false;

    public GameObject OptionsMenu;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (OptionsIsActivatet)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        OptionsMenu.SetActive(false);
        Time.timeScale = 1f;
        OptionsIsActivatet = false;
    }

    private void Pause()
    {
        OptionsMenu.SetActive(true);
        Time.timeScale = 0f;
        OptionsIsActivatet = true;
    }
}