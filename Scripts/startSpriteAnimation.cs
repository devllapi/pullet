using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class startSpriteAnimation : MonoBehaviour {
	public Vector2 dir;
	public float spd;
	public Vector2 bulletPos;
	public Rigidbody2D rb;
	bool isDashing;
	bool move;
	public Button startButtonButton;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		spd = .001f;

		Button btn = startButtonButton.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			move = true;
		}
		if (move == true) {
			transform.position = new Vector2 (transform.position.x + spd, transform.position.y);
			spd=spd*1.5f;
			if (transform.position.x >= 10f) {
				SceneManager.LoadScene (1);
			}
		}
}

	void TaskOnClick(){
		move = true;
	}
			}
