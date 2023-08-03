using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    public Transform Target;
	[SerializeField]
	private Vector3 offset;

    public bool canMoveCam = true;

	private void Awake()
	{
		Target = GameManager.instance.player.transform;
		canMoveCam = true;
	}

	private void LateUpdate()
	{
		if (canMoveCam)
			transform.position = new Vector3(0, Target.position.y, -10) + offset;
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
