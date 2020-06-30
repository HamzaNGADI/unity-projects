using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrol : MonoBehaviour
{

    public Transform player;
    private Vector3 offset;
    private float fmin, fmax,zoomsp;
    private Camera cam;
    void Start()
    {
        offset = transform.position - player.transform.position;
        fmin = 0;
        fmax = 1000;
        zoomsp = 10;
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = player.transform.position + offset;
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            cam.fieldOfView += zoomsp;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            cam.fieldOfView -= zoomsp;
        }
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, fmin, fmax);
    }

    public void target(Transform t)
    {
        player = t;
    }
}
