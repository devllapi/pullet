using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRand : MonoBehaviour {
	int health=1;
	bool dead;
	public GameObject enemyBullet;
	GameObject player;
	public static int score;
	public float spd;
	Rigidbody2D rb;
	public GameObject[] randomEnemy;
	public playerMovement playerMove;
	 GameManager deathCounter;
	bool dashToo;
	Vector2 dir;

	CamControl cam;
	public GameObject deathEffect;
	public GameObject deathText;

	public TextMesh textMesh;
	float deathScore=200;
	// Use this for initialization
	void Start () {
//		StartCoroutine (Shoot ());
		rb=GetComponent<Rigidbody2D>();
		deathCounter = GameObject.Find ("Manager").GetComponent<GameManager> ();
		player = GameObject.Find ("Raven Player");
		dashToo = playerMove.GetComponent<playerMovement> ().isDashing;
		cam = GameObject.Find ("Main Camera").GetComponent<CamControl> ();

	}
	
	// Update is called once per frame
	void Update () {
		print (dashToo);

		if (dead == true) {
			
			Destroy (gameObject);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			dashToo = true;
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
		if (dashToo == true) {
			
			dir = ((Vector2)player.transform.position - ((Vector2)transform.position)).normalized;
			rb.MovePosition ((Vector2)transform.position + (dir * spd * 3));
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
//			int numberSelect = Random.Range (0, 2);
//			Instantiate (randomEnemy [numberSelect], (Vector2)transform.position+new Vector2 (3,0), Quaternion.identity);
//			print (randomEnemy[numberSelect].transform.position);
		
			Instantiate (deathEffect, transform.position, Quaternion.identity);
			Instantiate (deathText, new Vector2(transform.position.x, transform.position.y+3), Quaternion.identity);

			cam.shakeCamera(.25f,.25f);
			Flasher.me.ScoreUp ();
		}
	}
}
