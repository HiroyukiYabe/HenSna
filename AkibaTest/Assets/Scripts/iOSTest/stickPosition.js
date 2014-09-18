#pragma strict
public var uiTitle : GUITexture;
var flag : boolean;

function Start (){
	flag = false;
}

function Update () {
	//if(!flag){
		flag = true;
		uiTitle = GetComponent( GUITexture );
		uiTitle.pixelInset.x = 400;//Screen.width - 100;
		Debug.Log("OK");
	//}
}