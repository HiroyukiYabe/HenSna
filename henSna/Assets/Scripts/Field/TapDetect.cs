// タップ位置、スワイプ量を取得 
//Attach to GameController

//To Do: ポーズ時の例外処理



using UnityEngine;
using System.Collections;

public class TapDetect : MonoBehaviour {

	Vector2 downStartPos;
	Vector2 upStartPos;
	Vector2 downMove;
	Vector2 upMove;
	bool isDownTouch;
	bool isUpTouch;
	int downID;
	int upID;

	public bool upAndDown;

	public Texture2D MoveTexture;
	public Texture2D RotTexture;
	Rect rect;
	enum status{None,Move,Rot};
	status stat;
	float statTimer;


	// Use this for initialization
	void Start () {
		isDownTouch = false;
		isUpTouch = false;
		downMove = Vector2.zero;
		upMove = Vector2.zero;

		ChangeUIController ();

		rect = new Rect (Screen.width*9/10,0,Screen.width/10,Screen.width/10); 
		stat = status.None;
		statTimer = 0f;
	}


	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) {
			foreach(Touch touch in Input.touches){
				switch(touch.phase){
				case TouchPhase.Began:
					if(!isDownTouch && !IsInUpperArea(touch.position)){
					//if(!isDownTouch && touch.position.y <= Screen.height / 2){
						downStartPos = touch.position;
						downID = touch.fingerId;
						isDownTouch = true;
						stat=status.Move;
					}else if(!isUpTouch && IsInUpperArea(touch.position)){
					//}else if(!isUpTouch && touch.position.y > Screen.height / 2){
						upStartPos = touch.position;
						upID = touch.fingerId;
						isUpTouch = true;
						stat=status.Rot;
					}
					break;
				case TouchPhase.Moved:
					if (isDownTouch && touch.fingerId==downID)	downMove = (touch.position - downStartPos);
					else if (isUpTouch && touch.fingerId==upID)	upMove = (touch.position - upStartPos);
					break;
				case TouchPhase.Ended:
					if (isDownTouch && touch.fingerId==downID){
						downMove = Vector2.zero;
						isDownTouch = false;
						downID = -1;
						if(stat==status.Move) stat=status.None;
			Debug.Log("Stat:Down Unpressed");
						
					}
					else if (isUpTouch && touch.fingerId==upID){
						upMove = Vector2.zero;
						isUpTouch = false;
						upID = -1;
						if(stat==status.Rot) stat=status.None;
			Debug.Log("Stat:Up Unpressed");
						
					}
					break;
				case TouchPhase.Canceled:
					downMove = Vector2.zero;
					isDownTouch = false;
					downID = -1;
					upMove = Vector2.zero;
					isUpTouch = false;
					upID = -1;
					stat=status.None;
			Debug.Log("Stat:Canceled");
					
					break;
				}
			}
		}


		if (stat != status.None)	statTimer += Time.deltaTime;
		else 						statTimer = 0f;
		if (statTimer>1f) {
			statTimer=0f;
			stat=status.None;
			Debug.Log("Stat:Time Out");
		}

	}


	//return TRUE if tap_position is UP or RIGHT
	bool IsInUpperArea(Vector2 _pos){
		if (upAndDown)	return _pos.y > Screen.height / 2;
		else			return _pos.x > Screen.width / 2;
	}


	public void ChangeUIController(){
		PrefsManager prefs = GetComponent<PrefsManager> ();
		switch (prefs.GetUIController ()) {
		case "UpDown":
			upAndDown = true;
			Debug.Log("UpAndDown");
			break;
		case "RightLeft":
			upAndDown = false;
			Debug.Log("RightAndLeft");
			break;
		default :
			upAndDown = true;
			Debug.Log("Error");
			break;
		}
	}


	//Get drag movement in UPPER or RIGHT area
	public Vector2 UpDrag(){
		float resx = upMove.x/(Screen.height/2);
		if (Mathf.Abs (resx) > 1)
			resx = Mathf.Sign(resx);
		float resy = upMove.y/(Screen.height/2);
		if (Mathf.Abs (resy) > 1)
			resy = Mathf.Sign(resy);
		return new Vector2(resx,resy);
	}


	//Get drag movement in LOWER or LEFT area
	public Vector2 DownDrag(){
		float resx = downMove.x/(Screen.height/2);
		if (Mathf.Abs (resx) > 1)
			resx = Mathf.Sign(resx);
		float resy = downMove.y/(Screen.height/2);
		if (Mathf.Abs (resy) > 1)
			resy = Mathf.Sign(resy);
		return new Vector2(resx,resy);
	}


	void OnGUI (){
		if(stat==status.Move) GUI.DrawTexture (rect,MoveTexture);
		if(stat==status.Rot) GUI.DrawTexture (rect,RotTexture);
	}


}
