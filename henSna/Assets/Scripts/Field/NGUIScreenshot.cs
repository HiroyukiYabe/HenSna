using UnityEngine;
using System.Collections;

public class NGUIScreenshot : MonoBehaviour {

	GUITexture thisTex;

	// Use this for initialization
	void Start () {
		thisTex = GetComponent<GUITexture> ();
		Color c = thisTex.color;
		c.a = 0f;
		thisTex.color = c;
	}
	
	// Update is called once per frame
	//void Update () {}

	public void ShowScreenshot(){
		Color c = thisTex.color;
		c.a = 1f;
		thisTex.color = c;
		Invoke ("Disappear", 5);
	}
	void Disappear(){
		Color c = thisTex.color;
		c.a = 0f;
		thisTex.color = c;
	}

}
