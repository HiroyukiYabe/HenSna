using UnityEngine;
using System.Collections;
using System;

public class homeGameController : MonoBehaviour
{
	// Use this for initialization
	string lastFilmUpTimeStr;
	UISprite chiefMessage;
	void Start ()
	{
		if (PlayerPrefs.GetInt ("firstLaunch3") == 0) {
			//初回起動
			Debug.Log ("come first launch!!!");
			PlayerPrefs.SetInt ("filmMax", 50);
			PlayerPrefs.SetInt ("filmNum", 50);
			PlayerPrefs.SetInt ("havingCoin", 300);
			PlayerPrefs.SetInt ("releaseHalloweenDungeon", 0);
			PlayerPrefs.SetInt ("valuationChief", 0);
			PlayerPrefs.SetInt ("userLevel", 1);
			PlayerPrefs.SetInt ("gotCoinNum", 0);
			PlayerPrefs.SetInt ("playerUIController", 1);
			PlayerPrefs.SetInt ("tookPictureNum", 0);
			lastFilmUpTimeStr = DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss");
			PlayerPrefs.SetString ("lastFilmUpTime", lastFilmUpTimeStr);
			PlayerPrefs.SetInt ("firstLaunch3", 1);
		}
		PlayerPrefs.SetInt ("playerUIController", 1);
		chiefMessage = GameObject.Find ("chiefMessage").gameObject.GetComponent<UISprite> ();
		int seed = Environment.TickCount;
		System.Random rnd = new System.Random(seed++);
		int messageType = rnd.Next(3);


		switch (messageType) {
		case 0:
			chiefMessage.spriteName = "chiefMessage0";
			break;
		case 1:
			chiefMessage.spriteName = "chiefMessage1";
			break;
		case 2:
			chiefMessage.spriteName = "chiefMessage2";
			break;
		case 3:
			chiefMessage.spriteName = "chiefMessage3";
			break;
		default:
			chiefMessage.spriteName = "chiefMessage0";
			break;
		}
	}
	// Update is called once per frame
	/*void Update ()
	{
		DateTime nowTime = DateTime.Now;
		lastFilmUpTimeStr = PlayerPrefs.GetString ("lastFilmUpTime");
		DateTime lastFilmUpTime = DateTime.Parse (lastFilmUpTimeStr);
		TimeSpan timeSpan = nowTime - lastFilmUpTime;
		int spanMinutes = timeSpan.Minutes;
		if (spanMinutes >= 1) {
			Debug.Log ("come film up! home");
			int filmNum = PlayerPrefs.GetInt ("filmNum");
			int filmMax = PlayerPrefs.GetInt ("filmMax");
			filmNum += spanMinutes;
			if (filmNum > filmMax) {
				filmNum = filmMax;
			}
			PlayerPrefs.SetInt ("filmNum", filmNum);
			PlayerPrefs.SetString ("lastFilmUpTime", DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss"));
		}
	}*/

	public void clickPlayButton ()
	{
		Debug.Log ("click PlayButton");
		Application.LoadLevel ("selectDungeon");
	}

	public void clickSettingButton ()
	{
		Application.LoadLevel ("setting");
	}

	public void clickSoundButton ()
	{
		Debug.Log ("click sound button");
	}

	public void clickPurchaseItemButton ()
	{
		Application.LoadLevel ("purchaseItem");
	}

	public void clickCollectionButton ()
	{
		Application.LoadLevel ("collection");
	}
}
