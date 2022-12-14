using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Preferences : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;

    public void Start()
    {
        // set volume controls if saved in PlayerPrefs
        if (PlayerPrefs.HasKey("music"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("music");
            PlayerPrefs.SetFloat("music", musicSlider.value);
        }
        if (PlayerPrefs.HasKey("sfx"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("sfx");
            PlayerPrefs.SetFloat("music", sfxSlider.value);
        }
        PlayerPrefs.Save();
    }

    // set music volume level and save to PlayerPrefs
    public void musicSettings(float vol)
    {
        PlayerPrefs.SetFloat("music", vol);
        audioMixer.SetFloat("music", vol);
    }

    // set SFX volume level and save to PlayerPrefs
    public void SFXSettings(float vol)
    {
        PlayerPrefs.SetFloat("sfx", vol);
        audioMixer.SetFloat("sfx", vol);
    }
}


