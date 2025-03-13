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
        button.onClick.AddListener(action);

        var spriteState = new SpriteState
        {
            pressedSprite = pressed
        };

        button.spriteState = spriteState;
        button.image.sprite = normal;
    }

    private void OnPlayPressed()
    {
        Debug.Log("Play button pressed!");
        SceneManager.LoadScene("TestGameScene");
    }

    private void OnExitPressed()
    {
        Debug.Log("Exit button pressed!");
        Application.Quit();
    }

    private void OnSettingsPressed()
    {
        Debug.Log("Settings button pressed!");
        ViewManager.Show<SettingsMenuView>();
    }
}
