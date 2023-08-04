using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

	[Header("Script Reference")]
    public Movement player;
    public LevelManager lvManager;
	public Score scoreManager;
	public SoundManager soundManager;
	public StartUI startUI;
	public CircleTimer circleTimer;
	public PostProcessManager postProcess;
	public StartTouchUI touchUI;
	public CameraMove cameraMove;

	[Header("Components")]
	public int respawnCount = 0;
	[SerializeField]
	private TextMeshProUGUI gameoverScoreText;
	[SerializeField]
	private TextMeshProUGUI informBestScore;
	[SerializeField]
	private GameObject restartButton;
	[SerializeField]
	private GameObject homeButton;
	[SerializeField]
	private AudioSource lobbySound;

	[Header("Score")]
	public int score;
	public int bestScore;
	public string HIGH_SCORE_KEY = "high_score";
	public TextMeshProUGUI bestScoreText;

	public UnityEvent OnStart;
	public UnityEvent OnStop;
	public UnityEvent OnInitialize;
	public UnityEvent OnRespawn;

	public bool IsTutorial;
	public bool IsTutorialEnd;

	private void Awake()
	{
		Application.targetFrameRate = 60;

		if (instance != null)
		{
			Debug.LogError("다중 게임매니저 활성화");
		}
		else
		{
			instance = this;
		}

		if (PlayerPrefs.HasKey(HIGH_SCORE_KEY))
		{
			bestScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY);
		}

		soundManager = FindObjectOfType<SoundManager>();
	}

	private void Start()
	{
		if (!IsTutorial) InitializeGame();
		//bestScore = PlayerPrefs.GetInt("BestScore", 0);
	}

    public void StartGame()
	{
		if (!IsTutorial)
		{
			scoreManager.SetTrue();
		}
		respawnCount = 0;
		startUI.DisableTouchUI();
		informBestScore.gameObject.SetActive(false);
		gameoverScoreText.color = new Color(1, 1, 1, 1f);
		player?.Active();
		player?.SetTrigger();
		player?.SetTrail();
		player.UpdateTrail();
		lvManager?.Active();
		scoreManager?.StartScoring();
		postProcess.SetGame();
		OnStart?.Invoke();
	}

	public void StopGame()
	{
		Handheld.Vibrate();
		cameraMove.canMoveCam = false;
		player?.Die();
		soundManager.PlayExplosion();
		scoreManager.scoreText.DOFade(0, 2f);
		gameoverScoreText.text = score.ToString();
		if (respawnCount < 1 && score > 15 && !IsTutorial)
        {
			circleTimer.gameObject.SetActive(true);
			restartButton.SetActive(false);
			homeButton.SetActive(false);
			respawnCount++;
		}
        else
        {
			if (!IsTutorial) circleTimer.gameObject.SetActive(false);
			restartButton.SetActive(true);
			homeButton.SetActive(true);
		}
		lvManager?.StopMove();
		player?.DisableTrigger();
		scoreManager?.StopScoring();
		player.UpdateTrail();
		OnStop?.Invoke();
		player?.ResetTrail();
		if (score > bestScore)
		{
			bestScore = score;
			RenewalScore();
			informBestScore.gameObject.SetActive(true);
			Sequence seq = DOTween.Sequence();
			for (int i = 0; i < 100; i++)
			{
				seq.Append(informBestScore.transform.DOScale(1.2f, 0.9f));
				seq.Append(informBestScore.transform.DOScale(1f, 0.9f));
			}
		}
	}

	public void InitializeGame()
	{			
		player?.Initialize();
		soundManager.count = 0;
		respawnCount = 0;
		lvManager?.Initialize();
		player?.SetTrigger();
		player?.ResetTrail();
		scoreManager?.Initialize();
		//soundManager?.StopBackgroundSong();
		informBestScore.gameObject.SetActive(false);
		gameoverScoreText.color = new Color(1, 1, 1, 1f);
		scoreManager.scoreText.color = new Color(0.6f, 0.6f, 0.6f, 0f);
		player.UpdateTrail();
		startUI?.AbleStartUI();
		postProcess.SetStart();
		OnInitialize?.Invoke();
	}

	public void Restart()
    {
		player?.Initialize();
		lvManager?.Initialize();
		scoreManager?.Initialize();
		startUI.SetTouchUI();
		gameoverScoreText.color = new Color(1, 1, 1, 1f);
		scoreManager.scoreText.color = new Color(0.6f, 0.6f, 0.6f, 0.25f);
		soundManager?.StopBackgroundSong();
		player?.SetTrigger();
		player?.ResetTrail();
		OnInitialize?.Invoke();
	}

	public void ReSpawn()
    {
		player?.ReSpawn();
		lvManager?.Active();
		scoreManager.scoreText.color = new Color(0.6f, 0.6f, 0.6f, 0.25f);
		scoreManager.isOn = true;
		OnRespawn?.Invoke();
    }

	public void RenewalScore()
    {
		bestScore = score;
		PlayerPrefs.SetInt(HIGH_SCORE_KEY, bestScore);
	}

    private void Update()
    {
		bestScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY);
		bestScoreText.text = bestScore.ToString(); // UI에 Best Score 값을 표시합니다.
	}

    public void Quit()
    {
		Application.Quit();
    }
}
