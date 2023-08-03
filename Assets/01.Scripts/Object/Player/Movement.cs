using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Movement : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField][Tooltip("전진 속도")]
	public float forwardSpeed;
    [SerializeField][Tooltip("좌우 이동 최대속도")]
    public float sidewardMaxSpeed;
	[SerializeField][Tooltip("가속도")]
	private float acceleration = 1f;

	[Header("Reference")]
	[SerializeField] 
	private Slider sidewardSlider;
	[SerializeField]
	private ParticleSystem deathParticle;
	[SerializeField]
	private TrailRenderer trailRenderer;
	[SerializeField]
	private CircleCollider2D coll;
	[SerializeField]
	private GameObject checker;
	[SerializeField]
	private SpriteRenderer spriteRenderer;
	[SerializeField]
	private Color originalColor = Color.white;
	[SerializeField]
	private Color changeColor;
	[SerializeField]
	private TextMeshProUGUI text;
	[SerializeField]
	private PostProcessManager processManager;

	[SerializeField]
	private CheckRisky checkRisky;

	public bool move = false;
    public Vector3 curVelocity;
	public bool isDie = false;

	[Header("Event")]
	public UnityEvent OnDie;

    private void Awake()
    {
		trailRenderer.emitting = true;
    }

	private void Update()
	{
		if (move)
		{
            if (Input.GetMouseButtonDown(0))
            {
                if (sidewardSlider.value != 0)
                {
                    sidewardSlider.value = sidewardSlider.value > 0 ? -1f : 1f;
                }
                else
                {
                    sidewardSlider.value = Camera.main.ScreenToViewportPoint(Input.mousePosition).x > 0.5f ? 1f : -1f;
                }
            }
            SidewardVelocity(sidewardSlider.value);
			Move();
		}
	}

	public void UpdateTrail()
	{
		trailRenderer.startWidth = 0.388f;
		trailRenderer.time = 2f;
	}

    public void SidewardVelocity(float input)
	{
		float addVelocity = 0;
		if (input < 0)
		{
			addVelocity = input;
		}
		else if (input > 0)
		{
			addVelocity = input;
		}
		else
		{
			addVelocity = 0;
		}
		curVelocity = new Vector3(curVelocity.x += addVelocity * Time.deltaTime * acceleration, forwardSpeed, 0);
		curVelocity = new Vector3(Mathf.Clamp(curVelocity.x, -sidewardMaxSpeed, sidewardMaxSpeed), forwardSpeed);
	}

	public void Move()
	{
		transform.Translate(curVelocity * Time.deltaTime);
	}

	public void Die()
	{
		if (!isDie)
		{
			isDie = true;
			move = false;
			trailRenderer.enabled = false;
			curVelocity = Vector3.zero;
			GetComponent<SpriteRenderer>().enabled = false;
			deathParticle.Play();
			OnDie?.Invoke();
		}
	}

	public void SetTrail()
	{
		trailRenderer.enabled = true;
	}

	public void ResetTrail()
	{
		trailRenderer.enabled = false;
	}

	public void SetTrigger()
	{
		coll.enabled = true;
		checker.SetActive(true);
	}

	public void DisableTrigger()
	{
		coll.enabled = false;
		checker.SetActive(false);
	}

	public void Active()
	{
		move = true;
		trailRenderer.enabled = true;
	}

	public void Initialize()
	{
		isDie = false;
		move = false;
		curVelocity = Vector3.zero;
		sidewardSlider.value = 0;
		transform.position = new Vector3(0, -2.5f);
		GetComponent<SpriteRenderer>().enabled = true;
		deathParticle.Clear();
	}

	private Coroutine blinkCoroutine;

	public void ReSpawn()
	{
		isDie = false;
		move = true;
		Invoke("ActiveCollider", 3f);
		trailRenderer.enabled = true;
		blinkCoroutine = StartCoroutine(BlinkCoroutine());
		Vector3 temp = transform.position;
		temp.x = 0;
		transform.position = temp;
		sidewardSlider.value = 0;
		GetComponent<SpriteRenderer>().enabled = true;
		deathParticle.Clear();
	}

	IEnumerator BlinkCoroutine()
	{
		float interval = 0.5f;
		float duration = 3f;
		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			spriteRenderer.color = changeColor;
			trailRenderer.startColor = changeColor;
			trailRenderer.endColor = changeColor;

			yield return new WaitForSecondsRealtime(interval);

			spriteRenderer.color = originalColor;
			trailRenderer.startColor = originalColor;
			trailRenderer.endColor = originalColor;

			yield return new WaitForSecondsRealtime(interval);

			elapsedTime += interval * 2;
		}
		StopCoroutine(blinkCoroutine);

		spriteRenderer.color = originalColor;
		trailRenderer.startColor = originalColor;
		trailRenderer.endColor = originalColor;
	}

	public void ActiveCollider()
    {
		coll.enabled = true;
		checker.SetActive(true);
		if (transform.position.x < -3 || transform.position.x > 3)
			GameManager.instance?.StopGame();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag != "Checker")
        {
			if (collision.CompareTag("Obstacle") || collision.CompareTag("MainCamera")) GameManager.instance?.StopGame();
			else if (collision.CompareTag("ObstacleEnd"))
            {
				GameManager.instance.IsTutorialEnd = true;
				GameManager.instance?.StopGame();
			}
		}
			
	}
}
