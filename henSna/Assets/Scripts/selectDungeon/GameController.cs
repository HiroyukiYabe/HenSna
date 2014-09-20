using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
				Debug.Log ("come start select dungeon");
	}
	
	// Update is called once per frame
	void Update () {
				Debug.Log ("come update22");
	}

		public void clickJapaneseDungeon(){
				Application.LoadLevel ("Field1_Japan");
		}

		public void clickBackButton(){
				Application.LoadLevel ("home");
		}
}
