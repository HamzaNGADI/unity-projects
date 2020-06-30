using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazorsign : MonoBehaviour {

    public GameObject lazor;
    List<GameObject> spawnin;
	// Use this for initialization
	void Start () {
        spawnin = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space))
        {
            RaycastHit hitin;
            if(Physics.Raycast(lazor.transform.position,lazor.transform.forward, out hitin))
            {
                if(hitin.collider.tag =="enemy")
                {
                   
                    hitin.collider.gameObject.GetComponent<rotatincontrol>().torotatin(false);
                    spawnin.Add(hitin.collider.gameObject);
                }
            }
        }
        else
        {
            if(spawnin.Count!=0)
            {
                for (int i=0;i<spawnin.Count;i++)
                {
                    
                    spawnin[i].GetComponent<rotatincontrol>().torotatin(true);
                }
                spawnin.Clear();
            }
            
        }
    }
    
}
