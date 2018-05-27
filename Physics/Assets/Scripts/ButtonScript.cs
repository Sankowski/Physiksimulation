using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public Animator animator;
    public Canvas canvasOff;
    public Animator gameStartAnimator;
    public AudioClip audioSound;

    public void Animation()
    {
        animator.SetTrigger("StartButton");
        canvasOff.enabled = false;
    }

    public void StartGame()
    {
        animator.SetTrigger("ButtonNewGame");
        AudioChangerScript.changeMusic(audioSound);
        canvasOff.enabled = false;
    }

    public void CloseGame()
    {
        Debug.Log("close");
        Application.Quit();
    }

    public void Button(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}