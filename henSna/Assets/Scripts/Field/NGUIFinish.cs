using UnityEngine;
using System.Collections;

public class NGUIFinish : MonoBehaviour {

	UISprite sprite;
	LevelEnd levelEnd;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<UISprite>();
		sprite.alpha = 0.0f;
		levelEnd = GameObject.FindWithTag ("GameController").GetComponent<LevelEnd> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (levelEnd.isend) {
			if(sprite.alpha<1.0f)
				sprite.alpha += Time.deltaTime*2; 
		}
	}
}
