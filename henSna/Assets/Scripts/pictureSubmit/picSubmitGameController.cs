using UnityEngine;
using System.Collections;
using System.IO;

static class Constants{
	public const int perPagePicNum = 4;
}
public class picSubmitGameController : MonoBehaviour {

	int tookPictureNum;
	private int nowPage;
	private int lastPage;
	private int perPagePicNum = 4;
	UITexture tookPictureImage;
	UILabel priceLabel;
	GameObject nextButton;
	GameObject prevButton;

	// Use this for initialization
	void Start () {
		this.nowPage = 1;
		this.nextButton = gameObject.transform.FindChild ("nextButton").gameObject;
		this.prevButton = gameObject.transform.FindChild ("prevButton").gameObject;
		displayImage (this.nowPage);
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/

	public void displayImage(int nowPage){
		tookPictureNum = PlayerPrefs.GetInt ("tookPictureNum");
		lastPage = tookPictureNum / Constants.perPagePicNum + 1;
		int nowPagePicNum;

		if (nowPage == lastPage) {
			nowPagePicNum = tookPictureNum % Constants.perPagePicNum;
			this.nextButton.SetActive (false);
			this.prevButton.SetActive (true);
		} else {
			nowPagePicNum = Constants.perPagePicNum;
			this.nextButton.SetActive (true);
			this.prevButton.SetActive (true);
		}

		if (nowPage == 1) {
			this.prevButton.SetActive (false);

		}
		for (int i = 0; i < Constants.perPagePicNum; i++) {
			int index = i + 1;
			tookPictureImage = gameObject.transform.FindChild ("tookPictureImage" + index).gameObject.GetComponent<UITexture> ();
			priceLabel = gameObject.transform.FindChild ("priceLabel" + index).gameObject.GetComponent<UILabel> ();
			if (i < nowPagePicNum) {
				tookPictureImage.alpha = 1;
				priceLabel.alpha = 1;

				string path = "";
				switch (Application.platform) {
				case RuntimePlatform.IPhonePlayer:
					path = Application.persistentDataPath + "/Screenshot" + i + ".png";
					break;
				case RuntimePlatform.Android:
					path = Application.persistentDataPath + "/Screenshot" + i + ".png";
					break;
				default:
					path = "Screenshot" + i + ".png";
					break;
				}
				Debug.Log ("path:" + path);

				// スクリーンショットの読み込み
				byte[] image = File.ReadAllBytes (path);

				// Texture2D を作成して読み込み
				Texture2D tex = new Texture2D (0, 0);
				tex.LoadImage (image);

				// NGUI の UITexture に表示する
				tookPictureImage.mainTexture = tex;
			
			} else {
				tookPictureImage.alpha = 0;
				priceLabel.alpha = 0;
			}
		}
	}

	public void clickNextButton(){
		this.nowPage++;
		tookPictureNum = PlayerPrefs.GetInt ("tookPictureNum");
		lastPage = tookPictureNum / Constants.perPagePicNum + 1;
		if (this.nowPage > lastPage) {
			this.nowPage = lastPage;
		}
		Debug.Log (this.nowPage.ToString());
		displayImage (this.nowPage);

	}

	public void clickPrevButton(){
		this.nowPage--;
		tookPictureNum = PlayerPrefs.GetInt ("tookPictureNum");
		lastPage = tookPictureNum / Constants.perPagePicNum + 1;
		if (this.nowPage < 1) {
			this.nowPage = 1;
		}
		Debug.Log (this.nowPage.ToString());
		displayImage (this.nowPage);

	}
}
