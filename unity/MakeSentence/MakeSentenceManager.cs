using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeSentenceManager : MonoBehaviour
{
    [Serializable]
    public class Question
    {
        public string Problem;
        public string CorrectAnswer;
    }
    public GameObject[] MarkerObjects;
    [Header("문제")]
    public Question[] SentenceQuestion;
    public string currentAnswer;
    public int AnswerNum; 
    //Manager;
    GameObject[] obj;
    public Text answertitle;
    public Text Problem;
    public Text Answer;
    public Text Result;

    public float Distance;

    bool CorrcectAnswer;
    // Use this for initialization
    void Start()
    { 
        AnswerNum = -1;
        NextAnswer(); 
    }

    // Update is called once per frame
    void Update()
    {
        //if (!CorrcectAnswer)
        //{
        //    MakeSentence();
        //    MatchingAnswer();
        //}


        ////test
        //GameObject[] Markers;
        //Markers = GameObject.FindGameObjectsWithTag("Marker");
        //if (Markers.Length > 1)
        //{
        //    Debug.Log("거리 : " + Vector3.Distance(Markers[0].transform.position, Markers[1].transform.position));
        //}
        if (!CorrcectAnswer)
        {
            Merge();
            MakeSentence();
            MatchingAnswer();
        }
    }

    void Merge()
    { 
        GameObject[] Markers;
        List<GameObject> objlist = new List<GameObject>(); 
        List<GameObject> sortList = new List<GameObject>();
        Markers = GameObject.FindGameObjectsWithTag("Marker"); 
        currentAnswer = "";
        //정렬
        for (int i = 0; i < Markers.Length; i++)
        {
            objlist.Add(Markers[i]);
            Markers[i].transform.GetChild(4).GetComponent<TextMesh>().text = Markers[i].GetComponent<SentenceObject>().str;
        }
        
        while (objlist.Count >= 1)
        {
            GameObject temp = null;
            for (int i = 0; i < objlist.Count; i++)
            {
                if (temp == null || objlist[i].transform.position.x < temp.transform.position.x)
                {
                    temp = objlist[i];
                }
            }
            sortList.Add(temp);
            objlist.Remove(temp);
        }
        //
        //변수 동적생성
        if (sortList.Count > 1)
        {
            bool[] checkMerge = new bool[sortList.Count - 1];

            //두 객체간 거리 체크
            for (int i = 0; i < sortList.Count - 1; i++)
            {
                Debug.Log("Dinstance : " + Vector3.Distance(sortList[i].transform.position, sortList[i+1].transform.position));
                if (Vector3.Distance(sortList[i].transform.position, sortList[i+1].transform.position) < Distance)
                {
                    checkMerge[i] = true;
                }
                else
                {
                    checkMerge[i] = false;
                }
            }

            for (int i = checkMerge.Length - 1; i >= 0; i--)
            {
                if (checkMerge[i])
                {
                    sortList[i].transform.GetChild(4).GetComponent<TextMesh>().text = sortList[i].transform.GetChild(4).GetComponent<TextMesh>().text + " " + sortList[i + 1].transform.GetChild(4).GetComponent<TextMesh>().text;
                    sortList[i + 1].transform.GetChild(4).GetComponent<TextMesh>().text = "";
                }
            }

            for (int i = 0; i < checkMerge.Length; i++)
            { 
                if (checkMerge[i] == false) //인식된 모든 마커가 Merge가 되어있지 않을경우 반환
                    return;
            }

            for (int i = 0; i < sortList.Count; i++)
            {
                currentAnswer += sortList[i].GetComponent<SentenceObject>().str;
                if(i < sortList.Count-1)
                    currentAnswer += "/";       //답 제작
            }
            
        }

    }

    void MakeSentence() //UI 띄워지는 용도
    { 
        List<GameObject> objlist = new List<GameObject>();
        string str = "";
        obj = GameObject.FindGameObjectsWithTag("Marker"); 
        

        for (int i = 0; i < obj.Length; i++)
            objlist.Add(obj[i]);

        while (objlist.Count >= 1)
        {
            GameObject temp = null;
            for (int i = 0; i < objlist.Count; i++)
            {
                if (temp == null || objlist[i].transform.position.x < temp.transform.position.x)
                {
                    temp = objlist[i];
                }
            }
            str += temp.GetComponent<SentenceObject>().str + " ";
            objlist.Remove(temp);
        }

        Answer.text = str;
        //currentAnswer = str;
        Result.text = "";
    }
    void MatchingAnswer()
    { 
        if (currentAnswer == SentenceQuestion[AnswerNum].CorrectAnswer)
        {
            //정답입니다 
            CorrcectAnswer = true;
            Result.text = "정답입니다!";
            UserInfo.sentenceMatching[AnswerNum] = true;
            Invoke("NextAnswer", 2.0f);
        }
        else
        {
            if (currentAnswer != "")
            {
                //오답입니다! 
                Result.text = "오답입니다!";
            }
        }
    }
    void NextAnswer()
    {
        if (AnswerNum + 1 < SentenceQuestion.Length && UserInfo.sentenceMatching.Length >= SentenceQuestion.Length)
        { 
            CorrcectAnswer = false;
            AnswerNum++;
            //
            string[] str = SentenceQuestion[AnswerNum].CorrectAnswer.Split('/');

            //
            int[] n = new int[str.Length];
            for( int i=0; i < n.Length; ++i )
                n[i] = i; 
            for( int i=0; i < n.Length; ++i )
            {
                int dest = UnityEngine.Random.Range(0, n.Length);
 
                int temp = n[i];
                n[i] = n[dest];
                n[dest] = temp;
            }
            //
            for (int i = 0; i < str.Length; i++)
            {
                MarkerObjects[i].GetComponent<SentenceObject>().str = str[n[i]];
            }
            //
            answertitle.text = "문제 " + (AnswerNum + 1).ToString() + "번";
            Problem.text = SentenceQuestion[AnswerNum].Problem;  
        }
    }
    public void PrevAnswerBtn()
    {
        if (AnswerNum - 1 >= 0)
        {
            CorrcectAnswer = false;
            AnswerNum--;
            //
            string[] str = SentenceQuestion[AnswerNum].CorrectAnswer.Split('/');

            //
            int[] n = new int[str.Length];
            for (int i = 0; i < n.Length; ++i)
                n[i] = i;
            for (int i = 0; i < n.Length; ++i)
            {
                int dest = UnityEngine.Random.Range(0, n.Length);

                int temp = n[i];
                n[i] = n[dest];
                n[dest] = temp;
            }
            //
            for (int i = 0; i < str.Length; i++)
            {
                MarkerObjects[i].GetComponent<SentenceObject>().str = str[n[i]];
            }
            //
            answertitle.text = "문제 " + (AnswerNum + 1).ToString() + "번";
            Problem.text = SentenceQuestion[AnswerNum].Problem;
        }
    }
    public void NextAnswerBtn()
    {
        if (AnswerNum + 1 < SentenceQuestion.Length && UserInfo.sentenceMatching.Length >= SentenceQuestion.Length)
        {
            CorrcectAnswer = false;
            AnswerNum++;
            //
            string[] str = SentenceQuestion[AnswerNum].CorrectAnswer.Split('/');

            //
            int[] n = new int[str.Length];
            for (int i = 0; i < n.Length; ++i)
                n[i] = i;
            for (int i = 0; i < n.Length; ++i)
            {
                int dest = UnityEngine.Random.Range(0, n.Length);

                int temp = n[i];
                n[i] = n[dest];
                n[dest] = temp;
            }
            //
            for (int i = 0; i < str.Length; i++)
            {
                MarkerObjects[i].GetComponent<SentenceObject>().str = str[n[i]];
            }
            //
            answertitle.text = "문제 " + (AnswerNum + 1).ToString() + "번";
            Problem.text = SentenceQuestion[AnswerNum].Problem;
        }
    }
}
