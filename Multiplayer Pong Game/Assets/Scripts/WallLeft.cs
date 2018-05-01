using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WallLeft : NetworkBehaviour {

    [SyncVar] private int rightScore = 0;
    public GameObject ball;
	public Transform spawnBall;

	private void OnTriggerEnter2D (Collider2D other) {
        spawnBall.GetComponent<Direction>().isRight = true;
        CmdScoreOnServer();
        CmdSpawnBall();

        Destroy(other.gameObject);
	}


    [Command]
    void CmdScoreOnServer()
    {
        rightScore++;
        RpcDisplayScore(rightScore);
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
        GameObject.Find("ScoreRight").GetComponent<TextMesh>().text = score.ToString();
    }
}