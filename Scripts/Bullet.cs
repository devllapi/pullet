using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	Rigidbody2D rb;
	public float spd;
	public float pullBackSpd;
	public GameObject dust;
	public GameObject particles;
	 Transform player;
	public Vector2 dir;
	public bool calledBack;
	public bool rebound;
	public Vector2 bulletPos;

	public playerMovement bigMove;
	public float rotateSpeed;
	bool reverse;


	void Awake(){
		rb = GetComponent<Rigidbody2D>();

	}
	void Start () {
		player = GameObject.Find ("Raven Player").transform;
		bigMove = GameObject.FindObjectOfType<playerMovement> ();

	}
	void Update(){
		//print ("rotate"+transform.rotation);
		if (Input.GetMouseButtonDown(1)) {
			calledBack = true;
		}
		bulletPos = transform.position;
		//transform.localEulerAngles += new Vector3 (0, 0, rotateSpeed*Time.deltaTime);
		print(reverse+ "is");
	}
	void FixedUpdate () {
		
		//Debug.Log (dir);
		if (player != null) {
			dir = (player.position - transform.position).normalized;
		}


		if (calledBack==true && reverse==false) {
			if (player != null) {
				calledBack = true;
				GetComponent<Renderer> ().material.color = Color.red;
				gameObject.layer = 12;
				Debug.Log ("calling back");
				spd = 1;
				rb.MovePosition ((Vector2)transform.position + (dir * spd*pullBackSpd));
			}
		}
		else if(calledBack==false)
		{
			gameObject.layer =13;
			rb.MovePosition(transform.position + transform.right * spd);
		}
		if (reverse == true) {
			Destroy (gameObject);

		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		print ("welcome to" + collision.gameObject.tag);
		if (calledBack) {
			collision.gameObject.SendMessage ("OnShot", null, SendMessageOptions.DontRequireReceiver);
		}
		if (collision.gameObject.tag == "floor" && (gameObject.layer==13)) {
			spd = 0;
		}

		if (collision.gameObject.tag == "Player") {
			Destroy (gameObject);
			bigMove.bulletCount = 0;
			bigMove.isDashing = false;
		}
		if (collision.gameObject.tag == "shield") {
			reverse = true;
		}
		//		Instantiate (dust, transform.localPosition, Quaternion.identity);

		//Destroy(gameObject);


	}

}
