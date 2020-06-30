using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jam : MonoBehaviour {

    void Update()
    {
        transform.Rotate(new Vector3(10, 25, 40) * Time.deltaTime*10);
    }
}
