using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuView : View
{
    [Header("Buttons")]
    public Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(OnBackPressed);
    }

    private void OnBackPressed()
    {
        Debug.Log("Back button pressed!");
        ViewManager.ShowLast();
    }
}
