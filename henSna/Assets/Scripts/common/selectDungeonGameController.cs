using UnityEngine;
using System.Collections;
using System;

public class selectDungeonGameController : MonoBehaviour {
		TimeSpan timeSpan;
	// Use this for initialization
	void Start () {
				PlayerPrefs.SetInt ("test",1);
				Debug.Log ("come start select dungeon");
	}
	
	// Update is called once per frame
	void Update () {
				Debug.Log ("come update select dungeon");

	}

		public void clickJapaneseDungeon(){
				Application.LoadLevel ("Field1_Japan");
		}

		public void clickBackButton(){
				Application.LoadLevel ("home");
		}
}
