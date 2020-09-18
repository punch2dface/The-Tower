using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioSettings : MonoBehaviour
{
    public AudioSource menuBackgroundAudio;
    public AudioSource sfxClickAudio;
    public static float menuBackgroundAudioVolume;
    public static float sfxAudioVolume;
    public Slider mainSlider;
    public Slider sfxSlider;

    private void Start()
    {
        if (LevelAudioController.mainBGVolume == 0)
        {
            menuBackgroundAudioVolume = 1.0f;
            sfxAudioVolume = 1.0f;
            Debug.Log("null");
        } 
        else
        {
            menuBackgroundAudioVolume = LevelAudioController.mainBGVolume;
            sfxAudioVolume = LevelAudioController.sfxVolume;
            mainSlider.value = menuBackgroundAudioVolume;
            sfxSlider.value = sfxAudioVolume;
        }
    }

    void Update()
    {
        menuBackgroundAudio.volume = menuBackgroundAudioVolume;
        sfxClickAudio.volume = sfxAudioVolume;
    }

    public void SetMenuBackgroundAudioVolume(float vol)
    {
        menuBackgroundAudioVolume = vol;
    }

    public void SetSFXAudioVolume(float vol)
    {
        sfxAudioVolume = vol;
    }

    public void PlayButtonClickAudio()
    {
        sfxClickAudio.Play();
    }

}
