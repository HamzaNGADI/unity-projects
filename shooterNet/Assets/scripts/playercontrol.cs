using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using System.Linq;


public class playercontrol : NetworkBehaviour
{

    [SyncVar] public int doorin = 0;

    public GameObject bullet;
    public Transform bulletsp;
    //    public Dropdown avatarii;
    static string colorin;
    bool boolin = true, btxt = true;
    static Color colav;
    GameObject[] txts;

    GameObject txt;
    public GameObject plc ;
    static uint no;
    // Use this for initialization
    void Start()
    {
        plc = this.gameObject;

        txts = GameObject.FindGameObjectsWithTag("txt");
        print(txts.Length);
        txt = txts[0];
    }
   
    // Update is called once per frame
    void Update()
    {
        if (isServer) collectormouse.activatin = true;
        else collectormouse.activatin = false;
       
        if (isLocalPlayer)
        {

            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Cmdfire();
            }
        }
        //   doorup = doorin;
    }
    IEnumerator wait()
    {
        Cmddoor();
        yield return new WaitForSeconds(1);

    }
    
        void OnCollisionEnter(Collision col)
    {
        uint n = 0;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        // if(isClient) Debug.Log("yeaaaaa");
        if (col.gameObject.tag == "sqr" && players.Length>1)
        {
          
            foreach (GameObject p in players)
            {
                if (n < p.GetComponent<NetworkIdentity>().netId.Value)
                    n = p.GetComponent<NetworkIdentity>().netId.Value;
            }
            Debug.Log(n);

            if (gameObject.GetComponent<NetworkIdentity>().netId.Value == n)
            {
                Destroy(col.gameObject);
            }
        }


        if (col.gameObject.tag == "door")
        {
            //            col.gameObject.transform.col
            Debug.Log(gameObject.GetComponent<NetworkIdentity>().netId);
            if (!isServer)
            {
                doorin++;
                txt.GetComponent<Text>().text = "" + (int.Parse(txt.GetComponent<Text>().text) + 1);
            }
            else
            {
                Cmddoor();
            }
        }
    }
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "door")
        {
            boolin = true;

            if((int.Parse(txt.GetComponent<Text>().text)==2) && doorin!=0)
            {
                //Destroy(col.gameObject);
               if(dooranim.countin==false) dooranim.opening();
            }

  //          Debug.Log("doorin : " + transform.name);
    //        Debug.Log("lo : " + isLocalPlayer);
        }
    }



    void OnCollisionExit(Collision col)
    {
        
        if (col.gameObject.tag == "door")
        {

            if (!isServer)
            {
                doorin--;
                txt.GetComponent<Text>().text = "" + (int.Parse(txt.GetComponent<Text>().text) - 1);

            }
            else
            {
                Cmddoormin();
            }

            Debug.Log("exiit doorin : " + transform.name);


        }
    }


    [Command]
    void Cmdfire()
    {
        var bulet = (GameObject)Instantiate(bullet, bulletsp.position, bulletsp.rotation);
        bulet.GetComponent<Rigidbody>().velocity = bulet.transform.forward * 7;
        NetworkServer.Spawn(bulet);
        Destroy(bulet, 4.0f);
    }


    [Command]
    void Cmddoor()
    {
        doorin++;
        txt.GetComponent<Text>().text = "" + (int.Parse(txt.GetComponent<Text>().text) + 1);


        //        Rpcdoor(doorin);
    }

    [Command]
    void Cmddoormin()
    {
        
        doorin--;
        txt.GetComponent<Text>().text = "" + (int.Parse(txt.GetComponent<Text>().text) - 1);



        //      Rpcdoormin(doorin);
    }

    
    public static void playerColor(string c)
    {
        if(c.Contains("red"))
        {
            colav = Color.red;
        }
        else if (c.Contains("green"))
        {
            colav = Color.green;
        }
        else colav = Color.blue;
    }
 
    public override void OnStartLocalPlayer()
    {
        
        if(isServer)   GetComponent<MeshRenderer>().material.color = playerloading.col[0];
        else GetComponent<MeshRenderer>().material.color = playerloading.col[1];
        Camera.main.GetComponent<cameracontrol>().target(gameObject.transform);
    }
}
