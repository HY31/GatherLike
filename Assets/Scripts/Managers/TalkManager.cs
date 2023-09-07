using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData; // NPC ��� ��ųʸ�
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
        talkData.Add(1000, new string[] {"�ȳ��ϼ���?", "���� �θ��̳���?"});
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
                isTextBoxActive = !isTextBoxActive; // ��� ���� ��ȯ

                // txtBox�� SetActive ���¸� isTextBoxActive ������ ����
                txtBox.SetActive(isTextBoxActive);

                if(isTextBoxActive)
                {
                    string talkText = GetTalk(1000, randomValue);
                    // Text ������Ʈ�� ���ڿ� �Ҵ�
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
