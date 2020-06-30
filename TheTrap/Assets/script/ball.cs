using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ball : MonoBehaviour
{

    // Use this for initialization
    private Vector3 initpos;
    static Vector3 localsc;
    public static bool initball = false, shootin = false, gameover = true;
    public static Text score, best;
    public static int sc, bestsc;
    public GameObject bulletp;
    public GameObject targetin;
    float rotdeg, rotspddi;
    void Start()
    {
        shootin = false;
        score = GameObject.FindWithTag("score").GetComponent<Text>();
        best = GameObject.FindWithTag("bestsc").GetComponent<Text>();
        sc = bestsc = 0;
        best.text = "";

        gamedata gu = savingsys.load();
        if (gu == null) bestsc = 0;
        else bestsc = gu.getscore();

        initpos = transform.position;
        rotdeg = 5f;
        rotspddi = 50;
        // GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 8), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        localsc = transform.localScale;
        transform.position = initpos;
        if (Input.GetMouseButtonUp(0))
        {
            if (shootin)
            {
               // Vector3 mouse = Input.mousePosition;
                //mouse.z = 10;
                Vector3 worldtrg= targetin.transform.position;

                Vector2 direction = (Vector2)((worldtrg - transform.position));
                direction.Normalize();
                // Creates the bullet locally
                GameObject bullet = (GameObject)Instantiate(
                                        bulletp,
                                        transform.position + (Vector3)(direction * 0.5f),
                                        Quaternion.identity);
                // Adds velocity to the bullet
                bullet.GetComponent<Rigidbody2D>().velocity = direction * 30f;
            }
            if (!shootin && gameover == true)
            {
                gameover = false;
                Debug.Log("startin");
                sc = 0;
                score.text = "Score : " + sc;
                best.text = "";
                walls.rotationspeed = 59;
                walls.rotlook = 0;

                tapetoplaysc.tapeout();
                logoanim.logoout();
                gm.instanciat = true;
                //remove all texts

            }
            rotspddi = 50;
        }

        //////////////////////
        if (Input.GetMouseButton(0))
        {
            Vector3 mous = Input.mousePosition;
            mous.z = 10;
            var plypnt = Camera.main.WorldToScreenPoint(transform.position);
            if (mous.x < plypnt.x)
            {
               // Debug.Log("lfttt");
                transform.Rotate(Vector3.forward * Time.deltaTime * rotspddi);
            }
            else
            {
            //    Debug.Log("righttt");
                transform.Rotate(-Vector3.forward * Time.deltaTime * rotspddi);
            }
            if(rotspddi<200f)rotspddi += 0.5f;
      //      Debug.Log("rotsssss" + rotspddi);
        }
     /*       Debug.Log("mous x " + transform.localPosition.x);
        Vector2 directn = Camera.main.ScreenToWorldPoint(mous) - transform.position;
        float angl = Mathf.Atan2(directn.y, directn.x) * Mathf.Rad2Deg;
        Quaternion rotnn = Quaternion.AngleAxis(angl, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotnn, Time.deltaTime * 50f);
        */


    }

    void OnCollisionEnter2D(Collision2D col)
    {


        if (col.collider.tag == "wall")
        {


        }


    }

    public static void scoring()
    {
        sc++;
        score.text = "Score : " + sc;

        if (sc > bestsc)
        {
            bestsc = sc;
            savingsys.save(new gamedata(bestsc));
            //      best.text = "best score = " + bestsc;
        }


    }

    public static void bestscshow()
    {
        best.text = "best score : " + bestsc;
    }
    public static Vector3 ballscale()
    {
        return localsc;
    }

}
