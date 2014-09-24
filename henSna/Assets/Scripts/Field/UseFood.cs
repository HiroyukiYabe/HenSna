//Attach to FoodGenerater in Player

//ポーズ対応


using UnityEngine;
using System.Collections;

public class UseFood : MonoBehaviour {

	PrefsManager prefs;
	public GameObject FoodPrefab;
	public Vector3 ThrowSpeed=new Vector3(0f,5f,5f);
	public int Cost=1000;

	// Use this for initialization
	void Start () {
		prefs = GameObject.FindWithTag ("GameController").GetComponent<PrefsManager> ();
	}
	
	// Update is called once per frame
	//void Update () {}

	public bool CanThrow(){
		return (prefs.GetHavingCoin () > Cost && !GameObject.Find ("Hambuger(Clone)"));
	}

	public void ThrowFood(){
		if (prefs.GetHavingCoin () > Cost && !GameObject.Find ("Hambuger(Clone)")) {
			prefs.SubtractCoin (Cost);
			GameObject foodInst = (GameObject)Instantiate (FoodPrefab, transform.position, Quaternion.identity);
			Vector3 vec = transform.right * ThrowSpeed.x + transform.up * ThrowSpeed.y + transform.forward * ThrowSpeed.z;
			foodInst.rigidbody.AddForce (vec, ForceMode.Impulse);
		}
	}
}
