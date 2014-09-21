using UnityEngine;
using System.Collections;
using System;

public class GameControllerCommon : MonoBehaviour {
		TimeSpan timeSpan;
	// Use this for initialization
	void Start () {
				Debug.Log ("come Start GameControllerCommon");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void OnApplicationPause(bool pauseStatus){
				if (pauseStatus) {
						string nowTime;
						nowTime = DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss");
						PlayerPrefs.SetString ("pauseTime",nowTime);
						PlayerPrefs.SetInt ("pause",1);
						Debug.Log ("nowTime is " + nowTime);
						Debug.Log ("application will resign active or on pause");
				} else {
						DateTime lastFilmUpTime;
						DateTime nowTime;
						int filmNum = PlayerPrefs.GetInt ("filmNum");
						if (PlayerPrefs.GetInt("pause")==1) {
								lastFilmUpTime = DateTime.Parse (PlayerPrefs.GetString ("lastFilmUpTime"));
								nowTime = DateTime.Now;
								timeSpan = nowTime - lastFilmUpTime;
								int spanMinutes = timeSpan.Minutes;
								int filmMax = PlayerPrefs.GetInt ("filmMax");
								filmNum += spanMinutes % 1;
								if (filmNum > filmMax) {
										filmNum = filmMax;
								}
								PlayerPrefs.SetInt ("filmNum",filmNum);
								PlayerPrefs.SetInt ("pause",0);
								Debug.Log ("timeSpan is : " + timeSpan);
								Debug.Log ("spanMinutes is :"+spanMinutes);
								Debug.Log ("application did become active or onresume");
						}
				}
		}


}
