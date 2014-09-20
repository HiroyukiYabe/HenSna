//スワイプ量を取得し、カメラを移動・回転
//Attach to Player

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour {

	public float MoveSpeed = 5.0f;
	public float RotSpeed = 50.0f;
	public float LimitRotX = 70.0f;
	TapDetect tapDetect;
	CharacterController charCon;
	//GameObject player;
	
	// Use this for initialization
	void Start () {
		tapDetect = GameObject.FindWithTag ("GameController").GetComponent<TapDetect> ();
		charCon = GetComponent<CharacterController>();
		//player = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 rot = tapDetect.UpDrag ();
		Vector2 move = tapDetect.DownDrag ();

		//スワイプ量を元に前後左右に移動
		Vector3 nowForward = new Vector3(transform.forward.x,0,transform.forward.z).normalized;
		Vector3 nowRight = new Vector3(transform.right.x,0,transform.right.z).normalized;
		Vector3 _move = (nowRight * move.x + nowForward * move.y) * MoveSpeed * Time.deltaTime + Physics.gravity * Time.deltaTime;
		charCon.Move(_move);

		//スワイプ量を元に回転
		float _rotX = transform.eulerAngles.x - rot.y * RotSpeed *Time.deltaTime;
		float _rotY = transform.eulerAngles.y + rot.x * RotSpeed *Time.deltaTime;
		//x方向の回転を制限  回転可能角度外
		if(_rotX > LimitRotX && _rotX < 360f - LimitRotX){
			//下と上のどちらから可能角度を超えたか それに応じて制限
			_rotX = _rotX > 180f ? 360f - LimitRotX : LimitRotX;
		}
		//回転
		transform.rotation = Quaternion.Euler(_rotX,_rotY,transform.eulerAngles.z);
		
	}

}
