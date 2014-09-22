using UnityEngine;
using System.Collections;

public class filmNum : MonoBehaviour {
		private UILabel label;
		int filmnum;
		int filmMax;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				filmnum = PlayerPrefs.GetInt ("filmNum");
				filmMax = PlayerPrefs.GetInt ("filmMax");
				label = GameObject.Find("filmNumLabel").GetComponent<UILabel>();
				label.text = filmnum+"/"+filmMax;
	}
}
