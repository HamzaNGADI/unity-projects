using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatincontrol : MonoBehaviour {

    // Use this for initialization
    public GameObject cleaner;
    private bool activ;
    private static bool activall;
    private float speed = 50;
	void Start () {
        activ = activall=true;
	}
	
	// Update is called once per frame
	void Update () {
		if(activ == true)
        {
            transform.Rotate(Vector3.right * (speed * Time.deltaTime));
        }

    }

    public void torotatin(bool b)
    {
        activ = b; 
    }
    
    public void speedinc()
    {

    }
    public void speeddec()
    {

    }
}
