using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public enum ButtonType { Save, Cancel }
    public ButtonType buttonType;

    private void OnMouseDown()
    {
        switch (buttonType)
        {
            case ButtonType.Save:
                SaveSettings();
                break;
            case ButtonType.Cancel:
                CancelSettings();
                break;
        }
    }

    private void SaveSettings()
    {
        // Save the current slider values
        PlayerPrefs.SetFloat("MusicVolume", FindObjectOfType<SettingsController>().musicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", FindObjectOfType<SettingsController>().sfxSlider.value);
        PlayerPrefs.Save();

        // Load the menu scene
        SceneManager.LoadScene("Menu");
    }

    private void CancelSettings()
    {
        // Reset the volume to the original values
        var settingsController = FindObjectOfType<SettingsController>();
        AudioManager.instance.SetMusicVolume(settingsController.originalMusicVolume);
        AudioManager.instance.SetSFXVolume(settingsController.originalSFXVolume);

        // Load the menu scene
        SceneManager.LoadScene("Menu");
    }
}
