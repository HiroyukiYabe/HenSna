using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	float Speed;

	// Use this for initialization
	void Start () {
		Speed = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		float x=Input.GetAxis("Horizontal");
		float y=Input.GetAxis("Vertical");
		Vector3 move = new Vector3 (x, 0, y)*Speed*Time.deltaTime;
		transform.position += move;
	}
}
