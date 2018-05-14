using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Slider>().value = AudioChangerScript.audioMixer.volume;
    }

    public void SetVolume(float volume)
    {
        AudioChangerScript.audioMixer.volume = volume;
    }
}