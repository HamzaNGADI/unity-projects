using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    private int count;
    public Text countn;
    public Text winin;
    private float rr;

    void Start () {
        rb = GetComponent<Rigidbody>();
        rr = 0.3f;

        count = 0;
        countext();
        winin.text = ""; 
	}

    private void FixedUpdate()
    {
        float moveh = Input.GetAxis("Horizontal");
        float movev = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveh, 0.0f, movev);
        rb.AddForce(move*speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            countext();
        }
        if(other.gameObject.CompareTag("cubeappart"))
        {
            if (rr < 1f)
            {
                other.gameObject.GetComponent<Renderer>().material.color = new Color(rr, 0.3f, 0.24f);
                rr += 0.08f;
            }
            else countn.text = "count : " + count.ToString()+ " -- colors stopped";

        }
    }

    void countext()
    {
        countn.text = "count : " + count.ToString();
        if(count>=5) winin.text = "Congrats";
    }
}
