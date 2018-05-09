using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip audioSound;

    private void changeScene()
    {
        SceneManager.LoadScene("Level1");
        AudioChangerScript.changeMusic(audioSound);
    }
}