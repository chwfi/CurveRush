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

    [SerializeField]
    private AudioSource lobby;

    public void OnMuteMusic()
    {
        soundManager.background = null;
        muteMusic.gameObject.SetActive(true);
    }

    public void OffMuteMusic()
    {
        soundManager.background = _background;
        muteMusic.gameObject.SetActive(false);
    }

    public void OnMuteEffect()
    {
        soundManager.soundEffects = null;
        muteEffect.gameObject.SetActive(true);
    }

    public void OffMuteEffect()
    {
        soundManager.soundEffects = _soundEffects;
        muteEffect.gameObject.SetActive(false);
    }
}
