//各キャラクタごとに撮影されたか判定、得点を計算してスコアを増加させる
//Attach to Characers

//To Do:撮影された状況によって得点を変化させる


using UnityEngine;
using System.Collections;

public class CharacterScore : MonoBehaviour {

	TakePicture pic;
	Score _score;
	//Transform player;
	public int ThisScore;
	

	// Use this for initialization
	void Start () {
		pic = GameObject.FindWithTag ("GameController").GetComponent<TakePicture> ();
		_score = GameObject.FindWithTag ("GameController").GetComponent<Score> ();
		//player = GameObject.FindWithTag ("Player").transform;
	}


	// Update is called once per frame
	void Update () {
		//if (pic.isTakingPicture)	PictureCheck();

		bool doubleTap = false;
		if (Input.touchCount > 0){
			foreach (Touch touch in Input.touches){
				if(touch.phase == TouchPhase.Began){
					if (touch.tapCount>1 && touch.tapCount%2==0) doubleTap = true;
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			doubleTap = true;
		}

		if (doubleTap)	PictureCheck();
	}


	void PictureCheck(){
		Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
		if (pos.x >= 0 && pos.x <= 1 && pos.y >= 0 && pos.y <= 1 && pos.z>=0) {
			_score.score+=ThisScore;
		}
	}


}
