//Attach to BottunManager

//ポーズ対応

using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {

	public static bool isPause;

	// Use this for initialization
	void Awake () {
		isPause = false;
	}
	
	// Update is called once per frame
	//void Update () {}


	public void Pause(){
		isPause = true;
		Time.timeScale = 0;
	}
	public void Resume(){
		isPause = false;
		Time.timeScale = 1;
	}


	void OnApplicationPause (bool pauseStatus)
	{
		if (pauseStatus) {
			Debug.Log("applicationWillResignActive or onPause");
			isPause = true;
			Time.timeScale = 0;
		} else{
			Debug.Log("applicationDidBecomeActive or onResume");
			isPause = false;
			Time.timeScale = 1;
		}
	}

}
