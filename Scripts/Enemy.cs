using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	int health=1;
	bool dead;
	public GameObject enemyBullet;
	GameObject player;
	public static int score;
	public float spd;
	Rigidbody2D rb;
	 CamControl cam;
	 GameManager deathCounter;

	public GameObject deathEffect;
	public soundScript sound;
	public AudioClip deathSound;

	public GameObject deathText;

	public TextMesh textMesh;
	float deathScore=100;
	// Use this for initialization
	void Start () {
//		StartCoroutine (Shoot ());
		rb=GetComponent<Rigidbody2D>();
		cam = GameObject.Find ("Main Camera").GetComponent<CamControl> ();
		player = GameObject.Find ("Raven Player");
	}
	
	// Update is called once per frame
	void Update () {
		

		if (dead == true) {
			
			Debug.Log ("start timer");
			Destroy (gameObject);
		}
	
	}
		void FixedUpdate(){
		if (player != null) {
			GameObject playerObj;
			Vector3 playerPos;
			playerObj = GameObject.FindWithTag ("Player"); 
			playerPos = playerObj.transform.position;
			Vector3 vel;
			vel = (playerPos - transform.position).normalized * spd;
			rb.MovePosition (transform.position + vel); 
		}


		}
	
//	IEnumerator Shoot() {
//		if (!dead) {
//			yield return new WaitForSeconds (Random.Range (1f, 4f));
//			Instantiate (enemyBullet, transform.position+transform.right*spd, Quaternion.Euler (0, 0, Geo.ToAng (player.position - transform.position)));
//			StartCoroutine (Shoot ());
//		}
//	}
	void OnShot(){
		health--;
		//GetComponent<Collider2D> ().enabled=false;

		//splat.Play ();


		if (health <= 0) {
			dead = true;
			GameManager.me.killCount += 1;
			if (GameManager.me.comboIsActive == false) {
				GameManager.me.playerScore+=deathScore;
				textMesh.text = "+" + deathScore + "!";
			} else{
				GameManager.me.playerScore += deathScore*2;
				textMesh.text = "+" + deathScore*2 + "!";
			}
			GameManager.me.ResetComboTimer ();
			cam.shakeCamera(.25f,.25f);

			Instantiate (deathText, new Vector2(transform.position.x, transform.position.y+3), Quaternion.identity);
			Instantiate (deathEffect, transform.position, Quaternion.identity);
			soundScript.me.Play (deathSound);
			Flasher.me.ScoreUp();
		}
	}
}
