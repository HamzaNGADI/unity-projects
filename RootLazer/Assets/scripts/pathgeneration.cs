using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathgeneration : MonoBehaviour {

    public GameObject currentobj;
    public Transform playersc;
    float spawnz = 0.0f;
    float tilesize = 40;
    bool ss = false; 
    int amounttile = 4;
    List<GameObject> tiles;

    public Material[] mat;
    
	void Start () {
        tiles = new List<GameObject>();
        for (int i = 0; i < amounttile; i++) spawny();
	}
	
	// Update is called once per frame
	void Update () {
        if (playersc.position.z > (spawnz - amounttile * tilesize))
        {
            spawny();
            if(ss)unspawn();
            ss = true;
        }
	}

    public void spawny(int spaw = -1)
    {
        GameObject curn;
        int i = Random.Range(0, mat.Length);
       curn  = (GameObject) Instantiate(currentobj, currentobj.transform.position, Quaternion.identity);
        curn.transform.SetParent(transform);
        curn.GetComponent<MeshRenderer>().material = mat[i]; 
       // curn.transform.Rotate(new Vector3(0,90,0));
        curn.transform.position = Vector3.forward * spawnz;
         spawnz += tilesize;
        tiles.Add(curn);
      
    }
    public void unspawn()
    {
        Destroy(tiles[0]);
        tiles.RemoveAt(0);
    }

}
