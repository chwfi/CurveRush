using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]
    private AudioSource audioSource;

    public AudioClip background;
    public AudioClip[] soundEffects;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }

        var obj = FindObjectsOfType<SoundManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        StartBackgroundSong();
    }

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
