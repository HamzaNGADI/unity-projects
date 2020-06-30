using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using UnityEngine.UI;

public class playerspawn : NetworkBehaviour {


    public GameObject Player = null;

    public virtual void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        for (int i = 0; i > 2; i++)
        {
          /*  if(i==0)Player.GetComponent<MeshRenderer>().material.color = Color.blue;
            else Player.GetComponent<MeshRenderer>().material.color = Color.red;*/

            Instantiate(Player, transform.position, Quaternion.identity);
            
        }
    }

}
