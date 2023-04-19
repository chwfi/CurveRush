using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevel : Level
{
	[SerializeField]
	private List<Transform> boxes;
	[SerializeField][Range(0, 10f)]
	private float posXRandomness = 0;
	[SerializeField]
	private float degreePerSecond;
	[SerializeField]
	private GameObject square;

    private void Update()
    {
		//transform.Rotate(Vector2.up * Time.deltaTime * degreePerSecond);
		//transform.Rotate(0, 0, -Time.deltaTime * degreePerSecond, Space.Self);
		square.transform.Rotate(0, 0, -Time.deltaTime * degreePerSecond, Space.Self);
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
