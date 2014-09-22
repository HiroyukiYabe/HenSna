using UnityEngine;
using System.Collections;
using System;
public class resultGameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clickGoHomeButton(){
		Debug.Log ("click goHomeButton!!");
		Application.LoadLevel ("home");
	}
}
