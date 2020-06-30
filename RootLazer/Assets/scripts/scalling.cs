using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scalling : MonoBehaviour
{

    
    public float shrinkSpeed = 5f,speed=4,der,dery;
    public static float speedrun=5;
    private float targetScale;
    private Vector3 v3Scale;
    public static bool gameover;
    private int score, bestsc;
    public Text txtscore;
    public Text bestscore;
    void Start()
    {
        gameover = false;
        v3Scale = transform.localScale;
        score = 0;

        bestscore.text = "";
        gamedata gu = savingsys.load();
        if (gu == null) bestsc = 0;
        else bestsc = gu.getscore();
        Debug.Log("bs" + bestsc + " gu " + gu.getscore());
    }

    void Update()
    {
        if(!gameover)transform.position += new Vector3(0, 0, 1) * speedrun * Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            der -= Input.GetAxis("Mouse X") * speed;
          //  der = Mathf.Clamp(der, 20, 135);
            dery -=Input.GetAxis("Mouse Y")*speed;
         //   Debug.Log("x = " + der + " y = " + dery);
            if (dery>0)
            {

                v3Scale.x += 0.1f;
                v3Scale.y -= 0.1f;
                v3Scale.x = Mathf.Clamp(v3Scale.x, 0.5f, 5);
                v3Scale.y = Mathf.Clamp(v3Scale.y, 0.5f, 5);
                //xaxis
            }
            if (dery<=0)
            {
                v3Scale.x -= 0.1f;
                v3Scale.y += 0.1f;
                v3Scale.x = Mathf.Clamp(v3Scale.x, 0.5f, 5);
                v3Scale.y = Mathf.Clamp(v3Scale.y, 0.5f, 5);
               //axis
            }
            if(transform.localScale.y>=transform.localScale.x) GetComponent<CapsuleCollider>().direction = 1;
            else    GetComponent<CapsuleCollider>().direction = 0;
                
            
        }
        /*  if (Input.GetKey(KeyCode.W))
          {

              v3Scale.x += 0.1f;
              v3Scale.y -= 0.1f;
              v3Scale.x = Mathf.Clamp(v3Scale.x, 0.5f, 5);
              v3Scale.y = Mathf.Clamp(v3Scale.y, 0.5f, 5);

          }
          if (Input.GetKey(KeyCode.X))
          {
              v3Scale.x -= 0.1f;
              v3Scale.y += 0.1f;
              v3Scale.x = Mathf.Clamp(v3Scale.x, 0.5f, 5);
              v3Scale.y = Mathf.Clamp(v3Scale.y, 0.5f, 5);
          }*/
        if (Input.GetKey(KeyCode.N))
        {
           if(gameover) SceneManager.LoadScene("main");
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, der), shrinkSpeed * Time.deltaTime);
        transform.localScale = Vector3.Lerp(transform.localScale, v3Scale, Time.deltaTime * shrinkSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "jam")
        {
            score++;
            //            SceneManager.LoadScene("gameover");
            txtscore.text = "score : " + score;
            //            Debug.Log("score : " + score);
            Destroy(other.gameObject);
        }
        if (other.tag == "enemy")
        {
          //  SceneManager.LoadScene("gameover");
            Debug.Log("tkass by "+other.name);
            if(score>bestsc)
            {
                bestsc = score;
                savingsys.save(new gamedata(bestsc));
            }
            bestscore.text = "best score = " + bestsc;
            gameover = true;
        }
      
    }
}

