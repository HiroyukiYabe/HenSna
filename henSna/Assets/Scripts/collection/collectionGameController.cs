using UnityEngine;
using System.Collections;

public class collectionGameController : MonoBehaviour
{
		enum Types
		{
				Mummy=1,
				Pumpkin,
				Skelton,
				Knight
		};

		GameObject summeryPanel;
		GameObject detailPanel;
		UILabel nameLabel;
		UILabel expLabel;
		UISprite contentImage;

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

		public void clickImage(GameObject obj){

				Debug.Log ("click Year!!!" + obj.name);
				this.summeryPanel.SetActive (false);
				this.detailPanel.SetActive (true);

				nameLabel = GameObject.Find ("nameLabel").gameObject.GetComponent<UILabel>();
				expLabel = GameObject.Find ("expLabel").gameObject.GetComponent<UILabel>();
				contentImage = GameObject.Find ("contentImage").gameObject.GetComponent<UISprite> ();

				collectionContent script = obj.GetComponent<collectionContent> ();
				int type = script.type;
				Debug.Log ("type is :" + type);
				switch(type){
				case (int)Types.Mummy:
						nameLabel.text = "obake of wara";
						expLabel.text = "yes,I am obake of wara";
						contentImage.spriteName = "mummyImage";
						break;
				case (int)Types.Pumpkin:
						nameLabel.text = "かぼちゃおとこ";
						expLabel.text = "かぼちゃおとこという\nネーミングのせいで\n女性はかなり肩身が\nせまい思いをしている\nらしい。";
						contentImage.spriteName = "pumpkinImage";
						break;
				case (int)Types.Skelton:
						nameLabel.text = "たけし";
						expLabel.text = "たけし、こんなこと\nやってないで早く\n就職しなさい。";
						contentImage.spriteName = "skeltonImage";
						break;
				case (int)Types.Knight:
						nameLabel.text = "さいきょうマン";
						expLabel.text = "めっちゃつよい。";
						contentImage.spriteName = "knightImage";
						break;
				default:
						nameLabel.text = "まだでてないよ";
						expLabel.text = "まだでてないよ";
						contentImage.spriteName = "question";
						break;
				}
		}

		public void clickBackDetailButton(){
				Debug.Log ("click back detail button");
				this.summeryPanel.SetActive (true);
				this.detailPanel.SetActive (false);
		}
}
