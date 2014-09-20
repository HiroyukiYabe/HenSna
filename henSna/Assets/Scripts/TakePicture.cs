//ダブルタップを検出して写真撮影フラグを管理
//Attach to GameController

//To Do:写真を撮れる間隔の設定 
//写真撮影時のエフェクト


using UnityEngine;
using System.Collections;

public class TakePicture : MonoBehaviour {

	[HideInInspector]
	public bool isTakingPicture;

	// Use this for initialization
	void Start () {
		isTakingPicture = false;
	}
	
	// Update is called once per frame
	void Update () {
		isTakingPicture = false;

		if (Input.touchCount > 0){
			foreach (Touch touch in Input.touches){
				if (touch.tapCount > 1) isTakingPicture = true;
			}
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			isTakingPicture = true;
		}
	}
}
