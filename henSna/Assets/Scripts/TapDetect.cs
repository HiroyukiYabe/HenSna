// タップ位置、スワイプ量を取得


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


	// Use this for initialization
	void Start () {
		isDownTouch = false;
		isUpTouch = false;
		downMove = Vector2.zero;
		upMove = Vector2.zero;

		upAndDown = true;
	}


	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) {
			foreach(Touch touch in Input.touches){
				switch(touch.phase){
				case TouchPhase.Began:
					if(!isDownTouch && !IsInUpperArea(touch.position)){
					//if(!isDownTouch && touch.position.y <= Screen.height / 2){
						isDownTouch = true;
						downStartPos = touch.position;
						downID = touch.fingerId;
					}else if(!isUpTouch && IsInUpperArea(touch.position)){
					//}else if(!isUpTouch && touch.position.y > Screen.height / 2){
						isUpTouch = true;
						upStartPos = touch.position;
						upID = touch.fingerId;
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
					}
					else if (isUpTouch && touch.fingerId==upID){
						upMove = Vector2.zero;
						isUpTouch = false;
						upID = -1;
					}
					break;
				case TouchPhase.Canceled:
						downMove = Vector2.zero;
						isDownTouch = false;
						downID = -1;
						upMove = Vector2.zero;
						isUpTouch = false;
						upID = -1;
					break;
				}
			}
		}

	}


	//return TRUE if tap_position is UP or RIGHT
	bool IsInUpperArea(Vector2 _pos){
		if (upAndDown)	return _pos.y > Screen.height / 2;
		else			return _pos.x > Screen.width / 2;
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


}
