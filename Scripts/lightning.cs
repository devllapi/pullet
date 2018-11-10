using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour {
	public GameObject player;
	Vector3 startPos;
	public Transform stopPoint;
	float step;
	bool moveLeft;
	// Use this for initialization
	void Start () {

		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		step = 5 * Time.deltaTime;
		if (transform.position.x > stopPoint.position.x && !moveLeft) {
			transform.position = Vector3.MoveTowards (transform.position, stopPoint.position, step);
		} else if (transform.position.x == stopPoint.position.x) {
			moveLeft = true;
		}
		if(moveLeft==true){
			transform.position = Vector3.MoveTowards (transform.position, startPos, step);
		}
		if(transform.position.x==startPos.x){
			moveLeft=false;
		}
	}

		
	}
		
		
	

