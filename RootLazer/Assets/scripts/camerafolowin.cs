using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafolowin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public GameObject ply;

    public float speed = 2.0f;

    void Update()
    {
        float interpolation = speed*Time.deltaTime;

        Vector3 position = this.transform.position;
       // position.y = Mathf.Lerp(this.transform.position.y, ply.transform.position.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, ply.transform.position.x, interpolation);
        position.z = Mathf.Lerp(this.transform.position.z-0.5f, ply.transform.position.z-0.5f, interpolation);

        this.transform.position = position;
    }

}
