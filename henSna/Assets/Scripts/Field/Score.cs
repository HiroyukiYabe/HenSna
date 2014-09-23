//現在の得点を保持、表示
//Attach to GameController

using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int score;
	public GUIText ScoreText;

	PrefsManager prefs;

	int charNum;
	int count;
	int onePhotoScore;

	// Use this for initialization
	void Start () {
		score = 0;
		prefs = GameObject.FindWithTag ("GameController").GetComponent<PrefsManager> ();
		charNum = GameObject.FindGameObjectsWithTag ("Character").Length;
		Debug.Log ("Character is " + charNum);
		count = 0;
		onePhotoScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		ScoreText.text = "Score: "+score;
	}

	void AddScore(int _score){
		onePhotoScore += _score;
		count++;
		if (count == charNum) {

			onePhotoScore=0;
			count=0;
		} else if (count > charNum) {
			Debug.LogError("Score Error!!");
		}
	}

}
