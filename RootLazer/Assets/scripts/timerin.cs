using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timerin : MonoBehaviour {

    // Use this for initialization
    float current = 0, start = 5;
    public Text countd;
	void Start () {
        current = start;
	}
	
	// Update is called once per frame
	void Update () {
        current -= 1 * Time.deltaTime;
        countd.text = "Replay in : " + current.ToString("0.0");
        if(current<=0)
        {
            SceneManager.LoadScene("main");
        }
	}
}
