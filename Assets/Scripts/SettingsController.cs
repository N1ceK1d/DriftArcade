using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class SettingsController : MonoBehaviour
{
    public AudioMixer mixer;
    public TMP_Dropdown qualityDropdown;
    float audioVolume;
    public Slider volumeSlider;
    public int controllType = 0;

    private void Awake() {
        LoadSettings();
    }

    public void AudioVolume(float sliderValue)
    {
        mixer.SetFloat("masterVolume", sliderValue);
        audioVolume = sliderValue;
    }

    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("FullScreenPreference", System.Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("Volume", audioVolume);
    }

    public void LoadSettings()
    {
        if(PlayerPrefs.HasKey("Volume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
            mixer.SetFloat("masterVolume", PlayerPrefs.GetFloat("Volume"));
        }

        if(PlayerPrefs.HasKey("QualitySettingPreference"))
        {
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        }
        else 
        {
            qualityDropdown.value = 3;
        }
    }
}