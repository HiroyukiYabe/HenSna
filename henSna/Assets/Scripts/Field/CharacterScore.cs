//各キャラクタごとに撮影されたか判定、得点を計算してスコアを増加させる
//Attach to Characers

//ポーズ対応必要なし

//To Do:撮影された状況によって得点を変化させる


using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharInfo))]
public class CharacterScore : MonoBehaviour {

	PrefsManager prefs;
	CharInfo info;

	TakePicture pic;
	Score _score;
	Camera cam;

	public float OffSet = 0.85f;
	public float Near = 3.0f;
	public float Far = 10.0f;

	//For Debug
	Ray ray;
	RaycastHit hit = new RaycastHit();
	Ray rayUp;
	RaycastHit hitUp = new RaycastHit();
	Ray rayDown;
	RaycastHit hitDown = new RaycastHit();
	Ray rayRight;
	RaycastHit hitRight = new RaycastHit();
	Ray rayLeft;
	RaycastHit hitLeft = new RaycastHit();
	Ray rayForward;
	RaycastHit hitForward = new RaycastHit();
	Ray rayBack;
	RaycastHit hitBack = new RaycastHit();
	

	// Use this for initialization
	void Start () {
		prefs = GameObject.FindWithTag ("GameController").GetComponent<PrefsManager> ();
		info = GetComponent<CharInfo> ();
		pic = GameObject.FindWithTag ("GameController").GetComponent<TakePicture> ();
		_score = GameObject.FindWithTag ("GameController").GetComponent<Score> ();
		cam = Camera.main;
	}


	// Update is called once per frame
	void Update () {
		bool photoflag = pic.isTakingPicture;

		/*if (Input.touchCount > 0){
			foreach (Touch touch in Input.touches){
				if(touch.phase == TouchPhase.Began){
					if (touch.tapCount>1 && touch.tapCount%2==0) doubleTap = true;
				}
			}
		}*/

		if (photoflag ) {	
			if(IsInScreen ()){
				prefs.SetGotCharacter(info.name);
				prefs.SetThisTimeGotType(info.id);
				_score.AddScore(CalculateScore());
			}else _score.AddScore(0);
		}


		//For Debug
		Debug.DrawLine(ray.origin, hit.point, Color.black);
		Debug.DrawLine(rayUp.origin, hitUp.point, Color.green);
		Debug.DrawLine(rayDown.origin, hitDown.point, Color.blue);
		Debug.DrawLine(rayRight.origin, hitRight.point, Color.red);
		Debug.DrawLine(rayLeft.origin, hitLeft.point, Color.yellow);
		Debug.DrawLine(rayForward.origin, hitForward.point, Color.magenta);
		Debug.DrawLine(rayBack.origin, hitBack.point, Color.cyan);

	}


	//キャラクタがカメラの画面内かを判定する関数
	bool IsInScreen(){
		Vector3 pos = cam.WorldToViewportPoint (transform.position+transform.up*OffSet);
		Vector3 posUp = cam.WorldToViewportPoint (transform.position+transform.up*OffSet+transform.up*0.45f);
		Vector3 posDown = cam.WorldToViewportPoint (transform.position+transform.up*OffSet-transform.up*0.45f);
		Vector3 posRight = cam.WorldToViewportPoint (transform.position+transform.up*OffSet+transform.right*0.25f);
		Vector3 posLeft = cam.WorldToViewportPoint (transform.position+transform.up*OffSet-transform.right*0.25f);
		Vector3 posForward = cam.WorldToViewportPoint (transform.position+transform.up*OffSet+transform.forward*0.25f);
		Vector3 posBack = cam.WorldToViewportPoint (transform.position+transform.up*OffSet-transform.forward*0.25f);
		if ((pos.x>=0 && pos.x<=1 && pos.y>=0 && pos.y<=1 && pos.z>=0) || (posUp.x>=0 && posUp.x<=1 && posUp.y>=0 && posUp.y<=1 && posUp.z>=0) || (posDown.x>=0 && posDown.x<=1 && posDown.y>=0 && posDown.y<=1 && posDown.z>=0) || (posRight.x>=0 && posRight.x<=1 && posRight.y>=0 && posRight.y<=1 && posRight.z>=0) || 
		    (posLeft.x>=0 && posLeft.x<=1 && posLeft.y>=0 && posLeft.y<=1 && posLeft.z>=0) || (posForward.x>=0 && posForward.x<=1 && posForward.y>=0 && posForward.y<=1 && posForward.z>=0) || (posBack.x>=0 && posBack.x<=1 && posBack.y>=0 && posBack.y<=1 && posBack.z>=0)) {

			/*Ray ray = cam.ScreenPointToRay(cam.WorldToScreenPoint(transform.position));
			RaycastHit hit = new RaycastHit();
			Physics.Raycast(ray, out hit);
			Ray rayUp = cam.ScreenPointToRay(cam.WorldToScreenPoint(transform.position+transform.up*0.4f));
			RaycastHit hitUp = new RaycastHit();
			Physics.Raycast(rayUp, out hitUp);
			Ray rayDown = cam.ScreenPointToRay(cam.WorldToScreenPoint(transform.position-transform.up*0.3f));
			RaycastHit hitDown = new RaycastHit();
			Physics.Raycast(rayDown, out hitDown);
			Ray rayRight = cam.ScreenPointToRay(cam.WorldToScreenPoint(transform.position+transform.right*0.3f));
			RaycastHit hitRight = new RaycastHit();
			Physics.Raycast(rayRight, out hitRight);
			Ray rayLeft = cam.ScreenPointToRay(cam.WorldToScreenPoint(transform.position-transform.right*0.3f));
			RaycastHit hitLeft = new RaycastHit();
			Physics.Raycast(rayLeft, out hitLeft);
			Ray rayForward = cam.ScreenPointToRay(cam.WorldToScreenPoint(transform.position+transform.up*OffSet+transform.forward*0.25f));
			RaycastHit hitForward = new RaycastHit();
			Physics.Raycast(rayForward, out hitForward);
			Ray rayBack = cam.ScreenPointToRay(cam.WorldToScreenPoint(transform.position+transform.up*OffSet-transform.forward*0.25f));
			RaycastHit hitBack = new RaycastHit();
			Physics.Raycast(rayBack, out hitBack);*/

			//For Debug
			ray = cam.ScreenPointToRay(cam.WorldToScreenPoint(transform.position+transform.up*OffSet));
			hit = new RaycastHit();
			Physics.Raycast(ray, out hit);
			rayUp = cam.ScreenPointToRay(cam.WorldToScreenPoint(transform.position+transform.up*OffSet+transform.up*0.45f));
			hitUp = new RaycastHit();
			Physics.Raycast(rayUp, out hitUp);
			rayDown = cam.ScreenPointToRay(cam.WorldToScreenPoint(transform.position+transform.up*OffSet-transform.up*0.45f));
			hitDown = new RaycastHit();
			Physics.Raycast(rayDown, out hitDown);
			rayRight = cam.ScreenPointToRay(cam.WorldToScreenPoint(transform.position+transform.up*OffSet+transform.right*0.25f));
			hitRight = new RaycastHit();
			Physics.Raycast(rayRight, out hitRight);
			rayLeft = cam.ScreenPointToRay(cam.WorldToScreenPoint(transform.position+transform.up*OffSet-transform.right*0.25f));
			hitLeft = new RaycastHit();
			Physics.Raycast(rayLeft, out hitLeft);
			rayForward = cam.ScreenPointToRay(cam.WorldToScreenPoint(transform.position+transform.up*OffSet+transform.forward*0.25f));
			hitForward = new RaycastHit();
			Physics.Raycast(rayForward, out hitForward);
			rayBack = cam.ScreenPointToRay(cam.WorldToScreenPoint(transform.position+transform.up*OffSet-transform.forward*0.25f));
			hitBack = new RaycastHit();
			Physics.Raycast(rayBack, out hitBack);

			if(hit.collider.gameObject==this.gameObject || hitUp.collider.gameObject==this.gameObject || hitDown.collider.gameObject==this.gameObject || hitRight.collider.gameObject==this.gameObject || 
			   hitLeft.collider.gameObject==this.gameObject || hitForward.collider.gameObject==this.gameObject || hitBack.collider.gameObject==this.gameObject){
				return true;
			}
		}
		return false;
	}


	//得点を計算する関数
	int CalculateScore(){
		int _score = info.baseScore;
		//向きによる倍率
		float magDir = 0.5f + 0.5f * (Vector3.Angle(transform.forward,cam.transform.forward)/180.0f);
		//画面内位置による倍率
		Vector3 _pos = cam.WorldToViewportPoint (transform.position + transform.up * OffSet);
		float magPos = 0.25f + 0.75f * 2 * ((Mathf.Abs(0.5f-_pos.x) > Mathf.Abs(0.5f-_pos.y)) ? 0.5f-Mathf.Abs(0.5f-_pos.x) : 0.5f-Mathf.Abs(0.5f-_pos.y));
		//距離による倍率
		float magDis;
		if (_pos.z >= 0 && _pos.z < Near)
						magDis = 1.0f;
				else if (_pos.z < Far)
						magDis = 0.5f;
				else
						magDis = 0.1f;
		//切り上げ処理
		_score = Mathf.CeilToInt(_score * magDir * magPos * magDis);
		return _score;
	}


}
