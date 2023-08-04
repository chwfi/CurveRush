using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public void MyButtonClick()
    {
        SoundManager.Instance.ClickButtonSound();
    }

    private void Start()
    {
        Button myButton = GetComponent<Button>();

        myButton.onClick.AddListener(MyButtonClick);
    }
}
