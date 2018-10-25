using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour {
    protected string sceneName;
    
    public void BackBtnPress()
    {

        StartCoroutine(BackBtnPressCo()); //LoginCo 실행
        StartCoroutine(BackBtnPressDelayCo());
        CheckCategory.InitCheckCategory();    
        

    }
    IEnumerator BackBtnPressDelayCo()
    {
        yield return new WaitForSeconds(0.7f);
            SceneManager.LoadScene("MainUI");
    }

    IEnumerator BackBtnPressCo()
    {
       if(IsLogin.isLogin)
        {
            //////////// 연결되서 서버에 보내는부분은 따로 구현해야 함. /////////////
            const string categorySaveURL = "http://gkagm2.dothome.co.kr/connectProgram/cardDatabase/card.php";
            string dbName = "";
            WWWForm form = new WWWForm();

            Debug.Log("selected and return category = " + CheckCategory.GetCheckedCategory());

            if (CheckCategory.category[0] == true)
            {
                dbName = "AnimalStudyDB";

                for (int i = 0; i < 5; i++)
                {
                    string question = "q";
                    question += i;
                    Debug.Log("animal question : " + UserInfo.wordAnimal[i] + " " + question + " " + i + UserInfo.wordAnimal[i].ToString());
                    form.AddField(question, UserInfo.wordAnimal[i].ToString());
                }
            }
            else if (CheckCategory.category[1] == true)
            {
                dbName = "ObjectStudyDB";

                for (int i = 0; i < 5; i++)
                {
                    string question = "q";
                    question += i;
                    Debug.Log("wordObject question : " + UserInfo.wordObject[i] + " " + question + " " + i + UserInfo.wordObject[i].ToString());
                    form.AddField(question, UserInfo.wordObject[i].ToString());
                }
            }
            else if (CheckCategory.category[2] == true)
            {
                dbName = "WordMatchingDB";

                for (int i = 0; i < 5; i++)
                {
                    string question = "q";
                    question += i;
                    Debug.Log("WordMatchingDB question : " + UserInfo.wordMatching[i] + " " + question + " " + i + UserInfo.wordMatching[i].ToString());
                    form.AddField(question, UserInfo.wordMatching[i].ToString());
                }

            }
            else if (CheckCategory.category[3] == true)
            {
                dbName = "MakeSentenceDB";

                for (int i = 0; i < 5; i++)
                {
                    string question = "q";
                    question += i;
                    Debug.Log("MakeSentenceDB question : " + UserInfo.sentenceMatching[i] + " " + question + " " + i + UserInfo.sentenceMatching[i].ToString());
                    form.AddField(question, UserInfo.sentenceMatching[i].ToString());
                }
            }
            form.AddField("category", dbName);
            form.AddField("user_email", UserInfo.email);


            WWW webRequest2 = new WWW(categorySaveURL, form); // request 객체 생성후 웹사이트 로그인 url에 전송
            yield return webRequest2;
            Debug.Log("webRequest : " + webRequest2.text);
            if (webRequest2.text == "success")
            {
                Debug.Log("깔끔하게 저장 완료");
            }
            else
            {
                Debug.Log("실패");
            }
        }



        ///////////////////////////////////////////////
        
    }





    public void SceneMove(string sceneName)
    {
        CheckCategory.StartCategory(sceneName);
        Debug.Log("I selected scenename : " + sceneName.ToString() + "and " + CheckCategory.GetCheckedCategory());
        this.sceneName = sceneName;
        StartCoroutine(SceneMoveDelayCo());
        

    }
    IEnumerator SceneMoveDelayCo( )
    {
        yield return new WaitForSeconds(0.7f);
        
        SceneManager.LoadScene(sceneName);
    }

   


}
