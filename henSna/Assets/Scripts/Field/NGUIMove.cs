using UnityEngine;
using System.Collections;

public class NGUIMove : MonoBehaviour {

	UISprite sprite;
	TapDetect tapDetect;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<UISprite>();
		sprite.alpha = 0.0f;
		tapDetect = GameObject.FindWithTag ("GameController").GetComponent<TapDetect> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (tapDetect.stat == TapDetect.status.Move)
						sprite.alpha = 1.0f;
				else
						sprite.alpha = 0.0f;
	
	}
}
