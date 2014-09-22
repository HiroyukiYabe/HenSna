//移動はだいたいOK

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Navtest : MonoBehaviour {

	NavMeshAgent nav;
	int index;
	public Transform[] waypoints;
	Vector3 center;

	float timer=0f;
	bool lestFlag= false;
	float lestTimer=0f;

	bool invokeFlag=false;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		index = 1;
		waypoints = GameObject.Find ("Waypoints").GetComponentsInChildren<Transform> ();
		center = new Vector3 (100f, 0f, 100f);
		//nav.SetDestination(waypoints[index].position);
		nav.SetDestination(RandomPosition());
		nav.speed=Random.Range(2f,5f);
		Debug.Log ("Destination: "+nav.destination+",    Speed: "+nav.speed);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		//Debug.Log ("Timer:  "+timer);

		if ((transform.position - nav.destination).sqrMagnitude <= nav.stoppingDistance || timer>10f) {
			if(!invokeFlag){
				Invoke("SetNav",Random.Range(2f,7f));
				invokeFlag=true;
			}
			/*lestFlag= true;
			lestTimer=0f;
			nav.Stop();*/
		}

		/*if (lestFlag)	lestTimer += Time.deltaTime;
		if (lestTimer > 3f) {
			lestTimer=0f;
			lestFlag = false;
			nav.Start();
		}*/

	}

	void SetNav(){
		nav.SetDestination(RandomPosition());
		nav.speed=Random.Range(2f,5f);
		if (nav.destination == transform.position) {
			nav.SetDestination(RandomPosition());
			Debug.Log ("Re:SetDestination");
		}
		Debug.Log ("Destination: "+nav.destination+",    Speed: "+nav.speed);
		timer=0f;
		invokeFlag = false;
	}

	void ChangeTarget(){
		if (index == waypoints.Length - 1)
			index = 1;
		else
			index++;
		Debug.Log("Change Target "+index);
		Debug.Log("Next Target is " + waypoints[index].name);
		nav.SetDestination(waypoints[index].position);
	}

	Vector3 RandomPosition(){
		float x = Random.Range (-25f,25f);
		float y = 0;//Random.Range (-25f,25f);
		float z = Random.Range (-25f,25f);
		Vector3 toCenter = (center - transform.position).normalized;
		return transform.position+new Vector3(x,y,z)+toCenter*Random.Range(3f,10f);
	}



}
