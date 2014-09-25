using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

	public bool isend;
	PrefsManager prefs;
	Score _score;

	// Use this for initialization
	void Start () {
		prefs = GetComponent<PrefsManager> ();
		_score = GetComponent<Score> ();
		isend = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (prefs.GetRemainFilmNum() == 0) {isend =true;}
		if(isend) Invoke("levelEnd", 2);
	}

	public void levelEnd(){
		prefs.SetTotalScore (_score.score);
		prefs.AddCoin (_score.score);

		if(prefs.GetTakenPicNum() > 0)
			Application.LoadLevel("pictureSubmit");
		else Application.LoadLevel("result");
	}

}
