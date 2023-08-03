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
            // 여기에 튜토리얼을 띄우는 로직을 추가하면 됩니다.
            Debug.Log("처음 플레이하는 유저입니다. 튜토리얼을 띄웁니다.");
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
