//Referenced from this linK: https://howto.im/q/how-do-i-add-a-settings-menu-to-my-unity-game

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    //public Toggle fullscreenToggle;


    void Start()
    {
        // Load saved settings or use default values
        //LoadSettings();
        
        // Add listeners to UI elements
        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.Save();
    }

}
