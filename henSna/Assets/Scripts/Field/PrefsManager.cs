//Attach to GameController

using UnityEngine;
using System.Collections;
using System.IO;

public class PrefsManager : MonoBehaviour {
	
	int remainFilmNum;
	int takenPicNum=0;
	//int totalScore;

	int oneShotScore=0;
	int oneShotIndex=0;

	int screenshotIndex=0;

	// Use this for initialization
	void Awake () {
		SetTakenPicNum (0);
		//totalScore = 0;
		//SetTotalScore (0);
		remainFilmNum = 5;//PlayerPrefs.GetInt("filmNum");
		SetRemainFilmNum (remainFilmNum);
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

	/*public int GetTotalScore(){
		return totalScore;
	}
	public int SetTotalScore(int num){
		totalScore = num;
		PlayerPrefs.SetInt ("gotCoinNum", totalScore);
		return totalScore;
	}*/

	/*public void AddCoin(int _score){
		int _total = PlayerPrefs.GetInt ("havingCoin")+_score;
		PlayerPrefs.SetInt ("havingCoin", _total);
	}*/

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


	public void SetOneShotScore(int score){
		PlayerPrefs.SetInt ("picturePoint" + oneShotIndex, score);
		oneShotIndex++;
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
