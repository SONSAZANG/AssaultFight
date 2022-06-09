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
    /// 입력한 숫자의 씬 로딩
    /// </summary>
    /// <param name="num"></param>
    public void SceneChanger(int num)
    {
        SceneManager.LoadScene(num);
    }

    /// <summary>
    /// 랭킹 조회
    /// </summary>
    public void ShowRank()
    {
        Debug.Log("Show Rank");
        // 랭킹 조회
    }
}
