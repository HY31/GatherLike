using UnityEngine;
using UnityEngine.UI;

public class NicknameManager : MonoBehaviour
{
    public InputField nicknameInput; // UI �ؽ�Ʈ �ʵ�

    NicknameDisplay nicknameDisplay;

    public void SaveNickname()
    {
        string nickname = nicknameInput.text;
        if (!string.IsNullOrEmpty(nickname))
        {
            // �г��� ����
            PlayerPrefs.SetString("Nickname", nickname);
            PlayerPrefs.Save();
        }
    }

    public void DataReset()
    {
        PlayerPrefs.DeleteAll();
    }
}
