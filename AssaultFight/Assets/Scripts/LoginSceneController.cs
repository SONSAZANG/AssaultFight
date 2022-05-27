using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginSceneController : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        Debug.Log("로그인 성공!!!");
        GameManager.Instance.SceneChanger(2);
    }
}
