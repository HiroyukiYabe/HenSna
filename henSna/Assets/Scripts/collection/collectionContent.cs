﻿using UnityEngine;
using System.Collections;

public class collectionContent : MonoBehaviour
{
	enum Types
	{
		Mummy=1,
		Pumpkin,
		Skelton,
		Knight}
	;
	private float questionSize;
	public int type;
	UILabel nameLabel;
	UILabel newLabel;
	UILabel monNumberLabel;
	UISprite contentImage;
	// Use this for initialization
	void Start ()
	{
		nameLabel = gameObject.transform.FindChild ("nameLabel").gameObject.GetComponent<UILabel> ();
		newLabel = gameObject.transform.FindChild ("newLabel").gameObject.GetComponent<UILabel> ();
		contentImage = gameObject.transform.FindChild ("UISprite").gameObject.GetComponent<UISprite> ();
		monNumberLabel = gameObject.transform.FindChild ("MonNumberLabel").gameObject.GetComponent<UILabel> ();
		questionSize = 100;
		switch (type) {
		case (int)Types.Mummy:
			monNumberLabel.text = "NO." + type;
			if (PlayerPrefs.GetInt ("gotMummy") == 1){
				//すでに撮った
				nameLabel.text = "Mummy";
				contentImage.spriteName = "mummyImage";
				if (PlayerPrefs.GetInt ("mummyNew") == 1) {
					//New
					newLabel.alpha = 1;

				} else {
					Destroy (newLabel);
				}
			} else {
				//まだ撮ってない
				nameLabel.text = "???";
				Destroy (newLabel);
				contentImage.spriteName = "question";
				contentImage.transform.localScale = new Vector3 (questionSize,questionSize,0);
			}
			break;
		case (int)Types.Pumpkin:
			monNumberLabel.text = "NO." + type;
			if (PlayerPrefs.GetInt ("gotPumpkin") == 1){
				//すでに撮った
				nameLabel.text = "Pumpkin";
				contentImage.spriteName = "pumpkinImage";
				if (PlayerPrefs.GetInt ("pumpkinNew") == 1) {
					//New
					newLabel.alpha = 1;

				} else {
					Destroy (newLabel);
				}
			} else {
				//まだ撮ってない
				nameLabel.text = "???";
				Destroy (newLabel);
				contentImage.spriteName = "question";
				contentImage.transform.localScale = new Vector3 (questionSize,questionSize,0);
			}

			break;
		case (int)Types.Skelton:
			monNumberLabel.text = "NO." + type;
			if (PlayerPrefs.GetInt ("gotSkelton") == 1){
				//すでに撮った
				nameLabel.text = "Skelton";
				contentImage.spriteName = "skeltonImage";
				if (PlayerPrefs.GetInt ("skeltonNew") == 1) {
					//New
					newLabel.alpha = 1;

				} else {
					Destroy (newLabel);
				}
			} else {
				//まだ撮ってない
				nameLabel.text = "???";
				Destroy (newLabel);
				contentImage.spriteName = "question";
				contentImage.transform.localScale = new Vector3 (questionSize,questionSize,0);
			}
			break;
		case (int)Types.Knight:
			monNumberLabel.text = "NO." + type;
			if (PlayerPrefs.GetInt ("gotKnight") == 1){
				//すでに撮った
				nameLabel.text = "Knight";
				contentImage.spriteName = "knightImage";
				if (PlayerPrefs.GetInt ("knightNew") == 1) {
					//New
					newLabel.alpha = 1;

				} else {
					Destroy (newLabel);
				}
			} else {
				//まだ撮ってない
				nameLabel.text = "???";
				Destroy (newLabel);
				contentImage.spriteName = "question";
				contentImage.transform.localScale = new Vector3 (questionSize,questionSize,0);
			}
			break;
		default:
			monNumberLabel.text = "NO.??";
			nameLabel.text = "Normal";
			contentImage.spriteName = "question";
			contentImage.transform.localScale = new Vector3 (questionSize,questionSize,0);
			break;
		}
	}
	// Update is called once per frame
	void Update ()
	{
	
	}
}
