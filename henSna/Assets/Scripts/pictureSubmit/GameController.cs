using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		public void clickGoResultButton(){
				Debug.Log ("clickGoResultButton");
				Application.LoadLevel ("result");
		}
}
