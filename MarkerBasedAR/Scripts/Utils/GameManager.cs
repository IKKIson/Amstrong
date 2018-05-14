using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //싱글톤
    public static GameManager instance = null;
    public ScreenController screenController; //screenController

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //소멸되지않게 하기
        DontDestroyOnLoad(gameObject);
        InitGame();
    }
    void InitGame()
    {
        
    }


}
