//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class raycastTest : MonoBehaviour {
//	float minWallDist;
//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		if(Input.GetKeyDown(KeyCode.UpArrow)){
//			float curThrust;
//			RaycastHit2D ray = Physics2D.Raycast (transform.position, -transform.up * minWallDist, minWallDist, LayerMask.GetMask ("Terrain")); //minWallDist is the distance the ray is travelling
//				if(ray){
//				curThrust+=bonusThrust * (1-ray.fraction);//the further the distance, the smaller the value of 1-ray.fraction
//
//
//				}
//	} 
//}
//