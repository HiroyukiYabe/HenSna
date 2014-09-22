using UnityEngine;
using System.Collections;

public class collectionContent : MonoBehaviour {
	enum Types{Mummy,Pumpkin,Skelton,Knight};
	public int type;

	UILabel nameLabel;
	UILabel newLabel;
	UISprite contentImage;
	// Use this for initialization
	void Start () {
		nameLabel = gameObject.transform.FindChild ("nameLabel").gameObject.GetComponent<UILabel>();
		newLabel = gameObject.transform.FindChild ("newLabel").gameObject.GetComponent<UILabel>();
		contentImage = gameObject.transform.FindChild ("UISprite").gameObject.GetComponent<UISprite>();
		switch (type) {
		case (int)Types.Mummy:
			nameLabel.text = "Mummy";
			break;
		case (int)Types.Pumpkin:
			nameLabel.text = "Pumpkin";
			if(PlayerPrefs.GetInt("GotPumpkin")==1){
				contentImage.spriteName = "chiefImage";
				if(PlayerPrefs.GetInt("PumpkinNew")==0){

				}else{

				}
			}else{
				contentImage.spriteName = "chiefImage2";
			}

			break;
		case (int)Types.Skelton:
			nameLabel.text = "Skelton";
			break;
		case (int)Types.Knight:
			nameLabel.text = "Knight";
			break;
		default:
			nameLabel.text = "Normal";
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
