using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    [SerializeField] private float speed = 15f;
    public GameObject ball;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;

        Movement();

    }


    private void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            Vector3 temp = transform.position;
            temp.y = Mathf.Clamp(temp.y, -3.75f, 3.75f);
            transform.position = new Vector3(transform.position.x, temp.y, transform.position.z);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            Vector3 temp = transform.position;
            temp.y = Mathf.Clamp(temp.y, -3.75f, 3.75f);
            transform.position = new Vector3(transform.position.x, temp.y, transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Space) &&!GameObject.FindGameObjectWithTag("Ball"))
        {
            CmdSpawnBall();
        }
    }


    [Command]
    void CmdSpawnBall()
    {
        GameObject go = (GameObject) Instantiate(ball, GameObject.Find("SpawnBall").GetComponent<Transform>().transform.position, Quaternion.identity);
        NetworkServer.Spawn(go);
    }

}
