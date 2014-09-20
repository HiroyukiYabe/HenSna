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
	public string status;
	public string name;
	

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

		if (doubleTap) {	
			if(IsInScreen ()){
				_score.score+=CalculateScore();
			}
		}
	}


	bool IsInScreen(){
		status = "Taped";
		name = "";
		Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
		if (pos.x >= 0 && pos.x <= 1 && pos.y >= 0 && pos.y <= 1 && pos.z >= 0) {
			status = "In Screen";
			Ray ray = Camera.main.ScreenPointToRay(Camera.main.WorldToScreenPoint(transform.position));
			RaycastHit hit = new RaycastHit();
			Physics.Raycast(ray, out hit);
			name=hit.collider.gameObject.name;
			if(hit.collider.gameObject==this.gameObject){
				status = "Visible";
				return true;
			}
		}
		return false;
	}


	int CalculateScore(){
		return ThisScore;
	}


}
