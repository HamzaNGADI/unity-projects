using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logoanim : MonoBehaviour {

    // Use this for initialization
    static Animator animl;
    void Start()
    {
        animl = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

         /* if(Input.GetKeyDown(KeyCode.I))
          {
              animl.SetTrigger("logoin");
          }
          if (Input.GetKeyDown(KeyCode.O))
          {
              animl.SetTrigger("logoout");
          }*/
    }

    public static void logoin()
    {
        animl.SetTrigger("logoin");
    }
    public static void logoout()
    {
        animl.SetTrigger("logoout");
    }
}
