using UnityEngine;
using System.Collections;

public class settingGameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clickUpSideDownButton(){
		PlayerPrefs.SetInt ("playerUIController",0);
		Application.LoadLevel ("home");
	}

	public void clickRightAndLeftButton(){
		PlayerPrefs.SetInt ("playerUIController",1);
		Application.LoadLevel ("home");
	}
}
