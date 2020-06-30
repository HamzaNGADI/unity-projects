using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using UnityEngine.UI;

public class collectormouse : NetworkBehaviour {
    
    public Texture2D CursorImage;
    
    public Vector2 CursorSize = 24 * Vector2.one;
    
    public Color CursorTint = Color.red;
    private GameObject hoveredgm;
    public Material highlightmat;
    public LayerMask mask = -1;
    private bool grabbing = false;
    private float lastobjdist;
    public Color GrabCursorTint = Color.green;
    Material originalmat;
    public static bool activatin;

    [SyncVar(hook = "OnChangemove")]
    Transform currentm = null; 


    void Start()
    {
        //Transform currentm = hoveredgm.transform;
        originalmat = GameObject.FindGameObjectsWithTag("cubemat")[0].GetComponent<Renderer>().material;
    }
    private Vector3 GetCursorScreenPosition()
    {
        // Step 1: Return mouse screen position.
        return Input.mousePosition;
    }

    private GameObject GetHoveredObject()
    {
        var cursorPosition = GetCursorScreenPosition();
        var ray = Camera.main.ScreenPointToRay(cursorPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance: 1000, layerMask: mask.value))
        {
            if (hit.collider.gameObject.tag == "collect")
            {
                print("" + hit.collider.gameObject.name);
                return hit.collider.gameObject;
            }
        }
        return null;
    }

    private float GetCursorDistanceScalingFactor()
    {
        // Step 3: Compute the scaling factor of cursor distance: (current-frame-distance / previous-frame-distance)
        return 1;
    }

    private void StartGrab()
    {
        if (!hoveredgm)
        {
            return;
        }

        grabbing = true;
        lastobjdist = Vector3.Distance(Camera.main.transform.position, hoveredgm.transform.position);
    }

    public void StopGrab()
    {
        grabbing = false; activatin = false;
    }

    private void Update()
    {
      
        /////////////nuup
        if (highlightmat && !grabbing)
        {
            if (hoveredgm)
            {
         //       print("oooold m");
               hoveredgm.GetComponent<Renderer>().material = originalmat;
                
            }
            hoveredgm = GetHoveredObject();

            if (hoveredgm)
            {
                hoveredgm.GetComponent<Renderer>().material = highlightmat;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            StartGrab();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopGrab();
        }

        if (grabbing && activatin)
        {
                var ray = Camera.main.ScreenPointToRay(GetCursorScreenPosition());
                lastobjdist *= GetCursorDistanceScalingFactor();
                hoveredgm.transform.position = ray.GetPoint(lastobjdist);
        }
    }

    void OnChangemove(Transform currentt)
    {
        hoveredgm.transform.position=currentt.position;
    }
    private void OnGUI()
    {
        var cursorPosition = (Vector2)GetCursorScreenPosition();
        
        cursorPosition.y = Screen.height - cursorPosition.y;
        
        var bounds = new Rect(cursorPosition - 0.5f * CursorSize, CursorSize);

        var originalColor = GUI.color;
        GUI.color = grabbing ? GrabCursorTint : CursorTint;
        GUI.DrawTexture(bounds, CursorImage);

        GUI.color = originalColor;

    }
}
