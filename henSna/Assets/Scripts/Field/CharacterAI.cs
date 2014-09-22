//単純なキャラクタ移動
//Attach to Character


using UnityEngine;
using System.Collections;

// Require these components when using this script
//[RequireComponent(typeof (Animator))]
//[RequireComponent(typeof (CapsuleCollider))]
//[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class CharacterAI : MonoBehaviour
{
	
	public float animSpeed = 1.5f;				// a public setting for overall animator animation speed
	public float lookSmoother = 3f;				// a smoothing setting for camera motion
	
	private Animator anim;							// a reference to the animator on the character
	private AnimatorStateInfo currentBaseState;			// a reference to the current state of the animator, used for base layer
	private AnimatorStateInfo layer2CurrentState;	// a reference to the current state of the animator, used for layer 2
	private CapsuleCollider col;					// a reference to the capsule collider of the character
	
	
	static int idleState = Animator.StringToHash("Base Layer.Idle");	
	static int locoState = Animator.StringToHash("Base Layer.Locomotion");			// these integers are references to our animator's states
	static int backState = Animator.StringToHash("Base Layer.WalkBack");				// and are used to check state for various actions to occur

	NavMeshAgent nav;					// Reference to the nav mesh agent.
	public float speedDampTime = 0.1f;				// Damping time for the Speed parameter.
	public float angularSpeedDampTime = 0.7f;		// Damping time for the AngularSpeed parameter
	public float angleResponseTime = 0.6f;			// Response time for turning an angle into angularSpeed.
	public float deadZone = 5f;					// The number of degrees for which the rotation isn't controlled by Mecanim.

	public Transform[] WayPoints;


	void Start ()
	{
		// initialising reference variables
		anim = gameObject.GetComponent<Animator>();					  
		//col = gameObject.GetComponent<CapsuleCollider>();				
		if(anim.layerCount ==2)
			anim.SetLayerWeight(1, 1);
		nav = GetComponent<NavMeshAgent>();
		// Making sure the rotation is controlled by Mecanim.
		nav.updateRotation = false;

		// We need to convert the angle for the deadzone from degrees to radians.
		deadZone *= Mathf.Deg2Rad;
		SetDestination ();
	}

	void Update () 
	{
		// Calculate the parameters that need to be passed to the animator component.
		NavAnimSetup();
	}
	
	
	void OnAnimatorMove()
	{
		// Set the NavMeshAgent's velocity to the change in position since the last frame, by the time it took for the last frame.
		nav.velocity = anim.deltaPosition / Time.deltaTime;
		
		// The gameobject's rotation is driven by the animation's rotation.
		transform.rotation = anim.rootRotation;
	}
	
	
	void NavAnimSetup ()
	{
		// Create the parameters to pass to the helper function.
		float speed;
		float angle;
		
		
		// Otherwise the speed is a projection of desired velocity on to the forward vector...
		speed = Vector3.Project(nav.desiredVelocity, transform.forward).magnitude;
		
		// ... and the angle is the angle between forward and the desired velocity.
		angle = FindAngle(transform.forward, nav.desiredVelocity, transform.up);
		
		// If the angle is within the deadZone...
		if(Mathf.Abs(angle) < deadZone)
		{
			// ... set the direction to be along the desired direction and set the angle to be zero.
			transform.LookAt(transform.position + nav.desiredVelocity);
			angle = 0f;
		}
		
		// Call the Setup function of the helper class with the given parameters.
		Setup(speed, angle);
	}
	
	
	float FindAngle (Vector3 fromVector, Vector3 toVector, Vector3 upVector)
	{
		// If the vector the angle is being calculated to is 0...
		if(toVector == Vector3.zero)
			// ... the angle between them is 0.
			return 0f;
		
		// Create a float to store the angle between the facing of the enemy and the direction it's travelling.
		float angle = Vector3.Angle(fromVector, toVector);
		
		// Find the cross product of the two vectors (this will point up if the velocity is to the right of forward).
		Vector3 normal = Vector3.Cross(fromVector, toVector);
		
		// The dot product of the normal with the upVector will be positive if they point in the same direction.
		angle *= Mathf.Sign(Vector3.Dot(normal, upVector));
		
		// We need to convert the angle we've found from degrees to radians.
		angle *= Mathf.Deg2Rad;
		
		return angle;
	}
	
	public void Setup(float speed, float angle)
	{
		// Angular speed is the number of degrees per second.
		float angularSpeed = angle / angleResponseTime;
		
		// Set the mecanim parameters and apply the appropriate damping to them.
		anim.SetFloat("Speed", speed, speedDampTime, Time.deltaTime);
		anim.SetFloat("Direction", angularSpeed, angularSpeedDampTime, Time.deltaTime);
	}	

	void SetDestination(){
		nav.SetDestination(WayPoints[Random.Range(0,WayPoints.Length)].position);
	}

	/*void FixedUpdate ()
	{	

		timer+=Time.fixedDeltaTime;
		if (timer > interval) {
			timer=0;
			dir = Random.Range(-1.0f,1.0f);
			speed = Random.Range(0.0f,1.0f);
		}

		//float h = Input.GetAxis("Horizontal");				// setup h variable as our horizontal input axis
		//float v = Input.GetAxis("Vertical");				// setup v variables as our vertical input axis
		anim.SetFloat("Speed", speed);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.SetFloat("Direction", dir); 						// set our animator's float parameter 'Direction' equal to the horizontal input axis		
		anim.speed = animSpeed;								// set the speed of our animator to the public variable 'animSpeed'
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	// set our currentState variable to the current state of the Base Layer (0) of animation
		
		if(anim.layerCount ==2)		
			layer2CurrentState = anim.GetCurrentAnimatorStateInfo(1);	// set our layer2CurrentState variable to the current state of the second Layer (1) of animation

		
		// IDLE
		// check if we are at idle, if so, let us Wave!
		else if (currentBaseState.nameHash == idleState)
		{
			if(Input.GetButtonUp("Jump"))
			{
				anim.SetBool("Wave", true);
			}
		}
		// if we enter the waving state, reset the bool to let us wave again in future
		if(layer2CurrentState.nameHash == waveState)
		{
			anim.SetBool("Wave", false);
		}
	}*/
}
