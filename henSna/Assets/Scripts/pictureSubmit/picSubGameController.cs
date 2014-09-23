using UnityEngine;
using System.Collections;

public class picSubGameController : MonoBehaviour
{
		int tookPictureNum;
		public GameObject tookPicture;
		float topPicY;
		float bottomPicY;
		float interval;
		float PicPosX;
		// Use this for initialization
		void Start ()
		{
				PlayerPrefs.SetInt ("picturePoint0",0);
				tookPictureNum = PlayerPrefs.GetInt("tookPictureNum");
				topPicY = 263f;
				bottomPicY = -36f;
				PicPosX = 62f;
				interval = 528f;

				for (int i = 0; i < tookPictureNum; i++) {
						UILabel pointLabel;
						UISprite tookImage;
						string picName = "Screenshot" + i + ".png";
						int picPoint = PlayerPrefs.GetInt ("picturePoint"+i);
						Vector3 picPos;
						int index = i/2;
						if (i%2 == 0) {
								picPos = new Vector3 (PicPosX +  index * interval, topPicY, 0);
						} else {
								picPos = new Vector3 (PicPosX + index * interval , bottomPicY,0);
						}
						Debug.Log (picPos.ToString());
						GameObject prefab = (GameObject)Instantiate (tookPicture,transform.localPosition + picPos,Quaternion.identity);
						Debug.Log ("UIGrid position : "+transform.position.ToString());
						prefab.transform.parent = transform;
						prefab.transform.localScale = new Vector3 (3.489579f,2.036455f,0f);
						prefab.transform.localPosition = picPos;
						pointLabel = prefab.transform.FindChild ("priceLabel").gameObject.GetComponent<UILabel> ();
						pointLabel.text = picPoint + "円";
						tookImage = tookPicture.transform.FindChild ("tookPictureImage").gameObject.GetComponent<UISprite> ();
						tookImage.spriteName = "monster2";


				}

		}
		/*IEnumerator createPicPrefs(){
				for (int i = 0; i < tookPictureNum; i++) {
						string picName = "Screenshot" + i + ".png";
						int picPoint = PlayerPrefs.GetInt ("picturePoint"+i);
						Vector3 picPos;
						int index = i/2;
						if (i%2 == 0) {
								picPos = new Vector3 (PicPosX +  index * interval, topPicY, 0);
						} else {
								picPos = new Vector3 (PicPosX + index * interval , bottomPicY,0);
						}
						Debug.Log (picPos.ToString());
						Instantiate (tookPicture,picPos,Quaternion.identity);

				}
		}*/
}
