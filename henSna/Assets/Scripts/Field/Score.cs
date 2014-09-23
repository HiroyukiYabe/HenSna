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
	int oneShotScore;

	// Use this for initialization
	void Start () {
		score = 0;
		prefs = GameObject.FindWithTag ("GameController").GetComponent<PrefsManager> ();
		charNum = GameObject.FindGameObjectsWithTag ("Character").Length;
		Debug.Log ("Character is " + charNum);
		count = 0;
		oneShotScore = 0;
	}


	// Update is called once per frame
	void Update () {
		ScoreText.text = "Score: "+score;
	}


	public void AddScore(int _score){
		oneShotScore += _score;
		score += _score;
		count++;
		Debug.Log ("Score.AddScore called");
		if (count == charNum) {
			prefs.SetOneShotScore(oneShotScore);
			Debug.Log("This Photo's Score is " + oneShotScore);
			oneShotScore=0;
			count=0;
		} else if (count > charNum) {
			Debug.LogError("Score Error!!");
		}
	}

}
