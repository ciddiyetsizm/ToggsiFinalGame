using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicMixerController : MonoBehaviour
{
    public AudioMixer mixer;

    
    public Slider masterSlider;
    public Slider sesSlider;
    public Slider musicSlider;

    public GameObject duraklatmaMenusu;

    void SetSlider()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        sesSlider.value = PlayerPrefs.GetFloat("SesVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            mixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
            mixer.SetFloat("SesVolume", PlayerPrefs.GetFloat("SesVolume"));
            mixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));

            SetSlider();

        }
        else
        {
            SetSlider();
        }
        
    }
    public void UpdateMasterVolume()
    {
        mixer.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
    }
    public void UpdateMusicVolume()
    {
        mixer.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("MusciVolume", musicSlider.value);
    }
    public void UpdateSesVolume()
    {
        mixer.SetFloat("SesVolume", sesSlider.value);
        PlayerPrefs.SetFloat("SesVolume", sesSlider.value);
    }
    public void sesGeri()
    {
        Time.timeScale = 1f;
        duraklatmaMenusu.SetActive(false);
    }
}
