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


	// Use this for initialization
	void Start () {
		isDownTouch = false;
		isUpTouch = false;
		downMove = Vector2.zero;
		upMove = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) {
			foreach(Touch touch in Input.touches){
				switch(touch.phase){
				case TouchPhase.Began:
					if(!isDownTouch && touch.position.y <= Screen.height/2){
						isDownTouch = true;
						downStartPos = touch.position;
						downID = touch.fingerId;
					}else if(!isUpTouch && touch.position.y > Screen.height/2){
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
					break;
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
				}
			}
		}

	}



	//Get drag movement in upper area
	public Vector2 UpDrag(){
		float resx = upMove.x/(Screen.height/2);
		if (Mathf.Abs (resx) > 1)
			resx = Mathf.Sign(resx);
		float resy = upMove.y/(Screen.height/2);
		if (Mathf.Abs (resy) > 1)
			resy = Mathf.Sign(resy);
		return new Vector2(resx,resy);
	}

	//Get drag movement in lower area
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
