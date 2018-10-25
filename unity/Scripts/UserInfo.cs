using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// User 정보
public class UserInfo {

    public static string email;
    public static string password;

    public static bool[] wordAnimal = new bool[26]; // 0 category
    public static bool[] wordObject = new bool[26]; // 1 category
    public static bool[] wordMatching = new bool[26]; // 2 category
    public static bool[] sentenceMatching = new bool[26]; // 3 category
}

//현재 어떤 카테고리를 선택한것인지.
public class CheckCategory
{
    public static bool[] category = new bool[4];
    public static void InitCheckCategory()
    {
        category[0] = category[1] = category[2] = category[3] = false;
    }
    public static void StartCategory(string categoryName)
    {
        
        //const string GetUserCardInfoUrl = "http://gkagm2.dothome.co.kr/connectProgram/cardDatabase/getcard.php";
        //WWWForm form = new WWWForm();
        //form.AddField("user_email", UserInfo.email);
        //WWW webRequest = new WWW(GetUserCardInfoUrl, form);
        //string wow = webRequest.text;
        


        if (categoryName == "WordAnimal")
        {
            category[0] = true;
        } else if (categoryName == "WordObject")
        {
            category[1] = true;
        } else if (categoryName == "WordMatching")
        {
            category[2] = true;
        } else if (categoryName == "MakeSentence")
        {
            category[3] = true;
        }
    }
    public static int GetCheckedCategory()
    {
        int categoryNum = -1; //-1이면 아무것도 선택안함.
        if(category[0] == true)
        {
            categoryNum = 0;
        } else if(category[1] == true)
        {
            categoryNum = 1;
        } else if(category[2] == true)
        {
            categoryNum = 2;
        }
        else if(category[3] == true)
        {
            categoryNum = 3;
        }
        return categoryNum;
    }
}