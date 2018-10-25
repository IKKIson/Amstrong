using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerSoundManager : MonoBehaviour {

    int AudioSoundIndex;
    string AudioSoundWord;
    [Serializable]
    public class MKSounds
    {
        public AudioSource soundSource;
        public AudioClip sound;
    }

    //public GameObject[] MarkerObjects;
    [Header("소리")]
    public MKSounds[] MarkerSound;
    
    

    [Header("인식")]
    GameObject EnableArObject;
    float timer;


    



    // Use this for initialization
    void Start () {
        AudioSoundIndex = -1;

    }
	
	// Update is called once per frame
	void Update () {

        FindEnableOjbect();

		
	}
    void FindEnableOjbect()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Marker");
   
        if(objs.Length == 1 && EnableArObject == null)
        {
            EnableArObject = objs[0];
            Debug.Log("해야된다. " + EnableArObject.ToString());


            //EnableArObject.text
            //수동임  불러와서 가져와야 함 
            //TODO: 이 부분 수정해야되는데 
            Debug.Log(AudioSoundIndex = EnableArObject.GetComponent<Word>().index);
            Debug.Log(AudioSoundWord = EnableArObject.GetComponent<Word>().GetWord.ToString());

            if (MarkerSound[AudioSoundIndex].soundSource && MarkerSound[AudioSoundIndex].sound)
            {
                if (MarkerSound[AudioSoundIndex].soundSource.GetComponent<AudioSource>().isPlaying)
                    return;
                else
                    MarkerSound[AudioSoundIndex].soundSource.GetComponent<AudioSource>().PlayOneShot(MarkerSound[AudioSoundIndex].sound);
            }
        } else if(objs.Length == 0)
        {
            EnableArObject = null;
        }

    }

}
