using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    private const string isFirstTimeKey = "IsFirstTimePlay";

    private void Start()
    {
        if (!PlayerPrefs.HasKey(isFirstTimeKey))
        {
            PlayerPrefs.SetInt(isFirstTimeKey, 1);
            // ���⿡ Ʃ�丮���� ���� ������ �߰��ϸ� �˴ϴ�.
            Debug.Log("ó�� �÷����ϴ� �����Դϴ�. Ʃ�丮���� ���ϴ�.");
        }
        else
        {
            PlayerPrefs.SetInt(isFirstTimeKey, 0);
            LoadSceneController.LoadScene("Game");
        }

        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
