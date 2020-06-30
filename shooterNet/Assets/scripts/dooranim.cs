using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class dooranim : NetworkBehaviour {

    // Use this for initialization
    static Animator anim;
    static float minstart = 10;
    float count = minstart;
    public static bool countin = false;
	void Start () {
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(countin == true)
        {
            count -= Time.deltaTime;
            if(Mathf.Round(count) <= 0)
            {
                closing();
            }
        }
	}
    public static void opening()
    {
        countin = true;
        Debug.Log("anim copenin");
        anim.SetTrigger("openDoor");

    }
    public void closing()
    {
        countin = false;
        count = minstart;
        anim.enabled = true;
        Debug.Log("anim close");
    }
    void pausingAnim()
    {
        Debug.Log("anim pausin");
        anim.enabled = false;
    }
}
