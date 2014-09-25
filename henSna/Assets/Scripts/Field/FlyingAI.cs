//単純なキャラクタ移動
//Attach to Character

//ポーズ対応必要なし

using UnityEngine;
using System.Collections;

// Require these components when using this script
//[RequireComponent(typeof (Animator))]
//[RequireComponent(typeof (CapsuleCollider))]
//[RequireComponent(typeof (Rigidbody))]
//[RequireComponent(typeof(NavMeshAgent))]
public class FlyingAI : MonoBehaviour
{
	
	//public float animSpeed = 1.5f;				// a public setting for overall animator animation speed
	//public float lookSmoother = 3f;				// a smoothing setting for camera motion
	

	public float MinSpeed = 0.5f;
	public float MaxSpeed = 2.0f;
	
	float timer;
	float interval;
	float speed;
	public Vector3 direction;
	
	void Start ()
	{
		timer = 10f;
		interval = 10f;
		speed = Random.Range (MinSpeed, MaxSpeed);
		direction = Vector3.zero;
	}
	
	
	// Update is called once per frame
	void Update(){
		timer += Time.deltaTime;
		if (timer > interval) {
			speed = Random.Range (MinSpeed, MaxSpeed);
			Vector2 newPosition = Random.insideUnitCircle * 50;
			direction=new Vector3(newPosition.x,0,newPosition.y)+new Vector3(100,40,100);
			timer=0f;
			Vector3 forward = transform.forward;
			transform.rotation = Quaternion.FromToRotation (new Vector3(forward.x,0,forward.z),direction - transform.position);
		}
		transform.position += (direction - transform.position).normalized * speed * Time.deltaTime;


	}
	

}
