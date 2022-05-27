using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSceneBtnClick()
    {
        GameManager.Instance.SceneChanger(1);
        GameManager.Instance.ShowRank();
    }
}
