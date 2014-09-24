using UnityEngine;
using System.Collections;

public class Test1 : MonoBehaviour {

	public GameObject cam;
	public BackgroundRenderBasic target;
	public GameObject model = null;
	
	void Start()
	{
		target = cam.GetComponent<BackgroundRenderBasic> ();
		target.result = ()=>
		{
			//renderer.material.mainTexture = target.screenshot;
			guiTexture.texture = target.screenshot;
		};
	}
	
	void OnGUI()
	{
		if( GUILayout.Button("camera "+ ((target.gameObject.activeSelf)?"off":"on")) )
		{
			target.gameObject.SetActive(!target.gameObject.activeSelf);
		}
		
		/*if( GUILayout.Button("model "+ ((model.activeSelf)?"hide":"show")) )
		{
			model.SetActive(!model.activeSelf);
		}*/
		
	}
}