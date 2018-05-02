using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 유저의 정보를 담는 클래스
/// </summary>
public class UserInfo {

    // user 정보를 넣을 값.
    public static string email; //이메일 (ID)
    public static string password;  // 패스워드
    public static string name; // 이름
    


    
    /////// 현재 공부하고있는지 구분하기위한 flags ////////
    
    ////////아래에 있는 값들은 UI에서 해당 카테고리나 리스트 선택 시 선택 했다고 표시하는 flag임////////
    // 메뉴 프로그램 종류
    public static bool menuWordStudy ; // 단어공부
    public static bool menuWordMatching; // 단어 맞추기
    public static bool menuMakeSentence; // 문장 만들기

    // 단어공부 화면에서의 카테고리
    public static bool wordStudyNumber; // 숫자 공부
    public static bool wordStudyObject; // 사물 공부
    public static bool wordStudyAnimal; // 동물 공부
    public static bool wordStudyHuman; // 인물 공부
    public static bool wordStudyTime; // 시간 공부

    // 현재 공부하고 있는지 구분하기 위한 플래그값들 초기화
    public static void InitCurrentStudyCheck()
    {
        //모두 false로 초기화 시켜줌
        menuWordStudy = false; // 단어공부
        menuWordMatching = false; // 단어 맞추기
        menuMakeSentence = false; // 문장 만들기

        wordStudyNumber = false; // 숫자 공부
        wordStudyObject = false; // 사물 공부
        wordStudyAnimal = false; // 동물 공부
        wordStudyHuman = false; // 인물 공부
        wordStudyTime = false; // 시간 공부
    }

}

class Object3D
{
    int[] id;
    string[] english;
    string[] korean;
    string[] phoneticAlpabet;
    string[] relationSentence;
    int[] marker_key;

}
