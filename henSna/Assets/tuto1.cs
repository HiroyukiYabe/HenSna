using UnityEngine;
using System.Collections;

public class tuto1 : MonoBehaviour {

	UISprite tex;

	float timer;
	float interval;

	// Use this for initialization
	void Start () {
		timer = 0f;
		tex = GetComponent<UISprite>();
		tex.alpha = 0f;
		interval = 5;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer>1)
			tex.alpha = 1f;
		if (timer > interval)
						Destroy (this.gameObject);
			
	}
}
