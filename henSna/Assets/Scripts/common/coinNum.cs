using UnityEngine;
using System.Collections;

public class coinNum : MonoBehaviour {
		int coinnum;
		private UILabel label;
	// Use this for initialization
	void Start () {
				coinnum = PlayerPrefs.GetInt ("havingCoin");
				label = GameObject.Find("coinLabel").GetComponent<UILabel>();
				label.text = ":" + coinnum;
	}
	
	// Update is called once per frame
		/*void Update () {
		
	}*/
}
