using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeToMainScene()
    {
        string savedNickname = PlayerPrefs.GetString("Nickname");

        if (!string.IsNullOrEmpty(savedNickname))
            SceneManager.LoadScene("MainScene");
    }
}
