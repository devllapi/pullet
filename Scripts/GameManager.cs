using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
	public float playerScore;
	public Text scoreText;
	public Text comboText;
	public Text restartText;
	public Text gameOver;

	public GameObject player;
	public AudioSource ravenProxy;
	public GameObject[] spikes;
	GameObject[] enemies;
	float timer;

	public bool comboIsActive;
	int comboTimer = 3;
	float currentComboTimer;

	public TextMesh textMesh;
	public static GameManager me;

	private float timeAlive;

	float restartGameTimer=1;

	public int killCount;
	// Use this for initialization
	void Start () {
		timeAlive = 0f;

		if (me == null) {
			me = this;
		} else {
			Destroy (this.gameObject);
		}
		//ravenProxy.time = 50;
		//ravenProxy.Play ();
		spikes[0].SetActive(false);
		spikes[1].SetActive(false);
		spikes[2].SetActive(false);
		spikes[3].SetActive(false);
		spikes[4].SetActive(false);
		spikes[5].SetActive(false);
		spikes[6].SetActive(false);
		spikes[7].SetActive(false);
		timer = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if (playerScore == 0) {
			restartText.text = "PULLET";
		} else {
			restartText.text = playerScore.ToString ();
		}
		scoreText.text = "High Score: "+ PlayerPrefs.GetInt("High Score").ToString();

		if (currentComboTimer > 0) {
			currentComboTimer -= Time.deltaTime;
			comboIsActive = true;
			//textMesh.text = "+200!";
			comboText.text = Mathf.RoundToInt (currentComboTimer).ToString ();
		} else {
			//textMesh.text = "+100!";
		}
		if (currentComboTimer <= 0) {
			currentComboTimer = Mathf.Max (currentComboTimer, 0);
			comboIsActive = false;

		}

//		if (currentComboTimer > 0) {
//			restartText.text = "DOUBLE POINTS";
//		} else {
//			restartText.text = "PULLET"; 
//		}

		timer += Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.R)) {
			timer = 0;
		}
		if (player == null) {
			gameOver.text = "GAME OVER";
			restartGameTimer -= Time.deltaTime;
			print ("the timer is" + restartGameTimer);
		}

		if (restartGameTimer <= 0) {
			SceneManager.LoadScene (1);
		}
	
		if (timer >= 4) {
			spikes [0].SetActive (true);
		}
		if (timer >= 8) {
			spikes [1].SetActive (true);
		}
		if (timer >= 10) {
			spikes [2].SetActive (true);
		}
		if (timer >= 12) {
			spikes [3].SetActive (true);
		}
		if (timer >= 16) {
			spikes [4].SetActive (true);
			spikes [5].SetActive (true);
			spikes [6].SetActive (true);
			spikes [7].SetActive (true);
		}

		timeAlive += 1 * Time.deltaTime;


//		if (playerScore >= 10) {
//			if (Input.GetKeyDown (KeyCode.E)) {
//				enemies = GameObject.FindGameObjectsWithTag ("enemy");
//				for(int i=0; i<enemies.Length;i++){
//					Destroy (enemies[i]);
//				playerScore = 0;
//			}
//		}
//
//	}
		if (PlayerPrefs.HasKey ("High Score")) {
			if (PlayerPrefs.GetInt ("High Score") < playerScore)
				PlayerPrefs.SetInt ("High Score", (int)playerScore);
		} else
			PlayerPrefs.SetInt ("High Score", (int)playerScore);
	}



	public void ResetComboTimer(){
		restartText.text = "";
		currentComboTimer = comboTimer;
	}
}