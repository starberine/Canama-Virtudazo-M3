using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinView : MonoBehaviour
{
    private void Start()
    {
    }

    public void OnRetryButtonClicked()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonPressSFX);
        SceneManager.LoadScene("TestGameScene"); 
    }

    public void OnMainMenuButtonClicked()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonPressSFX);
        SceneManager.LoadScene("MainMenuScene");
    }
}
