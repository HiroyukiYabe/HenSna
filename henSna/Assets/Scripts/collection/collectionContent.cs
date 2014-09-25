using UnityEngine;
using System.Collections;

public class collectionContent : MonoBehaviour
{
	enum Types
	{
		Mummy=1,
		Pumpkin,
		Skelton,
		Knight,
		Santa,
		Snowman,
		Wizard,
		Mike,
		NormalGirl,
		NormalGlassWoman
	};

	private float questionSize;
	public int type;
	UILabel nameLabel;
	UILabel newLabel;
	UILabel monNumberLabel;
	UISprite contentImage;
	UISprite nameImage;
	// Use this for initialization
	void Start ()
	{
		nameLabel = gameObject.transform.FindChild ("nameLabel").gameObject.GetComponent<UILabel> ();
		newLabel = gameObject.transform.FindChild ("newLabel").gameObject.GetComponent<UILabel> ();
		contentImage = gameObject.transform.FindChild ("UISprite").gameObject.GetComponent<UISprite> ();
		nameImage = gameObject.transform.FindChild ("nameImage").gameObject.GetComponent<UISprite> ();
		monNumberLabel = gameObject.transform.FindChild ("MonNumberLabel").gameObject.GetComponent<UILabel> ();
		questionSize = 100;
		switch (type) {
		case (int)Types.Mummy:
			monNumberLabel.text = "NO." + type;
			if (PlayerPrefs.GetInt ("gotMummy") == 1){
				//すでに撮った
				nameImage.spriteName = "mummyNameImage";
				contentImage.spriteName = "mummyImage";
				if (PlayerPrefs.GetInt ("mummyNew") == 1) {
					//New
					newLabel.alpha = 1;
					PlayerPrefs.SetInt ("mummyNew",0);
				} else {
					Destroy (newLabel);
				}
			} else {
				//まだ撮ってない
				nameImage.spriteName = "notGetImage";
				Destroy (newLabel);
				contentImage.spriteName = "question";
				contentImage.transform.localScale = new Vector3 (questionSize,questionSize,0);
			}
			break;
		case (int)Types.Pumpkin:
			monNumberLabel.text = "NO." + type;
			if (PlayerPrefs.GetInt ("gotPumpkin") == 1){
				//すでに撮った
				nameImage.spriteName = "pumpkinNameImage";
				contentImage.spriteName = "pumpkinImage";
				if (PlayerPrefs.GetInt ("pumpkinNew") == 1) {
					//New
					newLabel.alpha = 1;
					PlayerPrefs.SetInt ("pumpkinNew",0);
				} else {
					Destroy (newLabel);
				}
			} else {
				//まだ撮ってない
				nameImage.spriteName = "notGetImage";
				Destroy (newLabel);
				contentImage.spriteName = "question";
				contentImage.transform.localScale = new Vector3 (questionSize,questionSize,0);
			}

			break;
		case (int)Types.Skelton:
			monNumberLabel.text = "NO." + type;
			if (PlayerPrefs.GetInt ("gotSkelton") == 1){
				//すでに撮った
				nameImage.spriteName = "skeltonNameImage2";
				contentImage.spriteName = "skeltonImage";
				if (PlayerPrefs.GetInt ("skeltonNew") == 1) {
					//New
					newLabel.alpha = 1;
					PlayerPrefs.SetInt ("skeltonNew",0);
				} else {
					Destroy (newLabel);
				}
			} else {
				//まだ撮ってない
				nameImage.spriteName = "notGetImage";
				Destroy (newLabel);
				contentImage.spriteName = "question";
				contentImage.transform.localScale = new Vector3 (questionSize,questionSize,0);
			}
			break;
		case (int)Types.Knight:
			monNumberLabel.text = "NO." + type;
			if (PlayerPrefs.GetInt ("gotKnight") == 1){
				//すでに撮った
				nameImage.spriteName = "knightNameImage";
				contentImage.spriteName = "knightImage";
				if (PlayerPrefs.GetInt ("knightNew") == 1) {
					//New
					newLabel.alpha = 1;
					PlayerPrefs.SetInt ("knightNew",0);
				} else {
					Destroy (newLabel);
				}
			} else {
				//まだ撮ってない
				nameImage.spriteName = "notGetImage";
				Destroy (newLabel);
				contentImage.spriteName = "question";
				contentImage.transform.localScale = new Vector3 (questionSize,questionSize,0);
			}
			break;
		case (int)Types.Santa:
			monNumberLabel.text = "NO." + type;
			if (PlayerPrefs.GetInt ("gotSanta") == 1){
				//すでに撮った
				nameImage.spriteName = "santaNameImage";
				contentImage.spriteName = "santaImage";
				if (PlayerPrefs.GetInt ("santaNew") == 1) {
					//New
					newLabel.alpha = 1;
					PlayerPrefs.SetInt ("santaNew",0);
				} else {
					Destroy (newLabel);
				}
			} else {
				//まだ撮ってない
				nameImage.spriteName = "notGetImage";
				Destroy (newLabel);
				contentImage.spriteName = "question";
				contentImage.transform.localScale = new Vector3 (questionSize,questionSize,0);
			}
			break;
		case (int)Types.Snowman:
			monNumberLabel.text = "NO." + type;
			if (PlayerPrefs.GetInt ("gotSnowman") == 1){
				//すでに撮った
				nameImage.spriteName = "snowmanNameImage";
				contentImage.spriteName = "snowmanImage";
				if (PlayerPrefs.GetInt ("snowmanNew") == 1) {
					//New
					newLabel.alpha = 1;
					PlayerPrefs.SetInt ("snowmanNew",0);
				} else {
					Destroy (newLabel);
				}
			} else {
				//まだ撮ってない
				nameImage.spriteName = "notGetImage";
				Destroy (newLabel);
				contentImage.spriteName = "question";
				contentImage.transform.localScale = new Vector3 (questionSize,questionSize,0);
			}
			break;
		case (int)Types.Wizard:
			monNumberLabel.text = "NO." + type;
			if (PlayerPrefs.GetInt ("gotWizard") == 1){
				//すでに撮った
				nameImage.spriteName = "wizardNameImage";
				contentImage.spriteName = "wizardImage";
				if (PlayerPrefs.GetInt ("wizardNew") == 1) {
					//New
					newLabel.alpha = 1;
					PlayerPrefs.SetInt ("wizardNew",0);
				} else {
					Destroy (newLabel);
				}
			} else {
				//まだ撮ってない
				nameImage.spriteName = "notGetImage";
				Destroy (newLabel);
				contentImage.spriteName = "question";
				contentImage.transform.localScale = new Vector3 (questionSize,questionSize,0);
			}
			break;
		case (int)Types.Mike:
			monNumberLabel.text = "NO." + type;
			if (PlayerPrefs.GetInt ("gotMike") == 1){
				//すでに撮った
				nameImage.spriteName = "mikeNameImage";
				contentImage.spriteName = "mikeImage";
				if (PlayerPrefs.GetInt ("mikeNew") == 1) {
					//New
					newLabel.alpha = 1;
					PlayerPrefs.SetInt ("mikeNew",0);
				} else {
					Destroy (newLabel);
				}
			} else {
				//まだ撮ってない
				nameImage.spriteName = "notGetImage";
				Destroy (newLabel);
				contentImage.spriteName = "question";
				contentImage.transform.localScale = new Vector3 (questionSize,questionSize,0);
			}
			break;
		case (int)Types.NormalGirl:
			monNumberLabel.text = "NO." + type;
			if (PlayerPrefs.GetInt ("gotNormalGirl") == 1){
				//すでに撮った
				nameImage.spriteName = "normalGirlNameImage";
				contentImage.spriteName = "normalGirlImage";
				if (PlayerPrefs.GetInt ("normalGirlNew") == 1) {
					//New
					newLabel.alpha = 1;
					PlayerPrefs.SetInt ("normalGirlNew",0);
				} else {
					Destroy (newLabel);
				}
			} else {
				//まだ撮ってない
				nameImage.spriteName = "notGetImage";
				Destroy (newLabel);
				contentImage.spriteName = "question";
				contentImage.transform.localScale = new Vector3 (questionSize,questionSize,0);
			}
			break;
		case (int)Types.NormalGlassWoman:
			monNumberLabel.text = "NO." + type;
			if (PlayerPrefs.GetInt ("gotNormalGlassWoman") == 1){
				//すでに撮った
				nameImage.spriteName = "normalGlassWomanNameImage";
				contentImage.spriteName = "normalGlassWomanImage";
				if (PlayerPrefs.GetInt ("normalGlassWomanNew") == 1) {
					//New
					newLabel.alpha = 1;
					PlayerPrefs.SetInt ("normalGlassWomanNew",0);
				} else {
					Destroy (newLabel);
				}
			} else {
				//まだ撮ってない
				nameImage.spriteName = "notGetImage";
				Destroy (newLabel);
				contentImage.spriteName = "question";
				contentImage.transform.localScale = new Vector3 (questionSize,questionSize,0);
			}
			break;
		default:
			monNumberLabel.text = "NO.??";
			nameImage.spriteName = "notGetImage";
			contentImage.spriteName = "question";
			Destroy (newLabel);
			contentImage.transform.localScale = new Vector3 (questionSize,questionSize,0);
			break;
		}
	}
	// Update is called once per frame
	void Update ()
	{
	
	}
}
