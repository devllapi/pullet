using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour {
	private GameObject[] music;
	void Awake() {
		DontDestroyOnLoad(gameObject);
	}
	// Use this for initialization
	void Start () {
		music = GameObject.FindGameObjectsWithTag ("gameMusic");
		if (music.Length > 0) {
			Destroy (music [1]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
