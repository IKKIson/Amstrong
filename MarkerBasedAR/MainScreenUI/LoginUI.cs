using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //scene 관리

public class LoginUI : MonoBehaviour
{
    [Header("MyCanvas")]
    public GameObject MyCanvas;

    [Header("MyCanvas2")]
    public GameObject MyCanvas2;

    //로그인 화면의 오브젝트
    [Header("LoginPanelObject")]
    public GameObject LoginPanelObj;

    // 계정 생성 화면의 오브젝트
    [Header("CreateAccountPanelObject")]
    public GameObject CreateAccountPanelObj;

    //로그인 화면의 텍스트들
    [Header("LoginPanel")]
    public InputField IDInputField;
    public InputField PassInputField;
    public Text ShowIssueLoginText;


    //계정 생성 화면의 텍스트들
    [Header("CreateAccountPanel")]
    public InputField New_IDInputField;
    public InputField New_PassInputField;
    public InputField New_NameInputField;
    public Text ShowIssueCreateAccountText;
   


    //웹서버와 연결하기위한 정보
    private string LoginUrl;
    private string CreateAccountUrl;

    // Use this for initialization
    void Start()
    {
        if(ScreenController.loginUI == true)
        {
            MyCanvas.SetActive(true);
        }
        if (ScreenController.menuUI == true)
        {
            MyCanvas.SetActive(false);
            MyCanvas2.SetActive(true);
        }
        
        
        //웹서버와 연결하기위한 정보 초기 설정
        LoginUrl = "http://gkagm2.dothome.co.kr/connectProgram/login/login.php";
        CreateAccountUrl = "http://gkagm2.dothome.co.kr/connectProgram/createAccount/createAccount.php";


        if (Display.displays.Length > 1)
            // Activate the display 1 (second monitor connected to the system).
            Display.displays[2].Activate(0, 0, 60);
    }

    ///////////로그인 화면의 버튼들///////////

    //로그인 버튼을 누를 시
    public void LoginBtn()
    {
        StartCoroutine(LoginCo()); //LoginCo 실행

    }
    IEnumerator LoginCo()
    {
        //아이디나 비밀번호가 빈칸일 때
        if (IDInputField.text == "" || PassInputField.text == "")
        {
            ShowIssueLoginText.text = "빈칸을 채워주세요";
            yield return null;
        }
        //아이디와 비밀번호가 전부 입력되었으면
        else  
        {
            WWWForm form = new WWWForm(); //아이디와 비밀번호를 웹에 전송하기위해 WWWForm 객체 생성
            form.AddField("user_email", IDInputField.text); //text에서 받은 id와
            form.AddField("user_password", PassInputField.text); //password를 form 객체의 필드에 저장.

            WWW webRequest = new WWW(LoginUrl, form); // request 객체 생성후 웹사이트 로그인 url에 전송
            yield return webRequest;

            Debug.Log(webRequest.text);
            //성공적으로 로그인 되었으면
            if (webRequest.text == "success")
            {
                //Menu 화면으로 전환
                MyCanvas.SetActive(false);
                MyCanvas2.SetActive(true);

                //유저 정보에 아이디와 비밀번호를 저장
                UserInfo.email = IDInputField.text;
                UserInfo.password = PassInputField.text;
            }
            //로그인 실패했을 경우
            else
            {
                ShowIssueLoginText.text = "아이디 혹은 패스워드가 틀렸습니다.";
                yield return null;
            }
        }

    }

    /////////////로그인 화면에서의 버튼////////////

    //계정생성 버튼을 누를 시
    public void GotoCreateAccountBtn()
    {
        CreateAccountPanelObj.SetActive(true); //계정생성 화면을 띄우고
        LoginPanelObj.SetActive(false);//로그인 화면을 없앤다.
    }


    //////////계정생성 화면에서의 버튼////////////

    //뒤로가기 버튼을 누를 시
    public void GotoLoginPanelBtn()
    {
        LoginPanelObj.SetActive(true);//로그인 화면을 띄우고
        CreateAccountPanelObj.SetActive(false);//계정생성 화면을 없앤다.

    }
    //생성완료 버튼을 누를 시
    public void CreateAccountBtn()
    {
        StartCoroutine(CreateAccountCo()); //실행

    }
    IEnumerator CreateAccountCo()
    {
        //빈칸이 하나라도 있으면
        if (New_NameInputField.text == "" || New_PassInputField.text == "" || New_IDInputField.text == "")
        {
            ShowIssueCreateAccountText.text = "빈칸을 채워주세요.";
            yield return null;
        }
        //빈칸없이 완벽히 입력했으면
        else
        {
            WWWForm form = new WWWForm();  //새로운 계정 정보를 웹에 전송하기위해 WWWForm 객체 생성
            form.AddField("user_email", New_IDInputField.text);//아이디와
            form.AddField("user_password", New_PassInputField.text);//패스워드와
            form.AddField("user_name", New_NameInputField.text);//이름을 form 객체의 필드에 저장.

            WWW webRequest = new WWW(CreateAccountUrl, form); // request 객체 생성후 웹사이트 로그인 url에 전송
            yield return webRequest;

            //성공적으로 가입이 될 시
            if (webRequest.text == "success")
            {
                ShowIssueLoginText.text = "가입 성공"; //가입 성공 메시지를 보여주고
                LoginPanelObj.SetActive(true); //로그인 화면을 보여준다.
                CreateAccountPanelObj.SetActive(false); //계정생성 화면을 없앤다.
                IDInputField.text = New_IDInputField.text; //새로 만들었던 아이디를 로그인 화면의 text에 자동으로 만들어준다.


            }
            //동일한 아이디가 존재할 시
            else if (webRequest.text == "existId")
            {
                ShowIssueCreateAccountText.text = "아이디가 존재합니다.";
            }
        }
    }

}

public class GuiPassword : MonoBehaviour
{
    string passwordToEdit = string.Empty;
    void OnGUI()
    {
        GUI.Label(new Rect(300, 275, 100, 30), "Password");
        passwordToEdit = GUI.PasswordField(new Rect(300, 300, 200, 20), passwordToEdit, "*"[0], 25);
    }
}



public class ActionSomeThing
{
    //마커를 한번 봤으면 현재 카테고리와 현재 챕터, 마커 번호를 넘긴다.
    public string CheckMarker(string currentCategory, string currentChapter, int markerNuber)
    {
        //넘겨서 데이터베이스에 알려줘야 한다. 
        //TODO: 버퍼에 담아서 끝낼 때 한꺼번에 웹 데이터베이스에 전달해줘도 괜찮을 듯 싶다.

        string something = " ";
        return something;
    }

    // 연결해줌
    protected void TransperWebQuery()
    {
        Debug.Log("TransperWebQuery");
        //WWWForm form = new WWWForm();
        //form.AddField("", );
        //form.AddField("", );
        //WWW webRequest = new WWW(CreateAccountUrl, form); // request 
    }


}