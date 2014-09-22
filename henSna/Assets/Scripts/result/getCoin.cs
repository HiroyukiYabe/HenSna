using UnityEngine;
using System.Collections;

public class getCoin : MonoBehaviour {
	private UILabel label;
	// Use this for initialization
	void Start () {
		int gotCoinNum = PlayerPrefs.GetInt ("gotCoinNum");
		label = GameObject.Find("getCoinNumLabel").GetComponent<UILabel>();
		label.text = gotCoinNum.ToString();
		PlayerPrefs.SetInt ("gotCoinNum",0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
