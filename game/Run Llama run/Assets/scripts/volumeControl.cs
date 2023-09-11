using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class volumeControl : MonoBehaviour
{

    //public AudioMixer audioMixer;
    public Slider slider;

    void Awake()
    {
        if (slider != null && PlayerPrefs.HasKey("volume"))
        {
            float wantedVolume = PlayerPrefs.GetFloat("volume", 0);

            slider.value = wantedVolume;
        }
    }

    public void setVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
    }
}
