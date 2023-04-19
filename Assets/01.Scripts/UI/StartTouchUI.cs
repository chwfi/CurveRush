using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTouchUI : MonoBehaviour
{
    [SerializeField]
    private Image touchUI;

    [SerializeField]
    private Movement player;

    private void Update()
    {
    }

    private void Start()
    {
        touchUI.gameObject.SetActive(false);
    }

    public void SetTrueUI()
    {
        touchUI.gameObject.SetActive(true);
    }

    public void SetFalseUI()
    {
        touchUI.gameObject.SetActive(false);
    }
}
