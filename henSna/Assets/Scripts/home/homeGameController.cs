using UnityEngine;
using System.Collections;
using System;
public class homeGameController : MonoBehaviour {

	// Use this for initialization
		string lastFilmUpTimeStr;
		void Start () {
				if (PlayerPrefs.GetInt ("firstLaunch2") == 0) {
						//初回起動
						Debug.Log ("come first launch!!!");
						PlayerPrefs.SetInt ("filmMax",20);
						PlayerPrefs.SetInt ("filmNum",5);
						PlayerPrefs.SetInt ("havingCoin",300);
						PlayerPrefs.SetInt ("releaseHalloweenDungeon",0);
						PlayerPrefs.SetInt ("valuationChief",0);
						PlayerPrefs.SetInt ("userLevel",1);
						lastFilmUpTimeStr = DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss");
						PlayerPrefs.SetString ("lastFilmUpTime",lastFilmUpTimeStr);
						PlayerPrefs.SetInt ("firstLaunch2",1);
				}
		}
	
	// Update is called once per frame
		void Update () {
				DateTime nowTime = DateTime.Now;
				lastFilmUpTimeStr = PlayerPrefs.GetString ("lastFilmUpTime");
				DateTime lastFilmUpTime = DateTime.Parse (lastFilmUpTimeStr);
				TimeSpan timeSpan = nowTime - lastFilmUpTime;
				int spanMinutes = timeSpan.Minutes;
				if (spanMinutes >= 1) {

						int filmNum = PlayerPrefs.GetInt ("filmNum");
						int filmMax = PlayerPrefs.GetInt ("filmMax");

						if (filmNum < filmMax) {
								Debug.Log ("come film up!");
								filmNum++;
								PlayerPrefs.SetInt ("filmNum",filmNum);
						}
						PlayerPrefs.SetString ("lastFilmUpTime",DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss"));
				}
		}


		public void clickPlayButton(){
				Debug.Log("click PlayButton");
				Application.LoadLevel("selectDungeon");
		}

		public void clickSettingButton(){
				Application.LoadLevel("setting");
		}

		public void clickSoundButton(){
				Debug.Log ("click sound button");
		}

		public void clickPurchaseItemButton(){
				Application.LoadLevel("purchaseItem");
		}

		public void clickCollectionButton(){
				Application.LoadLevel("collection");
		}
}
