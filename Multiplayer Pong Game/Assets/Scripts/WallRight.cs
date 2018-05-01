using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WallRight : NetworkBehaviour {

    [SyncVar] private int leftScore = 0;
    public GameObject ball;
    public Transform spawnBall;

   

    private void OnTriggerEnter2D (Collider2D other) {
        spawnBall.GetComponent<Direction>().isRight = false;
        CmdScoreOnServer();
        CmdSpawnBall();
         
       

        Destroy (other.gameObject);

    }

    [Command]
    void CmdScoreOnServer()
    {
        leftScore++;
        RpcDisplayScore(leftScore);
    }

    [Command]
    void CmdSpawnBall()
    {
        GameObject Ball = (GameObject)Instantiate(ball, spawnBall.position, Quaternion.identity);
         NetworkServer.Spawn(Ball);
        //NetworkServer.SpawnWithClientAuthority(Ball, connectionToClient);
    }

    [ClientRpc]
    public void RpcDisplayScore(int score)
    {
        GameObject.Find("ScoreLeft").GetComponent<TextMesh>().text = score.ToString();
    }
}