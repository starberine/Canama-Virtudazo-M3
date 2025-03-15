using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int playerLives = 5;
    public int wispsCollected = 0;

    public Image[] heartIcons;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public TMP_Text wispCounterText;
    public TMP_Text messageText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoseLife()
    {
        playerLives--;
        UpdateHearts();

        if (playerLives <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void GainWisp()
    {
        wispsCollected++;
        UpdateWispCounter();
    }

    public void TrySubmitWisps()
    {
        if (wispsCollected >= 8)
        {
            SceneManager.LoadScene("GameWinScene");
        }
        else
        {
            StartCoroutine(ShowMessage($"The sword awaits, but only the worthy shall prevail."));
        }
    }

    private IEnumerator ShowMessage(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        messageText.gameObject.SetActive(false);
    }

    public void ActivateLightForDuration(Light pointLight, float duration)
    {
        if (pointLight != null)
        {
            pointLight.enabled = true;
            pointLight.gameObject.SetActive(true);
            StartCoroutine(TurnOffLightAfterDelay(pointLight, duration));
        }
    }

    private IEnumerator TurnOffLightAfterDelay(Light pointLight, float duration)
    {
        yield return new WaitForSeconds(duration);

        if (pointLight != null)
        {
            pointLight.enabled = false;
            pointLight.gameObject.SetActive(false);
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < heartIcons.Length; i++)
        {
            heartIcons[i].sprite = i < playerLives ? fullHeart : emptyHeart;
        }
    }

    private void UpdateWispCounter()
    {
        wispCounterText.text = $"Wisps: {wispsCollected}";
    }
} 
