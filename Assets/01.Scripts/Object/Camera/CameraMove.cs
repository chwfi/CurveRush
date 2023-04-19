using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform target;
	[SerializeField]
	private Vector3 offset;

    public bool canMoveCam = true;

	private void Awake()
	{
		canMoveCam = true;
	}

	private void LateUpdate()
	{
		if (canMoveCam)
			transform.position = new Vector3(0, target.position.y, -10) + offset;
		else
			transform.DOShakePosition(0.1f, 0.05f).OnComplete(() =>
			{
				Invoke("StopShake", 0.09f);
			});
	}

	public void StopShake()
    {
		canMoveCam = true;
    }
}
