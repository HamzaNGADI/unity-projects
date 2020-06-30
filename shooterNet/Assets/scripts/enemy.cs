using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class enemy : NetworkBehaviour {


    public GameObject enemyPrefab;
    public int num;
   


    public override void OnStartServer()
    {
        for (int i = 0; i < num; i++)
        {
            var spawnp = new Vector3(Random.Range(-8.0f, 8.0f), 0.0f,Random.Range(-8.0f, 8.0f));

            var spawnr = Quaternion.Euler(0.0f,Random.Range(0, 180), 0.0f);

            var enemy = (GameObject)Instantiate(enemyPrefab, spawnp, spawnr);
            NetworkServer.Spawn(enemy);
        }
    }
}
