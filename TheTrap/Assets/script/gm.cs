using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gm : MonoBehaviour {

    // Use this for initialization
    public GameObject fontcam;
    public GameObject[] wals;
    public Color[] camcol;

    public static Color currcol;
    private float[] rangerotate, rangescale;
    public static Color[] col;
    public static bool instanciat = false;
	void Start () {
        rangerotate = new float[] { 20f, 30f ,45f, 60f };
        rangescale = new float[] { 1.2f, 1.4f, 1.3f ,1.5f};
        col = new Color[] { Color.red, Color.blue, Color.gray, Color.green };
        int ic = Random.Range(0, col.Length);

      /*  GameObject firstwall = GameObject.FindWithTag("walls");
        for (int curi = 0; curi < firstwall.transform.childCount; curi++)
        {
       //     firstwall.transform.GetChild(curi).gameObject.GetComponent<SpriteRenderer>().color = col[ic].;
            firstwall.transform.GetChild(curi).gameObject.GetComponent<SpriteRenderer>().color = new Color(col[ic].r, col[ic].g, col[ic].b, 0f); 
        }*/

        int ccl = Random.Range(0, camcol.Length);
        fontcam.GetComponent<Camera>().backgroundColor =camcol[ccl]; ///////////////////
        currcol = col[ic];
    }
	
	// Update is called once per frame
	void Update () {
		if(instanciat==true)
        {
            GameObject[] wl = GameObject.FindGameObjectsWithTag("walls");
            for (int ww = 0; ww < wl.Length; ww++) Destroy(wl[ww]);
            walls.fd = false;
            walls.rotlook = Random.Range(0, 2);
            walls.rotationspeed += 1;
            Debug.Log("spd r = " + walls.rotationspeed);

            ball.shootin = true;
            walls.fadin = 0f;
            int iw = Random.Range(0, wals.Length);
            int i = Random.Range(0, rangerotate.Length);
            int ii = Random.Range(0, rangescale.Length);
            GameObject curr= (GameObject)Instantiate(wals[iw], transform.position, Quaternion.identity);
           curr.transform.Rotate(new Vector3(0,0,rangerotate[i]));
            curr.transform.localScale = new Vector3(rangescale[ii], rangescale[ii], rangescale[ii]);
            int ic = Random.Range(0, col.Length);
            for (int curi= 0; curi < curr.transform.childCount; curi++)
            {
              //  curr.transform.GetChild(curi).gameObject.GetComponent<SpriteRenderer>().color = col[ic];
                curr.transform.GetChild(curi).gameObject.GetComponent<SpriteRenderer>().color = new Color(col[ic].r, col[ic].g, col[ic].b, 0f);
            }

            int ccl = Random.Range(0, camcol.Length);
            fontcam.GetComponent<Camera>().backgroundColor = camcol[ccl];
            /////////////////
            currcol = col[ic];
            
            instanciat = false;
        }
    }
}
