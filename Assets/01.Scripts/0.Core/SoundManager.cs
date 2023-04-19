using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    public AudioClip background;
    public AudioClip[] soundEffects;

    public void StartBackgroundSong()
    {
        audioSource.clip = background;
        audioSource.Play();
    }

    public void StopBackgroundSong()
    {
        audioSource.clip = background;
        audioSource.Stop();
    }

    public int count = 0;

    public void PlayEffect()
    {
        if (soundEffects != null)
        {
            if (count < 3)
            {
                audioSource.PlayOneShot(soundEffects[1]);
                count++;
            }
            else if (count >= 3)
            {
                audioSource.PlayOneShot(soundEffects[0]);
                count = 0;
            }
        }
    }

    public void PlayExplosion()
    {
        if (soundEffects != null)
            audioSource.PlayOneShot(soundEffects[2]);
    }

    public void ClickButtonSound()
    {
        if (soundEffects != null)
            audioSource.PlayOneShot(soundEffects[3]);
    }
}
