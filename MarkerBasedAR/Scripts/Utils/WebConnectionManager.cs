using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WebConnectionManager : MonoBehaviour {
    
    protected string url;
    protected string selectMenu;
    public static WebConnectionManager instance = null;
    // Use this for initialization
    void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //소멸되지않게 하기
        DontDestroyOnLoad(gameObject);
        GetObjectDB();
    }

	// Update is called once per frame
	void Update () {
		
	}


    //Object database 불러오기
    public void GetObjectDB()
    {
        StartCoroutine(GetObjectDBCo());
    }
    IEnumerator GetObjectDBCo()
    {
        WWWForm form = new WWWForm();
        selectMenu = UserInfo.CheckCurrentChoicedMenu(); //현재 선택한 메뉴에대해서 불러울 DB table이름을 가져온다.

        form.AddField("menu", selectMenu);  



        url = "http://gkagm2.dothome.co.kr/connectProgram/cardDatabase/objectDB.php";
        WWW webRequest = new WWW(url, form); // request 객체 생성후 웹사이트 로그인 url에 전송
        yield return webRequest;
        Debug.Log("데이터베이스 가져오기 예지 :" + webRequest.text);
    }

    //Animal databse 불러오기
    //public void GetAnimalDB()
    //{

    //}
}
