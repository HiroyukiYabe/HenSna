//ダブルタップを検出して写真撮影フラグを管理
//Attach to GameController

//ポーズ対応

//To Do:写真を撮れる間隔の設定
//写真撮影時のエフェクト
//写真プレビュー


using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class TakePicture : MonoBehaviour {

	PrefsManager Prefs;

	bool doubleTap;
	[HideInInspector]
	public bool isTakingPicture;

	Rect center;
	public Texture CenterMark;
	public AudioClip ShutterClip;
	AudioSource shutterSE;


	// Use this for initialization
	void Start () {
		Prefs = GameObject.FindWithTag ("GameController").GetComponent<PrefsManager> ();
		doubleTap = false;
		isTakingPicture = false;
		float markSize = Screen.height / 10;
		center = new Rect(Screen.width/2-markSize,Screen.height/2-markSize,markSize*2,markSize*2);
		shutterSE = GetComponent<AudioSource>();
		shutterSE.clip = ShutterClip;
	}


	// Update is called once per frame
	void Update () {
		doubleTap = false;
		isTakingPicture = false;

	if(!Pauser.isPause){

		if (Input.touchCount > 0){
			foreach (Touch touch in Input.touches){
				if (touch.phase==TouchPhase.Began){
					if (touch.tapCount > 1)	doubleTap = true;
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Space))	doubleTap = true;

		if (doubleTap && Prefs.GetRemainFilmNum () > 0) {
			isTakingPicture = true;
			TakePhoto ();
		}
	}
	}


	void TakePhoto(){
		GameObject ngui = GameObject.FindWithTag ("NGUI");
		ngui.SetActive (false);
		GUITexture prev = GameObject.FindWithTag ("Screenshot").GetComponent<GUITexture> ();;
		Color c = prev.color;
		c.a = 0f;
		prev.color = c;

		Debug.Log ("method calling");
		StartCoroutine(Prefs.CaptureScreenshotAsync());
		Debug.Log ("method called");
		
		Prefs.SetRemainFilmNum(Prefs.GetRemainFilmNum()-1);
		Prefs.SetTakenPicNum(Prefs.GetTakenPicNum()+1);

		FadeInOut fade = GameObject.Find ("FadeInOut").GetComponent<FadeInOut> ();
		fade.flag = true;
		shutterSE.Play();
		ngui.SetActive (true);
		
	}


	/*void OnGUI (){
		if(!Pauser.isPause)
			GUI.DrawTexture (center, CenterMark);
	}*/

}
