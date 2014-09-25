using UnityEngine;
using System.Collections;

public class NGUICenter : MonoBehaviour {

	UISprite sprite;
	LevelEnd levelEnd;
	
	// Use this for initialization
	void Start () {
		sprite = GetComponent<UISprite>();
		sprite.alpha = 1.0f;
		levelEnd = GameObject.FindWithTag ("GameController").GetComponent<LevelEnd> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (levelEnd.isend || Pauser.isPause) {
			sprite.alpha = 0f; 
		}else sprite.alpha = 1f;
	}
}
