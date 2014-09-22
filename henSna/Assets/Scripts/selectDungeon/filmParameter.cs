using UnityEngine;
using System.Collections;
using System;

public class filmParameter : MonoBehaviour {
		float filmNum;
		float filmMax;
		float parameterBaseWidth;
		float parameterBaseHeight;
		float parameterwidth;
		private UISprite parameterBase;
		private UISprite parameter;
	// Use this for initialization
	void Start () {
				parameterBase = GameObject.Find ("filmParameterBaseImage").GetComponent<UISprite>();
				parameter = GameObject.Find ("filmParameterImage").GetComponent<UISprite>();
				parameterBaseWidth = parameterBase.transform.localScale.x;
				parameterBaseHeight = parameterBase.transform.localScale.y;

	}
	
	// Update is called once per frame
	void Update () {
				filmNum = PlayerPrefs.GetInt ("filmNum");
				filmMax = PlayerPrefs.GetInt ("filmMax");
				parameterwidth = (filmNum / filmMax) * parameterBaseWidth;
				transform.localScale = new Vector3 (parameterwidth,parameterBaseHeight,0);
	
	}
}
