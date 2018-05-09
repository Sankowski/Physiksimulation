using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public Animator animator;
    public Canvas CanvasOff;
    public Animator GameStartAnimator;
    public AudioClip audioSound;

    public void Animation()
    {
        animator.SetTrigger("StartButton");
        CanvasOff.enabled = false;
    }

    public void StartGame()
    {
        animator.SetTrigger("ButtonNewGame");
        AudioChangerScript.changeMusic(audioSound);
        CanvasOff.enabled = false;
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