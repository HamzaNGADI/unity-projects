using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour {

    // Use this for initialization
    public GameObject[] enemyy;
    private float timesp;
    public float timebtwsp, decreaser, mintimin;
	void Start () {
        timesp = timebtwsp;
        mintimin = 3.65f;
	}
	
	// Update is called once per frame
	void Update () {
        if (!scalling.gameover)
        {
            transform.Translate(Vector3.forward * scalling.speedrun * Time.deltaTime);
            if (timesp <= 0)
            {
                int i = Random.Range(0, enemyy.Length);

                GameObject cn = Instantiate(enemyy[i], transform.position, Quaternion.identity);
                if (i == 0)
                {
                    cn.transform.Rotate(new Vector3(0, 0, -90));
                    cn.transform.position -= new Vector3(0, 5f, 0);
                }
                timesp = timebtwsp;
                /*   if (timebtwsp > mintimin)
                   {
                       timebtwsp -= decreaser;
                   }*/
            }
            else timesp -= Time.deltaTime;
        }
	}
}
