using UnityEngine;
using System.Collections;

public class collectionGameController : MonoBehaviour
{
	enum Types
	{
		Mummy = 1,
		Pumpkin,
		Skelton,
		Knight,
		Santa,
		Snowman,
		Wizard,
		Mike,
		NormalGirl,
		NormalGlassWoman}
	;

	GameObject summeryPanel;
	GameObject detailPanel;
	UILabel nameLabel;
	UILabel expLabel;
	UISprite contentImage;
	UISprite expImage;
	int type;
	// Use this for initialization
	void Start ()
	{
		this.detailPanel = GameObject.Find ("detailPanel");
		this.summeryPanel = GameObject.Find ("UIPanel (Clipped View)");
		this.detailPanel.SetActive (false);

	}
	// Update is called once per frame
	/*void Update ()
	{
	
	}*/

	public void clickImage (GameObject obj)
	{

		Debug.Log ("click Year!!!" + obj.name);
		this.summeryPanel.SetActive (false);
		this.detailPanel.SetActive (true);

		contentImage = GameObject.Find ("contentImage").gameObject.GetComponent<UISprite> ();
		expImage = GameObject.Find ("expImage").gameObject.GetComponent<UISprite> ();
		collectionContent script = obj.GetComponent<collectionContent> ();
		this.type = script.type;
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
			if (PlayerPrefs.GetInt ("gotKnight") == 1) {
				expImage.spriteName = "knightExp";
				contentImage.spriteName = "knightImage";
			} else {
				expImage.spriteName = "notYetExp";
				contentImage.spriteName = "question";			
			}
			break;
		case (int)Types.Santa:
			if (PlayerPrefs.GetInt ("gotSanta") == 1) {
				expImage.spriteName = "santaExp";
				contentImage.spriteName = "santaImage";
			} else {
				expImage.spriteName = "notYetExp";
				contentImage.spriteName = "question";			
			}
			break;
		case (int)Types.Snowman:
			if (PlayerPrefs.GetInt ("gotSnowman") == 1) {
				expImage.spriteName = "snowmanExp";
				contentImage.spriteName = "snowmanImage";
			} else {
				expImage.spriteName = "notYetExp";
				contentImage.spriteName = "question";			
			}
			break;
		case (int)Types.Wizard:
			if (PlayerPrefs.GetInt ("gotWizard") == 1) {
				expImage.spriteName = "wizardExp";
				contentImage.spriteName = "wizardImage";
			} else {
				expImage.spriteName = "notYetExp";
				contentImage.spriteName = "question";			
			}
			break;
		case (int)Types.Mike:
			if (PlayerPrefs.GetInt ("gotMike") == 1) {
				expImage.spriteName = "mikeExp";
				contentImage.spriteName = "mikeImage";
			} else {
				expImage.spriteName = "notYetExp";
				contentImage.spriteName = "question";			
			}
			break;
		case (int)Types.NormalGirl:
			if (PlayerPrefs.GetInt ("gotNormalGirl") == 1) {
				expImage.spriteName = "normalgirlExp";
				contentImage.spriteName = "normalgirlImage";
			} else {
				expImage.spriteName = "notYetExp";
				contentImage.spriteName = "question";			
			}
			break;
		case (int)Types.NormalGlassWoman:
			if (PlayerPrefs.GetInt ("gotNormalGlassWoman") == 1) {
				expImage.spriteName = "normalGlassWomanExp";
				contentImage.spriteName = "normalGlassWomanImage";
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

	public void clickBackButton ()
	{
		Application.LoadLevel ("home");
	}

	public void clickTwitterButton ()
	{
		Debug.Log ("type is : " + this.type);
		string twitterTitle = "へんスナやろうよ！";
		string twitterBody;
		string imageURL;
		switch (this.type) {
		case (int)Types.Mummy:
			twitterBody = "わらのおばけ\n日本ホラー界のマスコット的キャラクターである。";
			imageURL = "/mummyImage.png";
			break;
		case (int)Types.Pumpkin:
			twitterBody = "かぼちゃおとこ\nかぼちゃおとこというネーミングのせいで女性はかなり肩身がせまいらしい。";
			imageURL = "/pumpkinImage.png";
			break;
		case (int)Types.Skelton:
			twitterBody = "たけし\nそんなことやってないで早く勉強しなさい。";
			imageURL = "/skeltonImage.png";
			break;
		case (int)Types.Knight:
			twitterBody = "最強マン\nおまいこそ早く勉強しなさい。";
			imageURL = "/knightImage.png";
			break;
		case (int)Types.Santa:
			twitterBody = "サンタ\n街を徘徊してたら不良にプレゼントを全部持ってかれたよ！";
			imageURL = "/santaImage.png";
			break;
		case (int)Types.Snowman:
			twitterBody = "オラフぃ\nこんな可愛い顔してやることはやってるんだって！";
			imageURL = "/snowmanImage.png";
			break;
		case (int)Types.Wizard:
			twitterBody = "ブンダルドア\n魔法とかクソ。とか言うようになったらしい。";
			imageURL = "/wizardImage.png";
			break;
		case (int)Types.Mike:
			twitterBody = "Mike\n工場長として重い責任感を持っている。";
			imageURL = "/mikeImage.png";
			break;
		case (int)Types.NormalGirl:
			twitterBody = "かな子(一般人)\n小学生にして、「魔王」が読めるらしい。";
			imageURL = "/normalGirlImage.png";
			break;
		case (int)Types.NormalGlassWoman:
			twitterBody = "マダム(一般人)\n頭の赤いバンドはメッシをイメージしてるらしい。";
			imageURL = "/normalGlassWomanImage.png";
			break;
		default:
			twitterBody = "でふぉると";
			imageURL = "/mummyImage.png";
			break;
		}
		Debug.Log (twitterTitle);
		Debug.Log (twitterBody);
		Debug.Log (Application.persistentDataPath);
		Debug.Log (Application.dataPath);
		SocialConnector.Share (
			twitterTitle,
			twitterBody, 
			Application.streamingAssetsPath + imageURL
		);
	}
}
