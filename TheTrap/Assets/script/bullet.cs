using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour {

    // Use this for initialization
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}





    void OnCollisionEnter2D(Collision2D col)
    {
              
                   
        if (col.collider.tag == "out")
          {
                        //   GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
                            Destroy(gameObject);
           // SceneManager.LoadScene("main", LoadSceneMode.Single);

        }

        if (col.collider.tag == "wall")
        {
            if (col.collider.name=="tagged")
            {
                // SceneManager.LoadScene("main", LoadSceneMode.Single);
                Destroy(gameObject);
                tapetoplaysc.tapein();
                logoanim.logoin();
                ball.bestscshow();
                ball.shootin = false;
                ball.gameover = true;
                GameObject[] wl = GameObject.FindGameObjectsWithTag("walls");
                for (int ww = 0; ww < wl.Length; ww++) Destroy(wl[ww]);
            }
            else {
                Debug.Log("wall in");
                col.collider.name = "tagged";
                col.collider.GetComponent<SpriteRenderer>().color = new Color(0,0,0,walls.fadin);
                ball.scoring();
                Destroy(gameObject);
                }
        }
             
    }
}
