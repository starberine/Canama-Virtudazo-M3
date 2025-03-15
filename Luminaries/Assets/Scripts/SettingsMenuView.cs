using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuView : View
{
    [Header("Buttons")]
    public Button backButton;

    [Header("Sliders")]
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    private void Start()
    {
        // Initialize slider values
        masterSlider.value = AudioManager.instance.GetMasterVolume();
        bgmSlider.value = AudioManager.instance.GetBGMVolume();
        sfxSlider.value = AudioManager.instance.GetSFXVolume();

        // Add listeners to sliders
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        // Back button listener
        backButton.onClick.AddListener(OnBackPressed);
    }

    private void SetMasterVolume(float value)
    {
        AudioManager.instance.SetMasterVolume(value);
    }

    private void SetBGMVolume(float value)
    {
        AudioManager.instance.SetBGMVolume(value);
    }

    private void SetSFXVolume(float value)
    {
        AudioManager.instance.SetSFXVolume(value);
    }

    private void OnBackPressed()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonPressSFX);
        ViewManager.ShowLast();
    }
}
