using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] private float speed = 15f;
    
	// Use this for initialization
	void Start () {
        if(GameObject.Find("SpawnBall").GetComponent<Direction>().isRight)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    float HitFactor(Vector2 BallPos, Vector2 PaddlePos, float PaddleHeight)
	{
		return (BallPos.y - PaddlePos.y)/PaddleHeight;
	}

	
	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.transform.position.x == GameObject.Find("LeftSpawn").GetComponent<Transform>().transform.position.x 
            && other.gameObject.CompareTag("Player"))
		{
			float y = HitFactor(transform.position,other.transform.position,other.collider.bounds.size.y);
			Vector2 Dir = new Vector2(1,y).normalized;
			GetComponent<Rigidbody2D>().velocity = Dir* speed;
		}

        if (other.gameObject.transform.position.x == GameObject.Find("RightSpawn").GetComponent<Transform>().transform.position.x
            && other.gameObject.CompareTag("Player"))
        {
            float y = HitFactor(transform.position, other.transform.position, other.collider.bounds.size.y);
            Vector2 Dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = Dir * speed;
        }
    }
}
