using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour {

	public bool flag = false;
	
	//フェードのスピード・大きいほど早い
	public float FadeSpeed = 2.5f;
	//MAXの透明度、0.5で不透明になる。1でも一緒。0.4だと80％ぐらいの透過度
	public float Opacity = 0.45f;
	
	private float alpha;
	private int fadeDir;
	
	void Start () {
		//テクスチャを全面描画
		guiTexture.pixelInset = new Rect ( - Screen.width/2, -Screen.height/2, Screen.width, Screen.height);
		//フラグで初期値がかわる…不必要かな？
		if(flag == true){
			alpha = 1.0f;
			fadeDir = -1;
		}else{
			alpha = 0f;
			fadeDir = 1;
		}
		Color _col = guiTexture.color;
		_col.a = alpha;
		guiTexture.color = _col;
	}
	
	void Update () {
		
		if(flag== true){
			alpha += fadeDir * FadeSpeed * Time.deltaTime;
			alpha = Mathf.Clamp(alpha,0,Opacity);
			Color _col = guiTexture.color;
			_col.a = alpha;
			guiTexture.color = _col;
			if(alpha==Opacity) flag=false;
		}else if(flag== false){
			var myDir = -1;
			alpha += myDir * FadeSpeed * Time.deltaTime;
			alpha = Mathf.Clamp01(alpha);
			Color _col = guiTexture.color;
			_col.a = alpha;
			guiTexture.color = _col;
		}
		
	}
}