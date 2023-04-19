using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveLevel : Level
{
	[SerializeField]
	private List<Transform> boxes;
	[SerializeField]
	[Range(0, 10f)]
	private float posXRandomness = 0;
	[SerializeField]
	private float moveSpeed;
	[SerializeField]
	private GameObject sqaure;

    public float moveDistance = 3f; // 이동 거리
    public float switchPoint = 5f; // 방향 전환 지점

    private Vector3 originalPosition;
    private Vector3 rightPosition;
    private Vector3 leftPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
        rightPosition = originalPosition + Vector3.right * moveDistance;
        leftPosition = originalPosition - Vector3.right * moveDistance;

        MoveRight();
    }

    private void MoveRight()
    {
        sqaure.transform.DOLocalMoveX(moveDistance, moveSpeed)
            .SetEase(Ease.Linear)
            .OnComplete(MoveLeft);
    }

    private void MoveLeft()
    {
        sqaure.transform.DOLocalMoveX(-moveDistance, moveSpeed)
            .SetEase(Ease.Linear)
            .OnComplete(MoveRight);
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
