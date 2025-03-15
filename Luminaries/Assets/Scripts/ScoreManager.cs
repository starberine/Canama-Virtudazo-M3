using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections; // Import for Coroutine support

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int playerLives = 5;
    public int wispsCollected = 0;

    public Image[] heartIcons; // Assign in Inspector
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public TMP_Text wispCounterText; // Use TMP_Text for TextMeshPro

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
            Debug.Log("Game Over!");
            // Trigger Game Over logic here
        }
    }

    public void GainWisp()
    {
        wispsCollected++;
        UpdateWispCounter();
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
