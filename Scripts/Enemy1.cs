using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {
	int health=1;
	bool dead;
	public GameObject enemyBullet;
	GameObject player;
	public static int score;
	public float spd;
	Rigidbody2D rb;

	 GameManager deathCounter;
	 GameObject bullet;
	CamControl cam;

	public GameObject enemyDeath;
	public AudioClip powerDown2;

	public float timer=3;
	float currentTimeBABY;
	public GameObject deathText;

	float deathScore=150;
	public TextMesh textMesh;
	// Use this for initialization
	void Start () {
		
		rb=GetComponent<Rigidbody2D>();
		deathCounter = GameObject.Find ("Manager").GetComponent<GameManager> ();
		player = GameObject.Find ("Raven Player");
		cam = GameObject.Find ("Main Camera").GetComponent<CamControl> ();
		currentTimeBABY = timer;

	}
	
	// Update is called once per frame
	void Update () {
		//bullet = GameObject.FindGameObjectWithTag ("bullet");
		currentTimeBABY-=Time.deltaTime;
		if (dead == true) {
			
			Destroy (gameObject);
		}
		if (currentTimeBABY <= 0) {
			Instantiate (enemyBullet, transform.position, Quaternion.Euler (0, 0, Geo.ToAng (player.transform.position - transform.position)));
			currentTimeBABY = timer;
		}
	
	}
		void FixedUpdate(){
		if (player != null) {
			GameObject playerObj;
			Vector3 playerPos;
			playerObj = GameObject.FindWithTag ("Player"); 
			playerPos = playerObj.transform.position;
			Vector3 vel;
			vel = (playerPos - transform.position).normalized * spd / 2;
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
			cam.shakeCamera(.3f,.5f);
			Instantiate (enemyDeath, transform.position, Quaternion.identity);
			Instantiate (deathText, new Vector2(transform.position.x, transform.position.y+3), Quaternion.identity);
			Flasher.me.ScoreUp ();
			soundScript.me.Play (powerDown2);
		}
	}
}
