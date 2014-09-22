using UnityEngine;
using System.Collections;

public class PrefsManager : MonoBehaviour {
	
	int remainFilmNum;
	int takenPicNum;
	int score;
	int totalScore;

	// Use this for initialization
	void Start () {
		takenPicNum = 0;
		SetTakenPicNum (0);
		score = 0;
		SetScore (0);
		remainFilmNum = PlayerPrefs.GetInt("filmNum");
	}
	
	// Update is called once per frame
	void Update () {}

	public int GetRemainFilmNum(){
		return remainFilmNum;
	}
	public int SetRemainFilmNum(int num){
		remainFilmNum = num;
		PlayerPrefs.SetInt ("filmNum", remainFilmNum);
		return remainFilmNum;
	}

	public int GetTakenPicNum(){
		return takenPicNum;
	}
	public int SetTakenPicNum(int num){
		takenPicNum = num;
		PlayerPrefs.SetInt ("tookPictureNum", takenPicNum);
		return takenPicNum;
	}

	public int GetScore(){
		return score;
	}
	public int SetScore(int num){
		score = num;
		PlayerPrefs.SetInt ("gotCoinNum", score);
		return score;
	}

	public void AddTotalScore(int _score){
		int _total = PlayerPrefs.GetInt ("havingCoin")+_score;
		PlayerPrefs.SetInt ("havingCoin", _total);
	}

	public void StorePhoto(){

	}

}
