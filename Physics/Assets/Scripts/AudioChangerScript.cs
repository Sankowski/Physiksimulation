using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChangerScript : MonoBehaviour
{
    public static AudioSource audioMixer;
    public AudioClip audioSound;

    private void Start()
    {
        audioMixer = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
        changeMusic(audioSound);
    }

    public void SetVolume(float volume)
    {
        audioMixer.volume = volume;
    }

    public static void changeMusic(AudioClip audio)
    {
        audioMixer.clip = audio;
        audioMixer.Play();
    }
}