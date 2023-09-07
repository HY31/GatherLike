using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData; // NPC 대사 딕셔너리
    public GameObject youCanTalk;
    public Text talkBoxTxt;
    private GameObject txtBox;
    private bool isTalkable = false;
    private bool isTextBoxActive = false;

    void Awake()
    {
        txtBox = GameObject.FindGameObjectWithTag("Canvas").transform.Find("TxtBox").gameObject;
        talkBoxTxt = txtBox.transform.Find("TalkTxt").GetComponent<Text>();
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] {"안녕하세요?", "저를 부르셨나요?"});
    }

    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isTalkable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTalkable = false;
        }
    }
   
    private void Update()
    {
        int randomValue = Random.Range(0, 2);

        if (isTalkable)
        {
            youCanTalk.SetActive(true);

            if (youCanTalk == true && Input.GetKeyDown(KeyCode.F))
            {
                isTextBoxActive = !isTextBoxActive; // 토글 상태 전환

                // txtBox의 SetActive 상태를 isTextBoxActive 값으로 설정
                txtBox.SetActive(isTextBoxActive);

                if(isTextBoxActive)
                {
                    string talkText = GetTalk(1000, randomValue);
                    // Text 컴포넌트에 문자열 할당
                    talkBoxTxt.text = talkText;
                }
            }
        }
        else
        {
            youCanTalk.SetActive(false);
            txtBox.SetActive(false);
        }
    }

}
