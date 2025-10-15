//Referenced from this linK: https://howto.im/q/how-do-i-add-a-settings-menu-to-my-unity-game

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    //public Toggle fullscreenToggle;

    private int currentResolutionIndex = 0;
    private Resolution[] resolutions;

    void Start()
    {
        // Load saved settings or use default values
        LoadSettings();
        
        // Add listeners to UI elements
        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.Save();
    }

    public void ChangeFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        // Load volume
        if (PlayerPrefs.HasKey("Volume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
            AudioListener.volume = volumeSlider.value;
        }
        else
        {
            volumeSlider.value = 1f; // Default volume
            AudioListener.volume = 1f;
        }

    }
}
