using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    [HideInInspector]
    public float originalMusicVolume;
    [HideInInspector]
    public float originalSFXVolume;

    void Start()
    {
        // Load the saved volume levels
        originalMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        originalSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        // Set the sliders to the saved values
        musicSlider.value = originalMusicVolume;
        sfxSlider.value = originalSFXVolume;

        // Add listeners to the sliders
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void SetMusicVolume(float volume)
    {
        AudioManager.instance.SetMusicVolume(volume);
    }

    void SetSFXVolume(float volume)
    {
        AudioManager.instance.SetSFXVolume(volume);
    }
}
