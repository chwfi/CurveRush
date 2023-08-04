using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CheckRisky : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    public Movement playerMovement;

    [SerializeField]
    private Score scoreCore;
    [SerializeField]
    private SoundManager soundManager;

    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private TextMeshProUGUI plusScoreText;

    public bool canText = true;

    string[] texts = { "AMAZING!", "WOW!", "RISKY!", "NICE\nCURVE!" };

    string[] scoreTexts = { "+1", "+2" };

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        transform.position = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            if (canText)
            {
                if (soundManager.count >= 3)
                {
                    scoreCore.DoubleBonus();
                    plusScoreText.text = scoreTexts[1];
                }
                else
                {
                    scoreCore.Bonus();
                    plusScoreText.text = scoreTexts[0];
                }

                soundManager.PlayEffect();
                ActiveText();
                PlusScoreText();
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Obstacle"))
    //    {
            
    //    }
    //}

    private void ActiveText()
    {
        canText = false;

        int textRand = Random.Range(0, 4);
        text.text = texts[textRand].ToString();
        int scaleRand = Random.Range(-15, 15);
        text.gameObject.transform.localEulerAngles = new Vector3(0, 0, scaleRand);
        int posxRand = Random.Range(-300, 300);
        int posyRand = Random.Range(-475, -720);
        text.rectTransform.anchoredPosition = new Vector3(posxRand, posyRand, 0);

        Sequence mySequence1 = DOTween.Sequence();
        mySequence1.Append(text.gameObject.transform.DOScale(1, 0.4f));
        mySequence1.AppendInterval(0.8f);
        mySequence1.Append(text.gameObject.transform.DOScale(0, 0.3f));
        mySequence1.OnComplete(() =>
        {
            canText = true;
        });
    }

    private void PlusScoreText()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(plusScoreText.gameObject.transform.DOScale(1, 0.4f));
        mySequence.AppendInterval(0.8f);
        mySequence.Append(plusScoreText.gameObject.transform.DOScale(0, 0.3f));
    }
}
