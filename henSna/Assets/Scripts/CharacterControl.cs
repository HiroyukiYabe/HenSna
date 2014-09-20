//単純なキャラクタ移動
//Attach to Character


using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))] 
public class CharacterControl : MonoBehaviour {

	Animator anim;
	CharacterController CC;

	float speed = 5f;
	float gravity = 9.8f;
	Vector3 moveDirection;
	
	float maxRotSpeed = 200.0f;
	float minTime = 0.1f;
	float range = 2.0f;
	float velocity = 0.0f;
	
	// 新しい変数をここに
	public Transform[] _waypoint;
	int index;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		CC = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		AnimatorStateInfo nextState = anim.GetCurrentAnimatorStateInfo (0);

		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log("OK!");
			Debug.Log(nextState);
			//if(nextState.nameHash!=Animator.StringToHash("Base Layer.idle")){
			if(nextState.IsName("Base Layer.idle")){
				anim.SetBool("attack",true);
				Debug.Log("attack");
			}else if(nextState.IsName("Base Layer.attack")){
				anim.SetBool("death",true);
				Debug.Log("death");
			}else if(nextState.IsName("Base Layer.death")){
				anim.SetBool("damege",true);
				Debug.Log("damege");
			}else if(nextState.IsName("Base Layer.damege")){
				anim.SetBool("idle",true);
				Debug.Log("idle");
			}
		}

		if (Input.GetKey(KeyCode.S)) {
			anim.speed = 0.3f;
		} else {
			anim.speed = 1;
		}

		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		if (x != 0 || y != 0) {
			transform.position+=new Vector3(x,0,y)*Time.deltaTime;
		}



			if((transform.position-_waypoint[index].position).sqrMagnitude >range){
				Move(_waypoint[index]);
				//animation.CrossFade("walk");
			}else NextIndex(); 
		}


		void Move(Transform target){
			moveDirection = transform.forward;
			moveDirection *= speed;
			moveDirection.y -= gravity * Time.deltaTime;
			CC.Move(moveDirection * Time.deltaTime);
			var newRotation = Quaternion.LookRotation(target.position - transform.position).eulerAngles;
			var angles = transform.rotation.eulerAngles;
			transform.rotation = Quaternion.Euler(angles.x, 
			                                       Mathf.SmoothDampAngle(angles.y, newRotation.y,ref velocity , minTime, maxRotSpeed), angles.z);
		}
		//NextIndex は単にindexを増分させ配列の範囲外では0をセット
		void NextIndex(){
			if(++index == _waypoint.Length) index = 0;
		}


	


}
