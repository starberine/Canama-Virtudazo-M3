using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip mainMenuBGM;
    public AudioClip buttonPressSFX;
    public AudioClip playerJumpSFX;
    public AudioClip collectSpriteSFX;
    public AudioClip enemyDeathSFX;

    [Header("Zone BGMs")]
    public AudioClip meadowlandsBGM;
    public AudioClip grovesBGM;
    public AudioClip shroomvilleBGM;

    [Header("Game End BGMs")]
    public AudioClip gameWinBGM;
    public AudioClip gameLoseBGM;

    private float masterVolume = 1f;
    private float bgmVolume = 1f;
    private float sfxVolume = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenuScene")
        {
            PlayBGM(mainMenuBGM);
        }
        else if (scene.name == "GameWinScene")
        {
            PlayBGM(gameWinBGM);
        }
        else if (scene.name == "GameOverScene")
        {
            PlayBGM(gameLoseBGM);
        }
    }

    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource.clip == clip && bgmSource.isPlaying) return;

        bgmSource.Stop();
        bgmSource.clip = clip;
        bgmSource.loop = true;
        bgmSource.volume = bgmVolume * masterVolume;
        bgmSource.time = 2f; // Skip initial 2 seconds
        bgmSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip, sfxVolume * masterVolume);
    }

    public void PlayJumpSFX()
    {
        PlaySFX(playerJumpSFX);
    }

    public void PlayCollectSFX()
    {
        PlaySFX(collectSpriteSFX);
    }

    public void PlayEnemyDeathSFX()
    {
        PlaySFX(enemyDeathSFX);
    }

    public void SetMasterVolume(float value)
    {
        masterVolume = value;
        UpdateVolumes();
    }

    public void SetBGMVolume(float value)
    {
        bgmVolume = value;
        bgmSource.volume = bgmVolume * masterVolume;
    }

    public void SetSFXVolume(float value)
    {
        sfxVolume = value;
    }

    public float GetMasterVolume() => masterVolume;
    public float GetBGMVolume() => bgmVolume;
    public float GetSFXVolume() => sfxVolume;

    private void UpdateVolumes()
    {
        bgmSource.volume = bgmVolume * masterVolume;
        sfxSource.volume = sfxVolume * masterVolume;
    }
}
