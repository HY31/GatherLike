using UnityEngine;
using UnityEngine.UI;

public class NicknameDisplay : MonoBehaviour
{
    public Text displayName; // �÷��̾� �г����� ǥ���� UI �ؽ�Ʈ
    void Start()
    {
        // ����� �г��� �ҷ�����
        string savedNickname = PlayerPrefs.GetString("Nickname");
        if (!string.IsNullOrEmpty(savedNickname))
        {
            displayName.text = savedNickname;
        }
    }

}
