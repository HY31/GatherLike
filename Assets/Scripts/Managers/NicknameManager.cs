using UnityEngine;
using UnityEngine.UI;

public class NicknameManager : MonoBehaviour
{
    public InputField nicknameInput; // UI 텍스트 필드

    NicknameDisplay nicknameDisplay;

    public void SaveNickname()
    {
        string nickname = nicknameInput.text;
        if (!string.IsNullOrEmpty(nickname))
        {
            // 닉네임 저장
            PlayerPrefs.SetString("Nickname", nickname);
            PlayerPrefs.Save();
        }
    }

    public void DataReset()
    {
        PlayerPrefs.DeleteAll();
    }
}
