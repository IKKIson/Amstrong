using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HelpManager : MonoBehaviour
{

    /*
     *  HelpPanel1 : 사물
     *  HelpPanel1 : 동물
     *  HelpPanel1 : 단어맞추기
     *  HelpPanel1 : 문장 만들기
     * 
     * 
    */

    [Header("도움말 설명")]
    public Text Explain;

    [Header("패널")]
    public GameObject HelpPanel1;
    public GameObject HelpPanel2;
    public GameObject HelpPanel3;
    public GameObject HelpPanel4;


    public void Start()
    {
        //Explain.text = "4번 도움말 입니다.";
    }

    public void StartHelpPanel1()
    {
        HelpPanel1.SetActive(true);
    }
    public void StartHelpPanel2()
    {
        HelpPanel1.SetActive(true);
    }
    public void StartHelpPanel3()
    {
        HelpPanel1.SetActive(true);
    }
    public void StartHelpPanel4()
    {
        HelpPanel1.SetActive(true);
    }


    public void CloseHelpPanel1Btn()
    {
        HelpPanel1.SetActive(false);
    }
    public void CloseHelpPanel2Btn()
    {
        HelpPanel2.SetActive(false);


    }
    public void CloseHelpPanel3Btn()
    {
        HelpPanel3.SetActive(false);
    }
    public void CloseHelpPanel4Btn()
    {
        HelpPanel4.SetActive(false);
    }
}
