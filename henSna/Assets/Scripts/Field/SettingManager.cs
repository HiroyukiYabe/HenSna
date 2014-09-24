using UnityEngine;
using System.Collections;

public class SettingManager : MonoBehaviour {

	public static bool pause;

	// Use this for initialization
	void Awake () {
		pause = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha9)) {
			Time.timeScale = 1;
			pause=false;
		}
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			Time.timeScale = 0;
			pause=true;
		}
	}


	void OnApplicationPause (bool pauseStatus)
	{
		if (pauseStatus) {
			Debug.Log("applicationWillResignActive or onPause");
		} else{
			Debug.Log("applicationDidBecomeActive or onResume");
		}
	}

}
