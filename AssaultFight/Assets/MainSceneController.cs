using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    [Header("MainPanel")]
    [SerializeField] GameObject mainPanel;
        
    [Header("CharacterSelectPanel")]
    [SerializeField] GameObject characterSelectPanel;
    [SerializeField] Text modeInfoText;
   

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// �� ���� ���� ����
    /// </summary>
    void Init()
    {
        mainPanel.SetActive(true);
        characterSelectPanel.SetActive(false);
        GameManager.Instance.ShowRank();
    }

    /// <summary>
    /// ��� ���� ��ư 1 -> AI��� 2 -> Rank���
    /// </summary>
    /// <param name="num"></param>
    public void ModeSelectBtnClick(int num)
    {
        mainPanel.SetActive(false);
        characterSelectPanel.SetActive(true);
        switch(num)
        {
            case 0:
                modeInfoText.text = "AI MODE";
                Debug.Log("AI Mode Select");
                break;
            case 1:
                modeInfoText.text = "RANK MODE";
                Debug.Log("Rank Mode Select");
                break;
        }
    }

    public void SelectCharacterBtnClick(int num)
    {

    }

    public void ReturnBtnClick()
    {
        characterSelectPanel.SetActive(false);
        mainPanel.SetActive(true);
        GameManager.Instance.ShowRank();
    }
}
