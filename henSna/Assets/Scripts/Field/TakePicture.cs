//ダブルタップを検出して写真撮影フラグを管理
//Attach to GameController

//To Do:写真を撮れる間隔の設定 
//写真撮影時のエフェクト


using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class TakePicture : MonoBehaviour {

	PrefsManager Prefs;

	[HideInInspector]
	public bool isTakingPicture;

	Rect center;
	public Texture CenterMark;
	public AudioClip ShutterClip;
	AudioSource shutterSE;


	// Use this for initialization
	void Start () {
		Prefs = GameObject.FindWithTag ("GameController").GetComponent<PrefsManager> ();
		isTakingPicture = false;
		float markSize = Screen.height / 10;
		center = new Rect(Screen.width/2-markSize,Screen.height/2-markSize,markSize*2,markSize*2);
		shutterSE = GetComponent<AudioSource>();
		shutterSE.clip = ShutterClip;
	}


	// Update is called once per frame
	void Update () {
		isTakingPicture = false;

		if (Input.touchCount > 0){
			foreach (Touch touch in Input.touches){
				if (touch.phase==TouchPhase.Began){
					if (touch.tapCount > 1)	isTakingPicture = true;
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Space))	isTakingPicture = true;

		if (isTakingPicture)	TakePic ();
	}


	void TakePic(){
		if (Prefs.GetRemainFilmNum() > 0) {
			Prefs.SetRemainFilmNum(Prefs.GetRemainFilmNum()-1);
			Prefs.SetTakenPicNum(Prefs.GetTakenPicNum()+1);

			Prefs.StorePhoto();
			FadeInOut fade = GameObject.Find ("FadeInOut").GetComponent<FadeInOut> ();
			fade.flag = true;
			shutterSE.Play();
		}
	}


	void OnGUI (){
		GUI.DrawTexture (center, CenterMark);
	}

}
