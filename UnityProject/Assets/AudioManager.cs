using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clips ----------")]
    public AudioClip mapBackground;
    public AudioClip levelBackground;
    public AudioClip examBackground;
    public AudioClip death;
    public AudioClip coins;
    public AudioClip energie;
    public AudioClip hoverSound;
    public AudioClip clickSound;
    public AudioClip popUpSoundHappy;
    public AudioClip popUpSoundsad;

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
        PlayBackgroundMusic(SceneManager.GetActiveScene().name); // Play initial scene music
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBackgroundMusic(scene.name);
    }

    public void PlayBackgroundMusic(string sceneName)
    {
        if (sceneName == "Map")
        {
            musicSource.clip = mapBackground;
        }
        else if (sceneName.StartsWith("Level"))
        {
            musicSource.clip = levelBackground;
        }
        else if (sceneName.StartsWith("Klausurphase"))  // Add this check for the exam phase
        {
            musicSource.clip = examBackground;
        }
        else
        {
            musicSource.clip = mapBackground; // Default music
        }

        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayHoverSound()
    {
        if (hoverSound != null)
        {
            SFXSource.PlayOneShot(hoverSound);
        }
    }

    public void PlayClickSound()
    {
        if (clickSound != null)
        {
            SFXSource.PlayOneShot(clickSound);
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        SFXSource.volume = volume;
    }
}
