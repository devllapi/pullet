using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {
	public Rigidbody2D rb; 
	Vector2 velocity;
	public float maxSpeed;
	public float accel;
	public Transform perchPoint;

	public float jumpHeight;
	public float jumpTimer=1;
	float jumpTime;
	public float fallGravity;
	public float jumpGravity;


	public bool grounded;
	BoxCollider2D box;
	Vector2[] debugPts;


	public GameObject bullet;
	public Transform cursor;
	public int bulletCount=0;
	int totalBullets=1;
	bool pause;

	Vector3 startPos;
	public GameObject shield;
	public Bullet bulletScript;

	//gabe's dash initialization
	public bool isDashing = false;
	public float dashDur = 1f;
	public float dashSpeed = 5f;
	private float dashTimer = 0f;
	Vector2 dashVector = Vector2.zero;

	public Vector2 dir;
	public float spd;
	GameObject bigBulletBOI;
	Vector2 bulletPos;

	public soundScript sounds;
	public AudioClip shot;
	public AudioClip dashSound;
	public AudioClip deathSound;
	public GameObject death;
	public AudioClip pullBack;

	public float timeAlive;

	public GameObject dashEffect;
	CamControl cam;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		box = GetComponent<BoxCollider2D> ();
		debugPts = new Vector2[2];

		cam = GameObject.Find ("Main Camera").GetComponent<CamControl> ();
		//timeAlive = 0;
	}
	void Update(){
		
		timeAlive += 1 * Time.deltaTime;
		print ("this is the timealive" + timeAlive);

		bulletCount = GameObject.FindGameObjectsWithTag ("bullet").Length;
		//print ("is dashing" + isDashing);
		if (bulletCount == 1) {
			bulletPos = bigBulletBOI.transform.position;
		}
		if (Input.GetMouseButtonDown (0)) {
			cam.shakeCamera (.1f, .1f);


			if (bulletCount==0) {
				bulletCount++;
				bigBulletBOI= Instantiate (bullet, transform.position + ((cursor.position - transform.position).normalized * 2f), Quaternion.Euler (0, 0, Geo.ToAng (cursor.position - transform.position)));
				bulletPos = bigBulletBOI.transform.position;
				sounds.Play (shot, .75f);
			}
		}

		//print (bulletPos);
		if (Input.GetMouseButtonDown(1)&&bulletCount==1) {
			bulletCount = 0;
			cam.shakeCamera (.3f, .3f);
			sounds.Play (pullBack, .75f);
		}

		dir = (bulletPos - (Vector2)transform.position).normalized;

		if (Input.GetKeyDown (KeyCode.Space) && isDashing == false && bulletCount > 0) {
			isDashing = true;
			soundScript.me.Play (dashSound);
			Instantiate (dashEffect, transform.position, Quaternion.identity);

		} 
		if (Vector2.Distance(bulletPos, transform.position)==0 && isDashing==true) {

			isDashing = false;

		}
	

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		bool rightButton = Input.GetKey (KeyCode.D);
		bool leftButton = Input.GetKey (KeyCode.A);
		bool upButton = Input.GetKey (KeyCode.W);
		bool downButton = Input.GetKey (KeyCode.S);
		bool mouseClick = Input.GetKeyDown (KeyCode.Mouse1);

		if (rightButton&&isDashing==false) {
			velocity.x += accel;
			//print ("right");
			//facing = 1;
		}
		if (leftButton&&isDashing==false) {
			velocity.x -= accel;
			//facing = -1;
		}
		if (!rightButton && !leftButton) {
			velocity.x = 0;
		}
		if (upButton&&isDashing==false) {
			velocity.y += accel;
		}
		if (downButton&&isDashing==false) {
			velocity.y -= accel;
		}
			if (!upButton && !downButton) {
				velocity.y = 0;
			}
			
					

		float mx = maxSpeed;
		velocity.x = Mathf.Max(Mathf.Min(velocity.x, mx), -mx);
		velocity.y=Mathf.Max(Mathf.Min(velocity.y,mx), -mx);
		if (isDashing == true) {
			rb.MovePosition ((Vector2)transform.position + (dir * spd*5));
			gameObject.layer=10;

			//GetComponent<Renderer> ().material.color = Color.black;
		} else if(isDashing==false) {
			rb.MovePosition ((Vector2)transform.position + velocity);
			gameObject.layer = 16;
			GetComponent<Renderer> ().material.color = Color.white;
		}

	}


	void OnCollisionEnter2D (Collision2D col){
		if ((col.gameObject.tag == "enemy")&&(gameObject.layer==16)) {
			Tinylytics.AnalyticsManager.LogCustomMetric ("Time Alive A", timeAlive.ToString ());
			Tinylytics.AnalyticsManager.LogCustomMetric ("Score A", GameManager.me.playerScore.ToString ());
			Tinylytics.AnalyticsManager.LogCustomMetric ("Kill Count A", GameManager.me.killCount.ToString ());
			Destroy(gameObject);
			Instantiate (death, transform.position, Quaternion.identity);
			cam.shakeCamera (.9f, .9f);
			sounds.Play (deathSound);
		}
		if ((col.gameObject.tag == "shield") || (col.gameObject.tag== "spikes")){
			Tinylytics.AnalyticsManager.LogCustomMetric ("Time Alive A", timeAlive.ToString ());
			Tinylytics.AnalyticsManager.LogCustomMetric ("Score A", GameManager.me.playerScore.ToString ());
			Tinylytics.AnalyticsManager.LogCustomMetric ("Kill Count A", GameManager.me.killCount.ToString ());

			Destroy (gameObject);
			Instantiate (death, transform.position, Quaternion.identity);
			sounds.Play (deathSound);
			cam.shakeCamera (.9f, .9f);

		}
		if (col.gameObject.tag == "enemy" && (gameObject.layer == 10)) {
			col.gameObject.SendMessage ("OnShot", null, SendMessageOptions.DontRequireReceiver);

		}
		}
	void OnTriggerEnter2D (Collider2D trigger){

		Destroy (gameObject);
		Instantiate (death, transform.position, Quaternion.identity);
		soundScript.me.Play (deathSound);
		print (trigger.gameObject.tag);
	}
	
	

//	void SetGrounded() {
//		Vector2 pt1 = transform.TransformPoint(box.offset + new Vector2(box.size.x / 2, -box.size.y / 2));//(box.size / 2));
//		Vector2 pt2 = transform.TransformPoint(box.offset - (box.size / 2) + new Vector2(0, 0));
//		debugPts[0] = pt1;
//		debugPts[1] = pt2;
//		grounded = Physics2D.OverlapArea(pt1, pt2, LayerMask.GetMask("Platform")) != null;
//
//		if (grounded) {
//			
//			velocity.y = 0;
//
//		}
//	}
}
