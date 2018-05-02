using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDB
{
    //사물에관한 임시 DB
    public const int markerCount = 6; //마커의 개수는 6개
    public static string[] english = new string[6];
    public static string[] korean = new string[6];
    public static string[] phoneticAlpabet = new string[6];
    public static string[] relationSentence = new string[6];
    public static string[] soundPath = new string[6];
    public static string[] imagePath = new string[6];

    //생성자
    static ObjectDB()
    {
        InitDB();

        english[0] = "Computer";
        korean[0] = "컴퓨터";
        phoneticAlpabet[0] = "kəm|pju:tə(r)";
        relationSentence[0] = "남자가 컴퓨터를 들어올리고 있다 The man is lifting the computer";
        soundPath[0] = "";
        imagePath[0] = "";

        english[1] = "Cars";
        korean[1] = "자동차";
        phoneticAlpabet[1] = "kɑ:(r)";
        relationSentence[1] = "자동차는 이산화탄소를 배출한다 Cars emit carbon dioxide";
        soundPath[1] = "";
        imagePath[1] = "";

        english[2] = "Cars";
        korean[2] = "자동차";
        phoneticAlpabet[2] = "kɑ:(r)";
        relationSentence[2] = "자동차는 이산화탄소를 배출한다 Cars emit carbon dioxide";
        soundPath[2] = "";
        imagePath[2] = "";
    }
    public static void InitDB()
    {
        int i;

        for (i = 0; i < english.Length; i++)
        {
            english[i] = "";
            korean[i] = "";
            phoneticAlpabet[i] = "";
            relationSentence[i] = "";
            soundPath[i] = "";
            imagePath[i] = "";
        }

    }

    public static string GetRowInfo(int n)  //n 은 number
    {
        //TODO: 한꺼번에 리턴시키게 해놨는데 나중에 배열로 리턴시키게해야함
        string str = english[n] + korean[n] + phoneticAlpabet[n] + phoneticAlpabet[n] + relationSentence[n] + soundPath[n] + imagePath[n];
        return str;


    }
}
public class CardDatabase
{


    public void HumanDB()
    {

    }
    public void ObjectDB()
    {

    }
    public void TimeDB()
    {

    }
    public void AnimalDB()
    {

    }
    public void NumberDB()
    {

    }
}