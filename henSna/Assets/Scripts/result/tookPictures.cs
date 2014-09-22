using UnityEngine;
using System.Collections;

public class tookPictures : MonoBehaviour {
	private UILabel label;
	// Use this for initialization
	void Start () {
		int tookPictureNum = PlayerPrefs.GetInt ("tookPictureNum");
		label = GameObject.Find("tookPictureNumLabel").GetComponent<UILabel>();
		label.text = tookPictureNum.ToString();
		PlayerPrefs.SetInt ("tookPictureNum",0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
