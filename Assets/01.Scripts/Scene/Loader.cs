using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    private const string isFirstTimeKey = "tt";

    private void Start()
    {
        if (!PlayerPrefs.HasKey(isFirstTimeKey))
        {
            PlayerPrefs.SetInt(isFirstTimeKey, 1);
            LoadSceneController.LoadScene("Tutorial");
        }
        else
        {
            PlayerPrefs.SetInt(isFirstTimeKey, 0);
            LoadSceneController.LoadScene("Game");
        }

        PlayerPrefs.Save();
    }
}
