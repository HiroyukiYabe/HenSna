using UnityEngine;
using System.Collections;

public class GemaController : MonoBehaviour {

	// Use this for initialization
		//void Start () {
	
		//}
	
	// Update is called once per frame
		//void Update () {
		//}


		public void clickPlayButton(){
				Debug.Log("click PlayButton");
				Application.LoadLevel("selectDungeon");
		}

		public void clickSettingButton(){
				Application.LoadLevel("setting");
		}

		public void clickSoundButton(){
				Debug.Log ("click sound button");
		}

		public void clickPurchaseItemButton(){
				Application.LoadLevel("purchaseItem");
		}

		public void clickCollectionButton(){
				Application.LoadLevel("collection");
		}
}
