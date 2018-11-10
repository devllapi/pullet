using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Flasher : MonoBehaviour {
    bool flashing;
    int flashTimer;
    public int flashLength;
    public int flashRate;
    public Text txt;
    Color defCol;
	GameManager deathCounter;

	public static Flasher me;
    // Use this for initialization
    void Start () {
		//txt = GetComponent<Text>();
		defCol = txt.color;
		flashTimer = 999;
		deathCounter = GameObject.Find ("Manager").GetComponent<GameManager> ();
		me = this;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
		
        if (flashTimer < flashLength) {
            if (flashTimer % (flashRate * 2) > flashRate) {
				txt.color = Color.white;
            } else {
				txt.color = Color.red;
            }
        } else {
			txt.color = defCol;
        }
        flashTimer++;
    }

    public void ScoreUp() {
        flashTimer = 0;
    }
}
