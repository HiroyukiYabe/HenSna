using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

	Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
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




	}


}
