using UnityEngine;
using System.Collections;
using System;

public class chiefMessage : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		int messageType;
		int seed = Environment.TickCount;
		System.Random rnd = new System.Random(seed++);
		int isRandumMessage = rnd.Next(2);
		string chiefMessage;
		UILabel chiefMessageLabel;

		if (isRandumMessage == 1) {
			rnd = new System.Random (seed++);
			switch (rnd.Next (3)) {
			case 0:
				chiefMessage = "やっほー";
				break;
			case 1:
				chiefMessage = "そやさ！";
				break;
			case 2:
				chiefMessage = "まじか！";
				break;
			default:
				chiefMessage = "default";
				break;
			}

		} else {
			messageType = rnd.Next (3);//PlayerPrefs.GetInt ("thisTimeGotType");
			switch (messageType) {
			case 0:
				//pumpkin
				chiefMessage = "かぼちゃの化け物を撮ったな！\n";
				break;
			case 1:
				//skelton
				chiefMessage = "ガイコツを撮ったな！まじか！";
				break;
			case 2:
				//knight
				chiefMessage = "騎士ってかっこいいよね。\n俺もあんな風になりたいぜ！";
				break;
			case 3:
				//mummy
				chiefMessage = "ミイラ撮ったんだってな！\nこいつに出くわしたら夜も寝れないんじゃないか？";
				break;
			default:
				chiefMessage = "おまい、もしかして何も撮れなかったのか？？\n勘弁してくれ！";
				break;
			}

			transform.gameObject.GetComponent<UILabel> ().text = chiefMessage;

		}

	}

}

