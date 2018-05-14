using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUi;

    private void Update()
    {
        //     if (Input.GetButtonDown("Cancel"))
        //     {
        //         if (GameIsPaused)
        //         {
        //             Resume();
        //         }
        //         else
        //         {
        //             Pause();
        //         }
        //     }
    }

    public void ButtonPauseMenu()
    {
        Pause();
    }

    public void ButtonResumeGame()
    {
        Resume();
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}