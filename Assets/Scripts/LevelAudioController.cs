using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAudioController : MonoBehaviour
{

    public AudioSource mainBackgroundAudio;
    public AudioSource jumpingAudio;
    public AudioSource clickingAudio;
    public static float mainBGVolume;
    public static float sfxVolume;
    public Slider bgSlider;
    public Slider levelSfxSlider;


    private void Start()
    {

        mainBGVolume = AudioSettings.menuBackgroundAudioVolume;
        sfxVolume = AudioSettings.sfxAudioVolume;
        bgSlider.value = mainBGVolume;
        levelSfxSlider.value = sfxVolume;
    }

    void Update()
    {
        mainBackgroundAudio.volume = mainBGVolume;
        jumpingAudio.volume = sfxVolume;
        clickingAudio.volume = sfxVolume;
    }

    public void SetBackgroundVolume(float vol)
    {
        mainBGVolume = vol;
    }

    public void SetSFXVolume(float vol)
    {
        sfxVolume = vol;
    }

    public void PlayButtonClickAudio()
    {
        clickingAudio.Play();
    }

    public void PlayPlayerJumpAudio()
    {
        jumpingAudio.Play();
    }
}
