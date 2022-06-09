using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoSingleton<GameManager>
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �Է��� ������ �� �ε�
    /// </summary>
    /// <param name="num"></param>
    public void SceneChanger(int num)
    {
        SceneManager.LoadScene(num);
    }

    /// <summary>
    /// ��ŷ ��ȸ
    /// </summary>
    public void ShowRank()
    {
        Debug.Log("Show Rank");
        // ��ŷ ��ȸ
    }
}
