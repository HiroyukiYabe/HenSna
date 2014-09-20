//現在の得点を保持、表示
//Attach to GameController or Score

using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int score;
	public GUIText ScoreText;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		ScoreText.text = "Score: "+score;
	}
}
