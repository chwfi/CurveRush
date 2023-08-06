using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;

    [SerializeField] private GameObject[] _lockedImages;

    public int _bestScore;

    public SpriteRenderer _rend;
    public Sprite[] Skins; 

    private void Start()
    {
        if (PlayerPrefs.HasKey(GameManager.instance.HIGH_SCORE_KEY))
        {
            _bestScore = PlayerPrefs.GetInt(GameManager.instance.HIGH_SCORE_KEY);
        }
    }

    public void OnPanel()
    {
        if (_bestScore >= 50) _lockedImages[0].SetActive(false);
        if (_bestScore >= 100) _lockedImages[1].SetActive(false);
        if (_bestScore >= 250) _lockedImages[2].SetActive(false);

        _shopPanel.SetActive(true);
    }

    public void OffPanel()
    {
        _shopPanel.SetActive(false);
    }

    public void ChangeSkin(Sprite sprite)
    {
        _rend.sprite = sprite;
    }
}
