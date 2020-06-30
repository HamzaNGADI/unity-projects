using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class playerloading : NetworkManager {

    public GameObject[] Player;
    public static Color[] col = { Color.green, Color.yellow };
    public static int i = 0;

    public override void OnServerDisconnect(NetworkConnection conn)
    {

        NetworkServer.DestroyPlayersForConnection(conn);

        if (conn.lastError != NetworkError.Ok)
        {

            if (LogFilter.logError) { Debug.LogError("Server error: " + conn.lastError); }

        }

    }

    public override void OnServerReady(NetworkConnection conn)
    {

        NetworkServer.SetClientReady(conn);
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
       // for (int i = 0; i < Player.Length; i++)
      //  {
            var sply = new Vector3(Random.Range(-5.0f, 5.0f), 0.0f, Random.Range(-5.0f, 5.0f));

            var player = (GameObject)GameObject.Instantiate(playerPrefab, sply, Quaternion.identity);
            //var player = (GameObject)GameObject.Instantiate(Player[i], sply, Quaternion.identity);

            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);


            Debug.Log("Client true");
      //  }
    }

    public override void OnServerRemovePlayer(NetworkConnection conn, PlayerController player)
    {

        if (player.gameObject != null)

            NetworkServer.Destroy(player.gameObject);

    }

    public override void OnClientConnect(NetworkConnection conn)

    {

        base.OnClientConnect(conn);
        ClientScene.AddPlayer(0);


        Debug.Log("Connected client...");

    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {

        StopClient();

        if (conn.lastError != NetworkError.Ok)

        {

            if (LogFilter.logError) { Debug.LogError("disconn error: " + conn.lastError); }

        }


    }


    public override void OnClientSceneChanged(NetworkConnection conn)
    {

        base.OnClientSceneChanged(conn);

        Debug.Log("scene client...");

    }


}
