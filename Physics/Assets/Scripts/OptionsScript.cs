using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    public static bool optionsIsActivatet = false;

    public GameObject optionsMenu;

    private void Update()
    {
    }

    public void Resume()
    {
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
        optionsIsActivatet = false;
    }

    public void Pause()
    {
        optionsMenu.SetActive(true);
        Time.timeScale = 0f;
        optionsIsActivatet = true;
    }
}