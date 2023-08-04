using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeInUI : MonoBehaviour
{
	[Header("<Param>")]
	[SerializeField]
	private float showDelay = 2f;

	[Header("<Reference>")]
	[SerializeField]
	private Image fadeScreen;

    private void Start()
    {
		fadeScreen.DOFade(0, showDelay).SetEase(Ease.OutCubic);
    }
}
