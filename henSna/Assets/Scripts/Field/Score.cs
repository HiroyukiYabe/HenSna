//現在の得点を保持、表示
//Attach to GameController

//ポーズ対応必要なし

using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int score;

	PrefsManager prefs;

	public int charNum;
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
	//void Update () {}


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
