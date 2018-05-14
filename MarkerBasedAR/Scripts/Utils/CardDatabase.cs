using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDB
{







    //사물에관한 임시 DB
    public const int markerCount = 6; //마커의 개수는 6개
    public static string[] english = new string[6]; //영어
    public static string[] korean = new string[6]; //한국어
    public static string[] partOfSpeech = new string[6]; //형태
    public static string[] phoneticAlpabet = new string[6]; //발음기호
    public static string[] relationSentenceEn = new string[6]; //영어 예시 문장
    public static string[] relationSentenceKo = new string[6]; //한국어 예시 문장

    //생성자
    static ObjectDB()
    {
        InitDB();

        english[0] = "Cars";
        korean[0] = "자동차";
        phoneticAlpabet[0] = "kɑ:(r)";
        partOfSpeech[0] = "None";
        relationSentenceEn[0] = "Cars emit carbon dioxide";
        relationSentenceKo[0] = "자동차는 이산화탄소를 배출한다";

        english[1] = "Soccer ball";
        korean[1] = "축구공";
        phoneticAlpabet[1] = "sɑ́kər bɔ:l";
        partOfSpeech[1] = "None";
        relationSentenceEn[1] = "Soccer ball is nice";
        relationSentenceKo[1] = "축구공은 멋있다";

        english[2] = "Notebook computer";
        korean[2] = "노트북";
        phoneticAlpabet[2] = "noʊtbʊk kəm|pju:tə(r)";
        partOfSpeech[2] = "None";
        relationSentenceEn[2] = "The man is lifting the Notebook computer";
        relationSentenceKo[2] = "남자가 노트북을 들어올리고 있다";

    }

    //초기화
    public static void InitDB()
    {
        int i;

        for (i = 0; i < english.Length; i++)
        {
            english[i] = "";
            korean[i] = "";
            phoneticAlpabet[i] = "";
            partOfSpeech[i] = "";
            relationSentenceKo[i] = "";
            relationSentenceEn[i] = "";

        }

    }

    //처리하기 쉽게 배열로 리턴함.
    public static string[] GetRowInfo(int n)  //n 은 number
    {
        
        //순서대로 영어 ,한국어, 발음기호, 형태, 영어문장, 한국어 문장 순.
        string[] tempIndex = new string[6];
        tempIndex[0] = english[n];
        tempIndex[1] = korean[n];
        tempIndex[2] = phoneticAlpabet[n];
        tempIndex[3] = partOfSpeech[n];
        tempIndex[4] = relationSentenceKo[n];
        tempIndex[5] = relationSentenceEn[n];
        
        return tempIndex;


    }
}
