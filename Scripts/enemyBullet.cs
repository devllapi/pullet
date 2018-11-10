using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour {
	public Rigidbody2D rb;
	public Vector2 dir;
	//Transform player;
	public float spd;
	float timer;
	public GameObject player;
	public GameObject enemy;

	public GameObject bulletSmoke;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){
		Debug.Log (player);
//		player = GameObject.FindGameObjectWithTag ("Player").transform;
//		if (player!=null){
//		dir = (player.position - transform.position).normalized;
//		}
		timer+=1*Time.deltaTime;
		if (timer >= 3 || player==null||enemy==null) {
			Destroy (gameObject);
		}

	}
	void FixedUpdate () {
		

		rb.MovePosition(transform.position + transform.right * spd);
		}


	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Player") {
			Destroy (gameObject);
			Instantiate (bulletSmoke, transform.position, Quaternion.identity);
		}
		if (col.gameObject.tag=="floor" || col.gameObject.tag=="spikes") {
			Destroy (gameObject);
			Instantiate (bulletSmoke, transform.position, Quaternion.identity);
		}

	}
}