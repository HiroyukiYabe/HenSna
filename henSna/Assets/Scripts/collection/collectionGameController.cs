﻿using UnityEngine;
using System.Collections;

public class collectionGameController : MonoBehaviour
{
	enum Types
	{
		Mummy = 1,
		Pumpkin,
		Skelton,
		Knight}

	;

	GameObject summeryPanel;
	GameObject detailPanel;
	UILabel nameLabel;
	UILabel expLabel;
	UISprite contentImage;
	UISprite expImage;
	// Use this for initialization
	void Start ()
	{
		this.detailPanel = GameObject.Find ("detailPanel");
		this.summeryPanel = GameObject.Find ("UIPanel (Clipped View)");
		this.detailPanel.SetActive (false);

	}
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void clickImage (GameObject obj)
	{

		Debug.Log ("click Year!!!" + obj.name);
		this.summeryPanel.SetActive (false);
		this.detailPanel.SetActive (true);

		contentImage = GameObject.Find ("contentImage").gameObject.GetComponent<UISprite> ();
		expImage = GameObject.Find ("expImage").gameObject.GetComponent<UISprite> ();
		collectionContent script = obj.GetComponent<collectionContent> ();
		int type = script.type;
		Debug.Log ("type is :" + type);
		switch (type) {
		case (int)Types.Mummy:
			if (PlayerPrefs.GetInt ("gotMummy") == 1) {
				expImage.spriteName = "mummyExp";
				contentImage.spriteName = "mummyImage";
			} else {
				expImage.spriteName = "notYetExp";
				contentImage.spriteName = "question";
			}
			break;
		case (int)Types.Pumpkin:
			if (PlayerPrefs.GetInt ("gotPumpkin") == 1) {
				expImage.spriteName = "pumpkinExp2";
				contentImage.spriteName = "pumpkinImage";
			} else {
				expImage.spriteName = "notYetExp";
				contentImage.spriteName = "question";
			}
			break;
		case (int)Types.Skelton:
			if (PlayerPrefs.GetInt ("gotSkelton") == 1) {
				expImage.spriteName = "skeltonExp";
				contentImage.spriteName = "skeltonImage";
			} else {
				expImage.spriteName = "notYetExp";
				contentImage.spriteName = "question";
			}
			break;
		case (int)Types.Knight:
			if (PlayerPrefs.GetInt ("gotknight") == 1) {
				expImage.spriteName = "knightExp";
				contentImage.spriteName = "knightImage";
			} else {
				expImage.spriteName = "notYetExp";
				contentImage.spriteName = "question";			
			}
			break;
		default:
			expImage.spriteName = "notYetExp";
			contentImage.spriteName = "question";
			break;
		}
	}

	public void clickBackDetailButton ()
	{
		Debug.Log ("click back detail button");
		this.summeryPanel.SetActive (true);
		this.detailPanel.SetActive (false);
	}

	public void clickBackButton(){
		Application.LoadLevel ("home");
	}
}
