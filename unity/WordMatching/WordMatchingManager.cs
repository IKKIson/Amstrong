using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class WordMatchingManager : MonoBehaviour {

    [Serializable]
    public class Question
    {
        public Sprite img;
        public string CorrectAnswer;
        public string AnswerText;
    }


    [Header("문제")]
    public Question[] WordQuestion;
    public string currentAnswer;
    public int AnswerNum;
    [Header("인식시간")]
    public float RecognizeTime;
    public Text answertitle;
    public Image img;
    public Text text;
    public Text result;
    bool CorrcectAnswer;
    GameObject EnableArObject;    
    float timer;
	// Use this for initialization
	void Start () {
        AnswerNum = -1;
        NextAnswer();
	}
	
	// Update is called once per frame
	void Update () {
        if (!CorrcectAnswer)
        {
            FindEnableObject();
            RecognizeObject();
            InputWord();
            MatchingAnswer();
            ShowAnswerToText();
        }
	}

    void FindEnableObject()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Marker");
        if(objs.Length >= 2)
        {  
            result.text = "카드를 한장씩 인식시켜주세요";
        }
        else if (objs.Length == 1 && EnableArObject == null)
        {
            EnableArObject = objs[0];
            result.text = EnableArObject.GetComponent<WordMatchingObject>().GetWord.ToString();
            Debug.Log("result tesxt :" + result.text);
        }
        else if (objs.Length == 0)
        {
            EnableArObject = null;
            timer = 0f;
            result.text = "";
        }
    }
    void RecognizeObject()
    {
        if(EnableArObject != null)
            timer += Time.deltaTime;
    }
    void InputWord()
    {
        if (timer > RecognizeTime)
        {
            string str = "";
            bool once = true;
            for (int i = 0; i < currentAnswer.Length; i++)
            { 
                if (once && currentAnswer[i] == '_')
                {
                    str += EnableArObject.GetComponent<WordMatchingObject>().GetWord;
                    once = !once;
                    continue;
                } 
                str += currentAnswer[i];
            }
            currentAnswer = str;
            timer = 0;
            EnableArObject = null;
        }
    }

    void MatchingAnswer()
    {
        string str="";
        for (int i = 0; i < currentAnswer.Length; i++)
        {
            if (currentAnswer[i] != '_' && currentAnswer[i] != ' ')
            {
                str += currentAnswer[i];
            }
        }
        if (WordQuestion[AnswerNum].CorrectAnswer.Length == str.Length)
        {
            if (WordQuestion[AnswerNum].CorrectAnswer == str)
            {
                Debug.Log("정답");
                CorrcectAnswer = true;
                result.text = "정답입니다!";
                UserInfo.wordMatching[AnswerNum] = true;
                Invoke("NextAnswer", 2.0f);
            }
            else
            {
                result.text = "오답입니다...";
                Invoke("ClearAnswer", 2.0f);
            }
        }
    }
    void NextAnswer()
    {
        if (AnswerNum + 1 < WordQuestion.Length && UserInfo.wordMatching.Length >= WordQuestion.Length)
        {
            CorrcectAnswer = false; 
            AnswerNum++;
            img.sprite = WordQuestion[AnswerNum].img;
            answertitle.text = "문제" + (AnswerNum + 1).ToString() + " : " + WordQuestion[AnswerNum].AnswerText;
            ClearAnswer();
        }
    }
    void ShowAnswerToText()
    {
        text.text = currentAnswer;
    }
    public void ClearAnswer()
    {
        string str = "";
        for (int i = 0; i < WordQuestion[AnswerNum].CorrectAnswer.Length; i++)
        {
            if (i == WordQuestion[AnswerNum].CorrectAnswer.Length - 1)
            {
                str += "_";
                break;
            }
            str += "_ ";
        }

        currentAnswer = str;
    }

    public void PrevAnswerBtn()
    {
        if (AnswerNum - 1 >= 0)
        {
            CorrcectAnswer = false;
            AnswerNum--;
            img.sprite = WordQuestion[AnswerNum].img;
            answertitle.text = "문제" + (AnswerNum + 1).ToString() + " : " + WordQuestion[AnswerNum].AnswerText;
            ClearAnswer();
        }
    }
    public void NextAnswerBtn()
    {
        if (AnswerNum + 1 < WordQuestion.Length && UserInfo.wordMatching.Length >= WordQuestion.Length)
        {
            CorrcectAnswer = false;
            AnswerNum++;
            img.sprite = WordQuestion[AnswerNum].img;
            answertitle.text = "문제" + (AnswerNum + 1).ToString() + " : " + WordQuestion[AnswerNum].AnswerText;
            ClearAnswer();
        }
    }
}
