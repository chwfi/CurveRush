using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private Image muteMusic;
    [SerializeField]
    private Image muteEffect;
    [SerializeField]
    private SoundManager soundManager;
    [SerializeField]
    private AudioClip _background;
    [SerializeField]
    private AudioClip[] _soundEffects;

    private AudioSource lobby;

    private void Start()
    {
        lobby = FindAnyObjectByType<AudioSource>();
    }

    public void OnMuteMusic()
    {
        soundManager.backgroundAudio.volume = 0;
        muteMusic.gameObject.SetActive(true);
    }

    public void OffMuteMusic()
    {
        soundManager.backgroundAudio.volume = 0.7f;
        muteMusic.gameObject.SetActive(false);
    }

    public void OnMuteEffect()
    {
        soundManager.effectAudio.volume = 0;
        muteEffect.gameObject.SetActive(true);
    }

    public void OffMuteEffect()
    {
        soundManager.effectAudio.volume = 1;
        muteEffect.gameObject.SetActive(false);
    }
}
