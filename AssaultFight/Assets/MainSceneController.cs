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
    /// 씬 시작 기초 설정
    /// </summary>
    void Init()
    {
        mainPanel.SetActive(true);
        characterSelectPanel.SetActive(false);
        GameManager.Instance.ShowRank();
    }

    /// <summary>
    /// 모드 설정 버튼 1 -> AI모드 2 -> Rank모드
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
