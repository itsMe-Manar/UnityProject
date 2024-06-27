
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
   
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Source ----------")]

    public AudioClip background;
    public AudioClip death;
    public AudioClip coins;
    public AudioClip energie;
    public AudioClip hoverSound;
    public AudioClip popUpSoundHappy;
    public AudioClip popUpSoundsad;

    private void Start()
    {
        musicSource.clip = background;
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


}
