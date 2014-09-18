// タップ位置、スワイプ量を取得


using UnityEngine;
using System.Collections;
using System;

public class TapDetect : MonoBehaviour {

	Vector2 downMove;
	Vector2 upMove;
	Vector2 downStartPos;
	Vector2 upStartPos;
	bool isUpTouch;
	bool isDownTouch;
	int upIndex;
	int downIndex;

	public GUIText text1;
	public GUIText text2;
	public GUIText WinSize;
	public GUIText te;

	// Use this for initialization
	void Start () {
		isUpTouch = false;
		isDownTouch = false;
	}
	
	// Update is called once per frame
	void Update () {
		te.text = "ID:";
		foreach (Touch _touch in Input.touches) {
			te.text += ""+_touch.fingerId;
				}
		te.text += "   NUM:";
		te.text += "" +	(Input.touchCount);

		if (Input.touchCount > 0) {
			foreach(Touch touch in Input.touches){
				if(touch.phase == TouchPhase.Began){
					if(!isDownTouch && touch.position.y <= Screen.height/2){
						isDownTouch = true;
						downStartPos = touch.position;
						downIndex = touch.fingerId;
					}else if(!isUpTouch && touch.position.y > Screen.height/2){
						isUpTouch = true;
						upStartPos = touch.position;
						upIndex = touch.fingerId;
						
					}
				}
			}
		}

		if(isUpTouch){
			Touch touch = Input.GetTouch(upIndex);
			if(touch.phase==TouchPhase.Moved) upMove = (touch.position - upStartPos);
			else if (touch.phase==TouchPhase.Ended){
				upMove = Vector2.zero;
				isUpTouch = false;
				upIndex = -1;
			}
		}

		if(isDownTouch){
			Touch touch = Input.GetTouch(downIndex);
			if(touch.phase==TouchPhase.Moved) downMove = (touch.position - downStartPos);
			else if (touch.phase==TouchPhase.Ended){
				downMove = Vector2.zero;
				isDownTouch = false;
				downIndex = -1;
			}
		}


		if (isUpTouch) {
			text1.text = "Up   X: "+ upMove.x.ToString() + "   Y: " + upMove.y.ToString();
		}else text1.text = "Up no Flic";
		if (isDownTouch) {
			text2.text = "Down X: "+ downMove.x.ToString() + "   Y: " + downMove.y.ToString();
		}else text2.text = "Down no Flic";

		WinSize.text = "width: " + Screen.width + "   height: " + Screen.height;

		int count = Input.touchCount;
		if (count > 0) {
			for(int i =0;i<count;i++){
				Touch touch = Input.GetTouch(i);
				Debug.Log( "i:"+i+",id:"+touch.fingerId+",phase:"+touch.phase);
			}
		}

	}

}
