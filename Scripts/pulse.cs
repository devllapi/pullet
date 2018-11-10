using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulse : MonoBehaviour {
	float startScale;
	// Use this for initialization
	void Start () {
		
		startScale = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		
		//print (Time.time);
		float scaleX = (Mathf.Cos(Time.time * (128 / 60) * Mathf.PI * 2));
//		float scaleYZ= .5f+ Mathf.Cos(Time.time * (128 / 60) * Mathf.PI * 2);
	

		transform.localScale = new Vector2 (scaleX+startScale, transform.localScale.y);

		if (this.gameObject.tag == "text") {
			transform.localScale = new Vector2 (scaleX+startScale, scaleX+transform.localScale.y);

		}
//			if (transform.localRotation.z == 90) {
//				transform.localScale = new Vector2 (scaleX, transform.localScale.y);
//			}
		}

		}

			
	

