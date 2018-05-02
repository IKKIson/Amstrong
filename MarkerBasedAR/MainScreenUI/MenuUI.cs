using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //scene 관리

public class MenuUI : MonoBehaviour {

    [Header("MyCanvas")]
    public GameObject MyCanvas;

    // 메인 메뉴 화면의 오브젝트
    [Header("MainMenuPanelObject")] // Inspector 부분에 보여주기 위해 적음.
    public GameObject MainMenuPanelObj;

    // 단어공부에 있는 카테고리 선택 화면의 오브젝트
    [Header("CategoryChoiceObject")]
    public GameObject CategoryChoicePanelObj;


    // Use this for initialization
    void Start () {
        if(ScreenController.menuUI == true)
        {
            Debug.Log("MenuUI 시작~");
            
        }
        //유저 정보를 초기화 시켜준다.
        UserInfo.InitCurrentStudyCheck();
    }
	
	// Update is called once per frame
	void Update () {

	}


    ///////////////메인 메뉴 화면의 버튼///////////////

    // 단어공부 버튼을 눌렀을 시
    public void WordStudyStartBtn()
    {
        //단어공부 플래그를 true로 바꿈
        UserInfo.menuWordStudy = true;
        CategoryChoicePanelObj.SetActive(true); //카테고리 선택 화면을 보여줌.
        MainMenuPanelObj.SetActive(false); // 메뉴 화면을 없앰
    }

    //문장 만들기 버튼을 눌렀을 시
    public void MakeSentenceStartBtn()
    {
        //문장 만들기 플래그를 true로 바꿈
        UserInfo.menuMakeSentence = true;

        //웹캠으로 화면전환 한다는 것으로 설정
        ScreenController.webcam = true;
        ScreenController.loginUI = false;
        //webcamScene이라는 scene으로 화면 전환한다.
        SceneManager.LoadScene("WebCamTextureMarkerBasedARExample");
    }

    //단어 맞추기 버튼을 눌렀을 시
    public void WordMatchingStartBtn()
    {
        //단어 맞추기 플래그를 true로 바꿈
        UserInfo.menuWordMatching = true;
        //웹캠으로 화면전환 한다는 것으로 설정
        ScreenController.webcam = true;
        ScreenController.loginUI = false;
        SceneManager.LoadScene("WebCamTextureMarkerBasedARExample");
    }





    /////////단어공부 화면의 카테고리 버튼들/////////

    // 숫자 공부버튼을 눌렀을 시
    public void NumberBtn() 
    {

        UserInfo.wordStudyNumber = true;
        //웹캠으로 화면전환 한다는 것으로 설정
        ScreenController.webcam = true;
        ScreenController.loginUI = false;
        SceneManager.LoadScene("WebCamTextureMarkerBasedARExample");
    }
    // 사물 공부 버튼을 눌렀을 시
    public void ObjectBtn()
    {
        UserInfo.wordStudyObject = true;
        //웹캠으로 화면전환 한다는 것으로 설정
        ScreenController.webcam = true;
        ScreenController.loginUI = false;
        SceneManager.LoadScene("WebCamTextureMarkerBasedARExample");
    }
    // 동물 공부 버튼을 눌렀을 시
    public void AnimalBtn()
    {
        UserInfo.wordStudyAnimal = true;
        //웹캠으로 화면전환 한다는 것으로 설정
        ScreenController.webcam = true;
        ScreenController.loginUI = false;
        SceneManager.LoadScene("WebCamTextureMarkerBasedARExample");

    }
    // 인물 공부 버튼을 눌렀을 시
    public void HumanBtn()
    {
        UserInfo.wordStudyHuman = true;
        //웹캠으로 화면전환 한다는 것으로 설정
        ScreenController.webcam = true;
        ScreenController.loginUI = false;
        SceneManager.LoadScene("WebCamTextureMarkerBasedARExample");
    }
    // 시간 공부 버튼을 눌렀을 시
    public void TimeBtn()
    {
        UserInfo.wordStudyTime = true;
        //웹캠으로 화면전환 한다는 것으로 설정
        ScreenController.webcam = true;
        ScreenController.loginUI = false;
#if UNITY_5_3 || UNITY_5_3_OR_NEWER
        SceneManager.LoadScene("WebCamTextureMarkerBasedARExample");
#else
        Application.LoadLevel("webcamScene");
#endif
    }

    // TODO: 알파벳 공부 버튼은 나중에 하기


    // 메인 화면으로 가는 버튼을 눌렀을 시
    public void GotoMainMenuButton()
    {
        MainMenuPanelObj.SetActive(true); //메인 메뉴 화면을 띄우고
        CategoryChoicePanelObj.SetActive(false); //현재 화면을 없앤다
    }

}
