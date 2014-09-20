//ナビメッシュを利用したキャラクタ移動 
//Attach to Character


using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class NavControl : MonoBehaviour {

	Animator anim;
	CharacterController CC;
	NavMeshAgent nav;
	
	float speed = 5f;
	float gravity = 9.8f;
	
	// 新しい変数をここに
	public Transform[] _waypoint;
	int index;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		CC = GetComponent<CharacterController> ();
		nav = GetComponent<NavMeshAgent> ();
		index = 0;
		nav.SetDestination (_waypoint [index].position);
		
	}
	
	// Update is called once per frame
	void Update () {
		Patrolling ();
	}
	
	
	void Patrolling ()
	{
		// Set an appropriate speed for the NavMeshAgent.
		nav.speed = speed;
		Debug.Log ("Patrolling");
		// If near the next waypoint or there is no destination...
		if (nav.remainingDistance < nav.stoppingDistance) {
			Debug.Log("Change Target");
						// ... increment the wayPointIndex.
						if (index == _waypoint.Length - 1)
								index = 0;
						else
								index++;
				}
			// If not near a destination, reset the timer.
			//patrolTimer = 0;
		
		// Set the destination to the patrolWayPoint.
						nav.SetDestination (_waypoint [index].position);
	}
	
	
}
