using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WordManager : MonoBehaviour {

    public Text title;
    string sceneName;
	// Use this for initialization
	void Start () {
        sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "WordAnimal":
                title.text = "Animal(동물)";
                break;
            case "WordObject":
                title.text = "Object(사물)";
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] markers = GameObject.FindGameObjectsWithTag("Marker"); 
        for (int i = 0; i < markers.Length; i++)
        {
            switch (sceneName)
            {
                case "WordAnimal":
                    UserInfo.wordAnimal[markers[i].GetComponent<Word>().index] = true;
                    break;
                case "WordObject": 
                    UserInfo.wordObject[markers[i].GetComponent<Word>().index] = true;
                    break;
            }
        }
	}
}
