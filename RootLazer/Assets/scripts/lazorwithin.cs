using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazorwithin : MonoBehaviour {

    // Use this for initialization
    private LineRenderer lr;
    bool b = false;
	void Start () {
        lr = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hitlr;
        if (Physics.Raycast(transform.position, transform.forward, out hitlr))
        {
            if (hitlr.collider)
            {
                lr.SetPosition(1, new Vector3(0, 0, hitlr.distance));
                b = true;
            }
        }
        else
        {
            if (b == true)
            {
                lr.SetPosition(1, new Vector3(0, 0, 100));
                b = false;
            }
        }
    }
}
