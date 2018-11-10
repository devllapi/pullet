using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class startButton : MonoBehaviour {
	public Button theButton;
	public AudioSource startSound;
	// Use this for initialization
	void Start () {
		Button btn = theButton.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void TaskOnClick(){
		startSound.Play ();
		//SceneManager.LoadScene (1);
	}

}
