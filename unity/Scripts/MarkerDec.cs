using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerDec : MonoBehaviour {
    public static int myFilter1;
    public static int myFilter2;

    public int m1;
    public int m2;


    
	// Use this for initialization
	void Start () {
        m1 = 127;
        m2 = 255;
        
    }
	
	// Update is called once per frame
	void Update () {
        myFilter1 = m1;
        myFilter2 = m2;
	}
}
