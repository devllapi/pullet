using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
	public GameObject enemy;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
	public float enemyCount;

	float timer;
	//public Vector3[] spawnPoints;
	// Use this for initialization
	void Start () {
		StartCoroutine (Spawn ());
//		StartCoroutine (Spawn2 ());
//		StartCoroutine (Spawn3 ());
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		enemyCount = GameObject.FindGameObjectsWithTag ("enemy").Length;
		timer += Time.deltaTime;

			//give each type of enemy its own timer variable
			//spawn1 timer starts at 0 then add to it (from 5 to 7)
	}

	IEnumerator Spawn(){
		if (enemyCount < 15) {
			yield return new WaitForSeconds (Random.Range (3, 5));
			Instantiate (enemy, transform.position, Quaternion.Euler (0, 0, transform.eulerAngles.z));
			yield return new WaitForSeconds (Random.Range (3, 5));
			Instantiate (enemy, transform.position, Quaternion.Euler (0, 0, transform.eulerAngles.z));
			Instantiate (enemy2, transform.position, Quaternion.Euler (0, 0, transform.eulerAngles.z));
			yield return new WaitForSeconds (4);
			Instantiate (enemy3, transform.position, Quaternion.Euler (0, 0, transform.eulerAngles.z));
			yield return new WaitForSeconds (Random.Range (3, 5));
			Instantiate (enemy2, transform.position, Quaternion.Euler (0, 0, transform.eulerAngles.z));
			Instantiate (enemy3, transform.position, Quaternion.Euler (0, 0, transform.eulerAngles.z));
			Instantiate (enemy4, transform.position, Quaternion.Euler (0, 0, transform.eulerAngles.z));
			yield return new WaitForSeconds (Random.Range (3, 5));
			Instantiate (enemy, transform.position, Quaternion.Euler (0, 0, transform.eulerAngles.z));
			Instantiate (enemy2, transform.position, Quaternion.Euler (0, 0, transform.eulerAngles.z));
			Instantiate (enemy3, transform.position, Quaternion.Euler (0, 0, transform.eulerAngles.z));
			yield return new WaitForSeconds (5);
			Instantiate (enemy4, transform.position, Quaternion.Euler (0, 0, transform.eulerAngles.z));
			Instantiate (enemy4, transform.position, Quaternion.Euler (0, 0, transform.eulerAngles.z));
			Instantiate (enemy4, transform.position, Quaternion.Euler (0, 0, transform.eulerAngles.z));

			StartCoroutine (Spawn ());
		}
	}
//	IEnumerator Spawn2(){
//		
//			yield return new WaitForSeconds (Random.Range (7, 10));
//			Instantiate (enemy2, transform.position, Quaternion.Euler (0, 0, transform.eulerAngles.z));
//			
//
//			StartCoroutine (Spawn2 ());
//
//	}
//	IEnumerator Spawn3(){
//		
//			yield return new WaitForSeconds (Random.Range (13, 15));
//			Instantiate (enemy3, transform.position, Quaternion.Euler (0, 0, transform.eulerAngles.z));
//
//			StartCoroutine (Spawn3 ());
//
//		}
	}

