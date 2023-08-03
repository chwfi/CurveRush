using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;

    public void OnPanel()
    {
        _shopPanel.SetActive(true);
    }

    public void OffPanel()
    {
        _shopPanel.SetActive(false);
    }
}
