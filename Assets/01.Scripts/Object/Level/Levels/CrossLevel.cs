using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CrossLevel : Level
{
	[SerializeField]
	private List<Transform> boxes;
	[SerializeField][Range(0, 10f)]
	private float posXRandomness = 0;
	[SerializeField]
	private float degreePerSecond;
	[SerializeField]
	private float moveSpeed;
	[SerializeField]
	private GameObject[] circles;

	public float rotationSpeed = 90f; // 90도/초로 회전
	private float currentRotation = 0f;

	private void Update()
    {
		currentRotation += rotationSpeed * Time.deltaTime;
		circles[0].transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
		circles[1].transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
		circles[0].transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
		circles[1].transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
	}

    public override void Initialize()
	{
		foreach (Transform tr in boxes)
		{
			tr.position = new Vector3(0, tr.position.y);
		}
	}

	public override void OnSpawn()
	{
		foreach (Transform tr in boxes)
		{
			tr.position = new Vector3(Random.Range(-posXRandomness, posXRandomness), tr.position.y);
		}
	}
}
