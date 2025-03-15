using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuView : View
{
    [Header("Buttons")]
    public Button playButton;
    public Button exitButton;
    public Button settingsButton;

    [Header("Default Button Sprites")]
    public Sprite normalSprite;
    public Sprite pressedSprite;

    [Header("Settings Button Sprites")]
    public Sprite settingsNormalSprite;
    public Sprite settingsPressedSprite;

    private void Start()
    {
        SetupButton(playButton, normalSprite, pressedSprite, OnPlayPressed);
        SetupButton(exitButton, normalSprite, pressedSprite, OnExitPressed);
        SetupButton(settingsButton, settingsNormalSprite, settingsPressedSprite, OnSettingsPressed);
    }

    private void SetupButton(Button button, Sprite normal, Sprite pressed, UnityEngine.Events.UnityAction action)
    {
        button.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.buttonPressSFX); // Play button press sound
            action.Invoke();
        });

        var spriteState = new SpriteState
        {
            pressedSprite = pressed
        };

        button.spriteState = spriteState;
        button.image.sprite = normal;
    }

    private void OnPlayPressed()
    {
        SceneManager.LoadScene("TestGameScene");
    }

    private void OnExitPressed()
    {
        Application.Quit();
    }

    private void OnSettingsPressed()
    {
        ViewManager.Show<SettingsMenuView>();
    }
}
