using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : MonoBehaviour {
	int health=1;
	bool dead;
	public GameObject enemyBullet;
	GameObject player;
	public static int score;
	public float spd;
	Rigidbody2D rb;
	CamControl cam;
	 GameManager deathCounter;

	public GameObject enemyDeath;
	public AudioClip bigPowerDown;
	public GameObject deathText;

	float deathScore=500;
	public TextMesh textMesh;
	// Use this for initialization
	void Start () {
		//StartCoroutine (Shoot ());
		rb=GetComponent<Rigidbody2D>();
		deathCounter = GameObject.Find ("Manager").GetComponent<GameManager> ();
		player = GameObject.Find ("Raven Player");
		cam = GameObject.Find ("Main Camera").GetComponent<CamControl> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			transform.eulerAngles = new Vector3 (0, 0, Geo.ToAng (player.transform.position - transform.position));
		}
		if (dead == true) {
			
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
			if(Vector2.Distance(transform.position, playerPos)>5f){
			vel = (playerPos - transform.position).normalized * spd / 2;
			}else{
				vel=(playerPos-transform.position).normalized*spd*1.5f;
			}
			rb.MovePosition (transform.position + vel); 
		}
	}
//		IEnumerator Shoot() {
//			if (!dead) {
//				yield return new WaitForSeconds (Random.Range (2f, 4f));
//				Instantiate (enemyBullet, transform.position, Quaternion.Euler (0, 0, Geo.ToAng (player.transform.position - transform.position)));
//				StartCoroutine (Shoot ());
//			}
//		}
		
	
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
			cam.shakeCamera(.5f,.5f);
			Instantiate (enemyDeath, transform.position, Quaternion.identity);
			Instantiate (deathText, new Vector2(transform.position.x, transform.position.y+3), Quaternion.identity);

			Flasher.me.ScoreUp ();
			soundScript.me.Play (bigPowerDown);
		}
	}
}
