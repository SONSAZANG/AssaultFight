using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using UnityEngine.Networking;
using Newtonsoft.Json;

#region 공통구조체
public class packet
{
    public int cmd;
}
#endregion

//로그인 시 응답 객체
public class res_sign : packet
{
    public int errorno;
}

//로그인 시 전송하는 객체
public class req_sign : packet
{
    public string uid;
}

//회원가입 시 응답 객체
public class res_join : packet
{
    public int errorno;
}

//회원가입시 전송하는 객체
public class req_join : packet
{
    public string uid;
    public string nickname;
}

public class App : MonoBehaviour
{
    public GameObject signinGo;
    public GameObject joinGo;
    public Text txtUID;
    public Text txtNickName;
    public Text txtSuccessLogin;
    public Button btn;
    public Button btnSubmit; //서버전송
    public InputField inputField;

    public Button btnSignin;
    public InputField signinInputField;

    private string uid;


    // Start is called before the first frame update
    void Start()
    {
        //서버에 요청 (device의 uid 등록여부 확인)

        this.Init();



        //버튼 이벤트 등록
        this.btn.onClick.AddListener(() =>
        {
            if (string.IsNullOrEmpty(this.inputField.text))
            {
                Debug.Log("닉네임을 입력해주세요.");
            }
            else
            {
                this.txtNickName.text = this.inputField.text;

                this.inputField.gameObject.SetActive(false);
                this.btn.gameObject.SetActive(false);
                this.txtNickName.gameObject.SetActive(true);
                this.btnSubmit.gameObject.SetActive(true);
            }
        });
        this.btnSignin.onClick.AddListener(() =>
        {
            Debug.Log("로그인 버튼누름");
            this.SignIn((success) =>
            {
                if (success)
                {
                    this.txtSuccessLogin.gameObject.SetActive(true);
                }
            });
        });
        this.btnSubmit.onClick.AddListener(() =>
        {
            var reqJoin = new req_join();
            reqJoin.cmd = 1000;
            reqJoin.uid = this.txtUID.text;
            reqJoin.nickname = this.txtNickName.text;

            var json = JsonConvert.SerializeObject(reqJoin);
            Debug.Log(json);

            StartCoroutine(this.Post("api/join", json, (result) =>
            {
                //응답 
                var responseResult = JsonConvert.DeserializeObject<res_join>(result);
                Debug.Log(responseResult);
                if (responseResult.cmd == 200)
                {
                    this.joinGo.SetActive(false);
                    this.signinGo.SetActive(true);
                }
                else
                {
                    if (responseResult.errorno == 1062)
                    {
                        Debug.Log("이미 회원등록되었습니다.");
                    }
                }
            }));

        });
    }

    private void Init()
    {
        this.uid = SystemInfo.deviceUniqueIdentifier;
        this.txtUID.text = this.uid;
        this.btnSubmit.gameObject.SetActive(false);
        this.txtNickName.gameObject.SetActive(false);
        this.SignIn((success) =>
        {
            if (success == false)
            {
                this.joinGo.SetActive(true);
            }
            else
            {
                this.txtSuccessLogin.gameObject.SetActive(true);
            }
        });
    }

    private void SignIn(System.Action<bool> OnComplete)
    {
        var reqSignin = new req_sign();
        reqSignin.cmd = 1100;
        reqSignin.uid = this.uid;
        var json = JsonConvert.SerializeObject(reqSignin);

        StartCoroutine(this.Post("api/signin", json, (result) =>
        {
            //응답 
            var responseResult = JsonConvert.DeserializeObject<res_sign>(result);
            Debug.Log(responseResult);
            Debug.LogFormat("<color=red>{0}</color>", responseResult.cmd);

            if (responseResult.cmd == 200)
            {
                Debug.Log("로그인 성공");
                OnComplete(true);
            }
            if (responseResult.errorno == 9001)
            {
                Debug.Log("회원등록이 되지 않은 아이디입니다.");
                OnComplete(false);
            }
        }));
    }

    private string serverPath = "http://127.0.0.1:3000";

    private IEnumerator Post(string uri, string data, Action<string> onResponse)
    {
        var url = string.Format("{0}/{1}", this.serverPath, uri);
        Debug.Log(url);
        Debug.Log(data);

        var req = new UnityWebRequest(url, "POST");
        byte[] body = Encoding.UTF8.GetBytes(data);
        Debug.Log(body);

        req.uploadHandler = new UploadHandlerRaw(body);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        onResponse(req.downloadHandler.text);
    }
}