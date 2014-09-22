//Attach to GameController

using UnityEngine;
using System.Collections;

public class PrefsManager : MonoBehaviour {
	
	int remainFilmNum;
	int takenPicNum;
	int score;
	int totalScore;

	// Use this for initialization
	void Awake () {
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

	public string GetUIController(){
		//0 is UpDown,  1 is RightLeft
		int setting = PlayerPrefs.GetInt("playerUIController");
		if(setting==0) return "UpDown";
		else if(setting==1) return "RightLeft";
		else return "Error";
	}

	public void StorePhoto(){

	}

}
