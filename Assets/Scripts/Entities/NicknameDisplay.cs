using UnityEngine;
using UnityEngine.UI;

public class NicknameDisplay : MonoBehaviour
{
    public Text displayName; // 플레이어 닉네임을 표시할 UI 텍스트
    void Start()
    {
        // 저장된 닉네임 불러오기
        string savedNickname = PlayerPrefs.GetString("Nickname");
        if (!string.IsNullOrEmpty(savedNickname))
        {
            displayName.text = savedNickname;
        }
    }

}
