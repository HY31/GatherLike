using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CautionPanel : MonoBehaviour
{
    [SerializeField] private GameObject cautionPanel;
    public void DisplayCautionPanel()
    {
        string savedNickname = PlayerPrefs.GetString("Nickname");

        if (string.IsNullOrEmpty(savedNickname))
        cautionPanel.SetActive(true);
    }

    public void CloseCautionPanel()
    {
        cautionPanel.SetActive(false);
    }
}
