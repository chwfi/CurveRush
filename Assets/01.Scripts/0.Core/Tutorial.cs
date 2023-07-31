using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private const string isFirstTimeKey = "IsFirstTimePlay";

    private void Awake()
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
            Debug.Log("�̹� �÷����� �����Դϴ�. Ʃ�丮���� �����մϴ�.");
        }

        PlayerPrefs.Save();
    }
}
