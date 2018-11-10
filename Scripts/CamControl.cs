using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {
    public float lerpAmnt;
    public Transform player;
    public Transform cursor;
    public float cursorOffsetScale;
	public bool enemyKill;
    Vector2 truePos;
	float shakeTimer;
	float shakeStrength; 
	// Use this for initialization
	void Start () {
		shakeStrength = 0; 
	}
	
	// Update is called once per frame
	void Update () {
     
		if (shakeTimer > 0) {
			transform.position += Random.insideUnitSphere * shakeStrength;
			shakeTimer -= Time.deltaTime;
		} else { 
			transform.position = new Vector3 (0f, 1.4f, -20);
		}
	}
	public void shakeCamera(float sa, float st){
		shakeTimer = st;		
		shakeStrength = sa;
	}
}
