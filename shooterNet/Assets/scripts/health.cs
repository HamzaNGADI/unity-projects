using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class health : NetworkBehaviour {

    public const int maxh = 100;
    [SyncVar(hook = "onchangehealth")]
    public int currenth = maxh;
    public RectTransform healbar;
    public bool bedead;

    public void damage(int d)
    {
        if (isServer)
        {
            currenth -= d;
            if (currenth <= 0)
            {
                if (bedead)
                {
                    Destroy(gameObject);
                }
                else
                {
                    currenth = maxh;
                    RpcRespawn();
                }
            }
        }
    }

    void onchangehealth(int hea)
    {
        healbar.sizeDelta = new Vector2(hea, healbar.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if(isLocalPlayer)
        {
            transform.position = Vector3.zero;
        }
    }
}
