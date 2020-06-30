using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class walls : MonoBehaviour {

    // Use this for initialization
    public static int rotationspeed =60, rotlook=0;
    float scalin = 0.002f;
    public static float fadin=0f;
    public static bool fd = false;
	void Start () {
        fadin = 0.0f;
        fd = false;
	}
	
	// Update is called once per frame
	void Update () {
     /*   if (Input.GetKey(KeyCode.C))
        {
            transform.Rotate(Vector3.forward * rotationspeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.X))
        {*/
         if(rotlook==0)   transform.Rotate(-Vector3.forward* rotationspeed * Time.deltaTime);
        if (rotlook == 1) transform.Rotate(Vector3.forward * rotationspeed * Time.deltaTime);

        //   }
        if (fadin <1f)
        {
            //  fadin += 0.2f * Time.deltaTime;
            if (fd == true)
            {
                fadin += 0.2f * Time.deltaTime;
                fadin = Mathf.Clamp(fadin, 0f, 1f);
            }
            Debug.Log("fadin : " + fadin);
            for (int curi = 0; curi < transform.childCount; curi++)
            {
//                fadin += 0.05f*Time.deltaTime;
                float rr=transform.GetChild(curi).gameObject.GetComponent<SpriteRenderer>().color.r;
                float gi = transform.GetChild(curi).gameObject.GetComponent<SpriteRenderer>().color.g;
                float bi = transform.GetChild(curi).gameObject.GetComponent<SpriteRenderer>().color.b;
                transform.GetChild(curi).gameObject.GetComponent<SpriteRenderer>().color = new Color(rr, gi,bi, fadin);
            }
            fd = true;
            
        }
//        Debug.Log("fadin : "+fadin);
        int ch = transform.childCount;
        int ic = 0;
       // Debug.Log(transform.childCount);
       for (int i=0;i<ch;i++)
        {
            if (transform.GetChild(i).gameObject.name=="tagged")
                ic++;
        }
//        Debug.Log("ic = "+ic);
        if (ic == ch)
        {
            Destroy(gameObject);
            gm.instanciat = true;
        }

       transform.localScale = new Vector3(transform.localScale.x-scalin, transform.localScale.y - scalin, transform.localScale.z - scalin);
        if (transform.localScale.x <= 0.2 || transform.localScale.y <= 0.2)
        {
            ball.shootin = false;
            Debug.Log("too late !!");

        }
        if (transform.localScale.x<0 || transform.localScale.y < 0)
        {
            //SceneManager.LoadScene("main", LoadSceneMode.Single);
            Destroy(gameObject);
            tapetoplaysc.tapein();
            logoanim.logoin();
            ball.bestscshow();
            ball.shootin = false;
            ball.gameover = true;
            //    ball.shootin = true;
        }

      //  if(ball.gameover==true && ball.shootin==false) Destroy(gameObject);

    }
}
