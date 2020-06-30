using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapetoplaysc : MonoBehaviour {

    // Use this for initialization
    static Animator anim;
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
      /*  if(Input.GetKeyDown(KeyCode.I))
        {
            anim.SetTrigger("in");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            anim.SetTrigger("out");
        }*/
    }

    public static void tapein()
    {
        anim.SetTrigger("in");
    }
    public static void tapeout()
    {
        anim.SetTrigger("out");
    }
}
