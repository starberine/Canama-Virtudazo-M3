using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro namespace

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
