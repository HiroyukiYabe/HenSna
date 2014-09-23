//Attach to GameController

using UnityEngine;
using System.Collections;
using System.IO;

public class PrefsManager : MonoBehaviour {
	
	int remainFilmNum;
	int takenPicNum;
	int score;
	int totalScore;
	int screenshotIndex;

	// Use this for initialization
	void Awake () {
		takenPicNum = 0;
		SetTakenPicNum (0);
		score = 0;
		SetScore (0);
		remainFilmNum = 10;//PlayerPrefs.GetInt("filmNum");
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


	public void SetGotCharacter(string name, bool isGotten=true){
		if (isGotten && PlayerPrefs.GetInt ("got"+name) == 0)
						PlayerPrefs.SetInt ("got"+name, 1);
	}


	public void CaptureScreenshot(){
		// Screenshot を撮る
		string screenshotName = "Screenshot" + screenshotIndex + ".png";
		Application.CaptureScreenshot (screenshotName);
		
		// プラットフォームごとに保存位置変わる？
		/*string path = "";
		switch (Application.platform) {
		case RuntimePlatform.IPhonePlayer:
			path = Application.persistentDataPath + "/" + screenshotName;
			break;
		case RuntimePlatform.Android:
			path = Application.persistentDataPath + "/" + screenshotName;
			break;
		default:
			path = screenshotName;
			break;
		}
		Debug.Log("path:"+path);

		while (!System.IO.File.Exists (path) ) {
			//Debug.Log(">>>>> Temporary Screenshot have not been written yet.");
		}

		// スクリーンショットの読み込み
		byte[] image = File.ReadAllBytes(path);
		
		// Texture2D を作成して読み込み
		Texture2D tex = new Texture2D(0, 0);
		tex.LoadImage(image);
		
		// NGUI の UITexture に表示するとき
		UITexture target = GameObject.Find("Screenshot").GetComponent<UITexture>();
		target.mainTexture = tex;*/

		screenshotIndex++;
	}

}
