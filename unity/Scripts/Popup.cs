using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour {
    public Text txt;
    float time;

    public void ShowPopUp(string str)
    {
        time = 1.5f;
        this.gameObject.SetActive(true);
        txt.text = str; 
    }
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0f) 
            this.gameObject.SetActive(false);
    } 
}
