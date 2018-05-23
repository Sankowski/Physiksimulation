using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    public static bool OptionsIsActivatet = false;

    public GameObject OptionsMenu;

    private void Update()
    {
    }

    public void Resume()
    {
        OptionsMenu.SetActive(false);
        Time.timeScale = 1f;
        OptionsIsActivatet = false;
    }

    public void Pause()
    {
        OptionsMenu.SetActive(true);
        Time.timeScale = 0f;
        OptionsIsActivatet = true;
    }
}