using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {  
        if (other.tag == "enemy" || other.tag=="cap" || other.tag == "jam") Destroy(other.gameObject);
    }
}
