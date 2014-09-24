//Attach to GameController

//ポーズ対応


using UnityEngine;
using System.Collections;
using System.IO;

public class PrefsManager : MonoBehaviour {
	
	int remainFilmNum;
	int takenPicNum=0;

	int havingCoin;

	//int oneShotScore=0;
	int oneShotIndex=0;
	int screenshotIndex=0;

	// Use this for initialization
	void Awake () {
		SetTakenPicNum (0);
		SetTotalScore (0);
		remainFilmNum = 10;//PlayerPrefs.GetInt("filmNum"); //For Debug
		SetRemainFilmNum (remainFilmNum);
		havingCoin = PlayerPrefs.GetInt("havingCoin");
	}
	
	// Update is called once per frame
	//void Update () {}

	//フィルム残数
	public int GetRemainFilmNum(){
		return remainFilmNum;
	}
	public int SetRemainFilmNum(int num){
		remainFilmNum = num;
		PlayerPrefs.SetInt ("filmNum", remainFilmNum);
		return remainFilmNum;
	}

	//現在の撮影枚数
	public int GetTakenPicNum(){
		return takenPicNum;
	}
	public int SetTakenPicNum(int num){
		takenPicNum = num;
		PlayerPrefs.SetInt ("tookPictureNum", takenPicNum);
		return takenPicNum;
	}

	//そのゲームでの獲得金額
	public int GetTotalScore(){
		return PlayerPrefs.GetInt ("gotCoinNum");
	}
	public int SetTotalScore(int _totalScore){
		PlayerPrefs.SetInt ("gotCoinNum", _totalScore);
		return _totalScore;
	}

	//所持金の増減
	public void AddCoin(int  coin){
		havingCoin = PlayerPrefs.GetInt ("havingCoin")+coin;
		PlayerPrefs.SetInt ("havingCoin", havingCoin);
	}
	public bool SubtractCoin(int coin){
		int now = PlayerPrefs.GetInt ("havingCoin");
		if (now >= coin) {
			havingCoin = now - coin;
			PlayerPrefs.SetInt ("havingCoin", havingCoin);
			return true;
		} else
			return false;
	}
	public int GetHavingCoin(){
		return havingCoin;
	}

	//操作UIの状態
	public string GetUIController(){
		//0 is UpDown,  1 is RightLeft
		int setting = PlayerPrefs.GetInt("playerUIController");
		if(setting==0) return "UpDown";
		else if(setting==1) return "RightLeft";
		else return "Error";
	}
	public void SetUIController(string setting){
		//0 is UpDown,  1 is RightLeft
		switch(setting){
		case "UpDown":
			PlayerPrefs.SetInt("playerUIController",0);
			break;
		case "RightLeft":
				PlayerPrefs.SetInt("playerUIController",1);
			break;
		default :
			Debug.LogError("PrefsManager: SetUI Error");
			break;
		}
	}

	//キャラクターが撮影されたことがあるか
	public void SetGotCharacter(string name, bool isGotten=true){
		if (isGotten && PlayerPrefs.GetInt ("got"+name) == 0)
						PlayerPrefs.SetInt ("got"+name, 1);
	}

	//To Do
	//最初に撮影されたキャラクター
	public void SetThisTimeGotType(string name){
		if (PlayerPrefs.GetInt ("thisTimeGotType") == 0) {
			switch(name){
			case "Pumpkin":
				PlayerPrefs.SetInt ("thisTimeGotType",1);
				break;
			case "Skelton":
				PlayerPrefs.SetInt ("thisTimeGotType",2);
				break;
			case "Knight":
				PlayerPrefs.SetInt ("thisTimeGotType",3);
				break;
			case "Mummy":
				PlayerPrefs.SetInt ("thisTimeGotType",4);
				break;
			default :
				Debug.LogError("PrefsManager.SetThisTimeGotType:  Not Defined Character");
				break;
			}
		}
	}

	//写真一枚ごとの点数
	public void SetOneShotScore(int score){
		PlayerPrefs.SetInt ("picturePoint" + oneShotIndex, score);
		oneShotIndex++;
	}

	//アイテム所持数
	/*public int GetItemNum(string itemName){
		switch (itemName) {
		case "Food":
			return PlayerPrefs.GetInt("itemFoodNum");
		default :
			Debug.LogError("PrefsManager: Selected Item does not Exist!!");
			return 0;
		}
	}
	public void SetItemNum(string itemName,int num){
		switch (itemName) {
		case "Food":
			PlayerPrefs.SetInt("itemFoodNum",num);
			break;
		default :
			Debug.LogError("PrefsManager: Selected Item does not Exist!!");
			break;
		}
	}*/


	//スクリーンショットの保存
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
