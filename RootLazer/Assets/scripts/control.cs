using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class control : MonoBehaviour {

    private float speed, rotationspeed, friction;
    private float xder;
	// Use this for initialization
    public static float speedin;
    private int score;
	void Start () {
        speed = 5;
        rotationspeed = 10;
        friction = 0.75f;
        speedin = speed;

        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        /*if(Input.GetMouseButton(0))
        {
            xder -= Input.GetAxis("Mouse X") * speed * friction;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, xder, 0), rotationspeed * Time.deltaTime);
        }*/
        //code setted as 90 degree in y
        transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.B))
        {
            transform.Rotate(Vector3.up, rotationspeed * Time.deltaTime);
            Vector3 curr = transform.localRotation.eulerAngles;
            curr.y = Mathf.Clamp(curr.y, 45, 135);
            transform.localRotation = Quaternion.Euler(curr);
        }
        if (Input.GetKey(KeyCode.V))
        {
            transform.Rotate(-Vector3.up, rotationspeed * Time.deltaTime);
            Vector3 curr = transform.localRotation.eulerAngles;
            curr.y = Mathf.Clamp(curr.y, 45, 135);
            transform.localRotation = Quaternion.Euler(curr);
        }

        Vector3 currh = transform.localRotation.eulerAngles;
        currh.x = 0;
        currh.z = 0;
        transform.localRotation = Quaternion.Euler(currh);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            //SceneManager.LoadScene("gameover");
            Debug.Log(other.name);
        }
        if (other.tag == "jam")
        {
            score++;
//            SceneManager.LoadScene("gameover");
            Debug.Log("score : "+score);
        }
    }

}
