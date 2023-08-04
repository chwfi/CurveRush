using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class Score : MonoBehaviour
{
	public TextMeshProUGUI scoreText;

	public bool isOn = false;
	public float time = 0f;
	public int score;
	[Tooltip("스코어의 증가율, tim * increase")]
	public float increase = 1f;

	private void Update()
	{
		if (isOn)
		{
			time += Time.deltaTime;
			score = (int)Mathf.Floor(time * increase);
			scoreText.text = score.ToString();
			GameManager.instance.score = score;
		}
	}

    public void SetTrue()
	{
		scoreText.DOFade(0.25f, 4f);
	}

	public void Bonus()
    {
		Invoke("PlusScore", 1.1f);
    }

	public void DoubleBonus()
	{
		Invoke("PlusDoubleScore", 1.1f);
	}

	public void PlusScore()
    {
		time++;
	}

	public void PlusDoubleScore()
	{
		time += 2;
	}

	public void Initialize()
	{
		isOn = false;
		scoreText.color = new Color(0.6f, 0.6f, 0.6f, 0);
		score = 0;
		scoreText.text = score.ToString();
	}

	public void StartScoring()
	{
		isOn = true;
		time = 0;
	}

	public void StopScoring()
	{
		isOn = false;
	}
}
