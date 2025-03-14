using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinView : MonoBehaviour
{
    private void Start()
    {
    }

    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene("TestGameScene"); 
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
