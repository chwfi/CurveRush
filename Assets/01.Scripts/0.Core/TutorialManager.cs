using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private Movement _player;
    [SerializeField] private LevelManager _lvManager;
    [SerializeField] private Score _score;

    [Header("UI")]
    [SerializeField] private CanvasGroup _touchUI;
    [SerializeField] private CanvasGroup[] _infoUI;

    public bool onStart = true;

    private void Start()
    {
        _player.Active();
        _player.sidewardMaxSpeed = 0;
        _player.forwardSpeed = 0;

        StartCoroutine(SetScore());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && onStart)
        {
            GameManager.instance.InitializeGame();
            GameManager.instance.StartGame();
            _player.sidewardMaxSpeed = 3f;
            _player.forwardSpeed = 3.2f;
            _touchUI.DOFade(0, 1f).OnComplete(() => _touchUI.gameObject.SetActive(false)).OnComplete(() =>
            {
                Sequence seq = DOTween.Sequence();
                seq.Append(_infoUI[0].DOFade(1, 1f));
                seq.Append(_infoUI[1].DOFade(1, 1f));
                seq.AppendInterval(4f);
                seq.Append(_infoUI[0].DOFade(0, 0.8f));
                seq.Join(_infoUI[1].DOFade(0, 0.8f).OnComplete(() => {
                    _infoUI[0].gameObject.SetActive(false);
                    _infoUI[1].gameObject.SetActive(false);
                }));
            });
            onStart = false;
        }
    }

    private IEnumerator SetScore()
    {
        yield return new WaitForSeconds(8.5f);
        _score.SetTrue();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
