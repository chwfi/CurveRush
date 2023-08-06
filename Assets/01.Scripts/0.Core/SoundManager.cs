using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource effectAudio;
    public AudioSource backgroundAudio;

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

        effectAudio = transform.Find("EffectAudio").GetComponent<AudioSource>();
        backgroundAudio = transform.Find("BackgroundAudio").GetComponent<AudioSource>();
    }

    public void StartBackgroundSong()
    {
        backgroundAudio.Play();
    }

    public void StopBackgroundSong()
    {
        backgroundAudio.Stop();
    }

    public int count = 0;

    public void PlayEffect()
    {
        if (soundEffects != null)
        {
            if (count < 3)
            {
                effectAudio.PlayOneShot(soundEffects[1]);
                count++;
            }
            else if (count >= 3)
            {
                effectAudio.PlayOneShot(soundEffects[0]);
                count = 0;
            }
        }
    }

    public void PlayExplosion()
    {
        if (soundEffects != null)
            effectAudio.PlayOneShot(soundEffects[2]);
    }

    public void ClickButtonSound()
    {
        if (soundEffects != null)
            effectAudio.PlayOneShot(soundEffects[3]);
    }
}
