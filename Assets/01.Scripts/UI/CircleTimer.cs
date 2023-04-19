using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CircleTimer : MonoBehaviour
{
    public float time;
    public Image fill;
    public float max;

    public Image Timer;
    public Image Ad;

    public TextMeshProUGUI bestScoreText;
    public GameObject _bestScoreText;

    [SerializeField]
    private GameObject background;
    [SerializeField]
    private GameObject fadeScreen;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI bestScore;
    [SerializeField]
    private Image crown;
    [SerializeField]
    private TextMeshProUGUI inform;

    [SerializeField]
    private FrontAd frontAd;
    [SerializeField]
    private AdTimer adTimer;

    private void OnEnable()
    {
        Ad.color = new Color(1, 1, 1, 1);
        time = max;
        Sequence seq1 = DOTween.Sequence();
        for (int i = 0; i < 10; i++)
        {
            seq1.Append(Ad.transform.DOScale(1.2f, 0.75f));
            seq1.Append(Ad.transform.DOScale(1f, 0.75f));
        }
    }

    public void ShowBestText()
    {
        bestScoreText.DOFade(1, 0.75f);
        Sequence seq = DOTween.Sequence();
        for (int i = 0; i < 100; i++)
        {
            seq.Append(_bestScoreText.transform.DOScale(1.2f, 1f));
            seq.Append(_bestScoreText.transform.DOScale(1f, 1f));
        }
    }

    private void Update()
    {
        time -= Time.deltaTime;
        fill.fillAmount = time / max;

        if (time < 0)
        {
            if (adTimer.canAd)
            {
                if (Application.internetReachability == NetworkReachability.NotReachable)
                {
                    adTimer.canAd = false;
                    adTimer.canTime = true;
                }
                else
                {
                    frontAd.ShowAd();
                    adTimer.canAd = false;
                    adTimer.canTime = true;
                }
            }
            time = 0;
            Timer.DOFade(0, 0.75f);
            scoreText.DOFade(0, 0.75f);
            Ad.DOFade(0, 0.75f);
            //bestScore.DOFade(0, 0.75f);
            //inform.DOFade(0, 0.75f);
            //crown.DOFade(0, 0.75f);
            Invoke("DestroyObj", 0.75f);
        }
        else
        {
            bestScore.color = new Color(1, 1, 1, 1);
            inform.color = new Color(1, 1, 1, 1);
            crown.color = new Color(1, 1, 1, 1);
        }
    }

    private void DestroyObj()
    {
        GameManager.instance.InitializeGame();
        background.gameObject.SetActive(false);
        fadeScreen.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
