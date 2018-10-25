using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour {
    const string LoginUrl = "http://gkagm2.dothome.co.kr/connectProgram/login/login.php";
    const string CreateAccountUrl = "http://gkagm2.dothome.co.kr/connectProgram/createAccount/createAccount.php";
    
    [Header("MainCanvas, MenuCanvas")]
    public Canvas main;
    public Canvas menu;
    [Header("로그인 ID, PW")]
    public InputField id;
    public InputField pw;

    [Header("회원가입 패널, ID, PW, NAME")]
    public GameObject MakePanel;
    public InputField mid;
    public InputField mpw;
    public InputField mname;

    [Header("팝업 패널")]
    public GameObject popup;
    Popup pu;

    void Start()
    {
        
        pu = popup.GetComponent<Popup>();
        Debug.Log(UserInfo.email);
        
    }
    void Update()
    {
        
        if (UserInfo.email != null)
            main.gameObject.SetActive(false);
        if (IsLogin.isLogin == false)
        {
            main.gameObject.SetActive(false);
        }


    }

    public void PlayAloneBtn()
    {
        IsLogin.isLogin = false;
        CheckCategory.InitCheckCategory(); //모두 false로 초기화.
        main.gameObject.SetActive(false);
    }

    public void LoginBtn()
    {
        StartCoroutine(LoginCo()); //LoginCo 실행
    }
    public void MakeAccountCreate()
    {
        StartCoroutine(CreateAccountCo()); //실행
    }
    
    public void ShowMakeAccout()
    {
        MakePanel.SetActive(true);
    } 
    public void MakeAccountCancel()
    {
        mid.text = "";
        mpw.text = "";
        mname.text = "";
        MakePanel.SetActive(false);
    }

    IEnumerator LoginCo()
    {
        //아이디나 비밀번호가 빈칸일 때
        if (id.text == "" || pw.text == "")
        { 
            pu.ShowPopUp("ID, PW를 채워주세요");
            yield return null;
        }
        //아이디와 비밀번호가 전부 입력되었으면
        else
        {
            WWWForm form = new WWWForm(); //아이디와 비밀번호를 웹에 전송하기위해 WWWForm 객체 생성
            form.AddField("user_email", id.text); //text에서 받은 id와
            form.AddField("user_password", pw.text); //password를 form 객체의 필드에 저장.

            WWW webRequest = new WWW(LoginUrl, form); // request 객체 생성후 웹사이트 로그인 url에 전송
            yield return webRequest;

            //성공적으로 로그인 되었으면
            if (webRequest.text == "success")
            {
                IsLogin.isLogin = true;
                UserInfo.email = id.text;
                UserInfo.password = pw.text;
                CheckCategory.InitCheckCategory(); //모두 false로 초기화.
            }
            //로그인 실패했을 경우
            else
            {
                pu.ShowPopUp("ID, PW를 확인해주세요");
                yield return null;
            }
        }

    }
    IEnumerator CreateAccountCo()
    {
        //빈칸이 하나라도 있으면
        if (mid.text == "" || mpw.text == "" || mname.text == "")
        {
            pu.ShowPopUp("회원가입 ID, PW, NAME을 채워주세요");
            yield return null;
        }
        //빈칸없이 완벽히 입력했으면
        else
        {
            WWWForm form = new WWWForm();  //새로운 계정 정보를 웹에 전송하기위해 WWWForm 객체 생성
            form.AddField("user_email", mid.text);//아이디와
            form.AddField("user_password", mpw.text);//패스워드와
            form.AddField("user_name", mname.text);//이름을 form 객체의 필드에 저장.

            WWW webRequest = new WWW(CreateAccountUrl, form); // request 객체 생성후 웹사이트 로그인 url에 전송
            yield return webRequest;

            //성공적으로 가입이 될 시
            if (webRequest.text == "success")
            { 
                pu.ShowPopUp("회원가입에 성공하였습니다.");
                id.text = mid.text;
                MakeAccountCancel();
                
            }
            //동일한 아이디가 존재할 시
            else if (webRequest.text == "existId")
            {
                pu.ShowPopUp("ID가 중복되었습니다");
            }
        }
    }

}

