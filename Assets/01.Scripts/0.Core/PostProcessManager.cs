using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessManager : MonoBehaviour
{
    public Bloom bloom;
    public float speed = 1f;

    public bool isLoading;

    private void Start()
    {
        Volume volume = GetComponent<Volume>();
        volume.profile.TryGet<Bloom>(out bloom);
        if (isLoading)
        {
            SetGame();
            bloom.intensity.value = 0.5f;
        }
        else if (!isLoading)
            SetStart();
    }

    private void Update()
    {
        float hue = Mathf.PingPong(Time.time * speed, 1f);
        Color newColor = Color.HSVToRGB(hue, 0.75f, 1f); // S 값을 0.5로 고정
        bloom.tint.Override(newColor);
    }

    public void SetStart()
    {
        Volume volume = GetComponent<Volume>();
        volume.profile.TryGet<Bloom>(out bloom);
        bloom.threshold.value = 0.08f;
        bloom.intensity.value = 0.5f;
        bloom.scatter.value = 0.9f;
    }

    public void SetGame()
    {
        Volume volume = GetComponent<Volume>();
        volume.profile.TryGet<Bloom>(out bloom);
        bloom.intensity.value = 1.1f;
        bloom.threshold.value = 0.6f;
        bloom.scatter.value = 0.6f;
    }
}
