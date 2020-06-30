using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        //        Debug.Log("yaaaaas");
        var hit = col.gameObject;
        var heal = hit.GetComponent<health>();
        if(heal != null)
        {
            heal.damage(10);
        }
        Destroy(gameObject);

    }
}
