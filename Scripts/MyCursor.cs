﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCursor : MonoBehaviour {
    Camera cam;
	public Transform perch;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
	}
	
	// Update is called once per frame
	void Update () {
		

        transform.position = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
		
}

}