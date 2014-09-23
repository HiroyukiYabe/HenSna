using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

	bool end;
	PrefsManager prefs;
	Score _score;

	// Use this for initialization
	void Start () {
		prefs = GetComponent<PrefsManager> ();
		_score = GetComponent<Score> ();
		end = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (prefs.GetRemainFilmNum() == 0) {
			end =true;
			//Invoke("levelEnd", 5);
		}
	}

	void  levelEnd(){
		//To Do
		prefs.SetTotalScore (_score.score);
		prefs.AddCoin (_score.score);
		Application.LoadLevel("pictureSubmit");
	}

	void OnGUI (){
		if (end)
			if(GUI.Button(new Rect(Screen.width/2-100,Screen.height/2-50,200,100),"FINISHED!!")) Invoke("levelEnd", 3);
	}

}
