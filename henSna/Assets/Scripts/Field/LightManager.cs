//Attach to LightManager

//ポーズ対応

using UnityEngine;
using System.Collections;


public class LightManager : MonoBehaviour {

	public Material DayLight;
	public Material Sunset;
	public Material Night;

	Skybox thisSky;
	GameObject light;

	// Use this for initialization
	void Start () {
		thisSky = Camera.main.GetComponent<Skybox> ();
		thisSky.material = DayLight;
		foreach (Transform _light in transform.GetComponentsInChildren<Transform>()) {
			if (_light.gameObject != gameObject)	_light.gameObject.SetActive (false);
		}
		light = transform.FindChild ("DayLight").gameObject;
		light.SetActive(true);
	}
	
	// Update is called once per frame
	//void Update () {}

	public void ChangeDayLight(){
		thisSky.material = DayLight;
		light.SetActive(false);
		light=transform.FindChild ("DayLight").gameObject;
		light.SetActive(true);
	}
	public void ChangeSunset(){
		thisSky.material = Sunset;
		light.SetActive(false);
		light=transform.FindChild ("Sunset").gameObject;
		light.SetActive(true);
	}
	public void ChangeNight(){
		thisSky.material = Night;
		light.SetActive(false);
		light=transform.FindChild ("Night").gameObject;
		light.SetActive(true);
	}

}
