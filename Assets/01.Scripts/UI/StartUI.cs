using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class StartUI : MonoBehaviour
{
    [SerializeField]
    private Image upperUI;
    [SerializeField]
    private Image lowerUI;
    [SerializeField]
    private GameObject RightObj;
    [SerializeField]
    private GameObject LeftObj;
    [SerializeField]
    private GameObject tts;
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject scoreText;

    [SerializeField]
    private GameObject touchUI;

    private void Start()
    {
        AbleStartUI();
    }

    public void DisableStartUI()
    {
        tts.SetActive(false);
        startButton.SetActive(false);
        upperUI.rectTransform.DOAnchorPos(new Vector2(0, 1000f), 0.5f);
        lowerUI.rectTransform.DOAnchorPos(new Vector2(0, -650f), 0.5f);
        RightObj.transform.DOMoveX(-10, 0.5f);
        LeftObj.transform.DOMoveX(10, 0.5f);
        touchUI.gameObject.SetActive(true);
        Invoke("RePost", 0.3f);      
    }

    public void RePost()
    {
        RightObj.gameObject.SetActive(false);
        upperUI.gameObject.SetActive(false);
        lowerUI.gameObject.SetActive(false);          
    }

    public void DisableTouchUI()
    {
        touchUI.gameObject.SetActive(false);
    }

    public void AbleStartUI()
    {
        //scoreText.SetActive(false);
        tts.SetActive(true);
        startButton.SetActive(true);
        upperUI.gameObject.SetActive(true);
        lowerUI.gameObject.SetActive(true);
        RightObj.gameObject.SetActive(true);
        upperUI.rectTransform.DOAnchorPos(new Vector2(0, 45), 0.5f);
        lowerUI.rectTransform.DOAnchorPos(new Vector2(0, -100), 0.5f);
        RightObj.transform.DOMoveX(-2.5f, 0.5f);
        LeftObj.transform.DOMoveX(3.45f, 0.5f);
    }

    public void SetTouchUI()
    {
        touchUI.SetActive(true);
    }
}
