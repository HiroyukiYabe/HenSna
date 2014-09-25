//Attach to BottunManager

//ポーズ対応


using UnityEngine;
using System.Collections;

public class ButtonManager_old : MonoBehaviour {
	
	UseFood useFood;
	TapDetect tapDetect;
	LightManager lightManager;
	LevelEnd levelEnd;
	
	Pauser _pauser;
	Transform PanelParent;
	GameObject MainPanel;
	GameObject ItemPanel;
	GameObject SettingPanel;
	GameObject _UIPanel;
	GameObject LightPanel;
	GameObject RetirePanel;
	
	// Use this for initialization
	void Start () {
		useFood = GameObject.Find("FoodGenerate").GetComponent<UseFood> (); 
		tapDetect = GameObject.FindWithTag ("GameController").GetComponent<TapDetect> ();
		lightManager = GameObject.Find ("LightManager").GetComponent<LightManager> ();
		levelEnd = GameObject.FindWithTag ("GameController").GetComponent<LevelEnd> ();
		_pauser = GetComponent<Pauser> ();
		_pauser.Resume();
		
		PanelParent = GameObject.Find ("Anchor").transform;
		MainPanel = PanelParent.Find ("MainPanel").gameObject;
		MainPanel.SetActive (true);
		ItemPanel = PanelParent.Find("ItemPanel").gameObject;
		ItemPanel.SetActive (false);
		SettingPanel = PanelParent.Find ("SettingPanel").gameObject;
		SettingPanel.SetActive (false);
		_UIPanel = PanelParent.Find("UIPanel").gameObject;
		_UIPanel.SetActive (false);
		LightPanel = PanelParent.Find ("LightPanel").gameObject;
		LightPanel.SetActive (false);
		RetirePanel = PanelParent.Find ("RetirePanel").gameObject;
		RetirePanel.SetActive (false);
	}
	
	// Update is called once per frame
	//void Update () {}
	
	
	public void OnItemClick(){
		_pauser.Pause ();
		//SettingPanel.SetActive (false);
		ResetAll ();
		ItemPanel.SetActive (true);
	}
	public void OnFoodClick(){
		if (useFood.CanThrow ()) {	
			useFood.ThrowFood();
			//ItemPanel.SetActive (false);
			ResetAll ();
			_pauser.Resume ();
		} else {
			//To Do
			ResetAll ();
			_pauser.Resume ();
		}
	}
	
	
	public void OnSettingClick(){
		_pauser.Pause ();
		//ItemPanel.SetActive (false);
		ResetAll ();
		SettingPanel.SetActive (true);
	}
	
	public void OnUIClick(){
		//SettingPanel.SetActive (false);
		ResetAll ();
		_UIPanel.SetActive (true);
	}
	public void OnUDClick(){
		tapDetect.SetUIController("UpDown");
		//_UIPanel.SetActive (false);
		ResetAll ();
		_pauser.Resume();
	}
	public void OnLRClick(){
		tapDetect.SetUIController("RightLeft");
		//_UIPanel.SetActive (false);
		ResetAll ();
		_pauser.Resume();
	}
	
	public void OnLightClick(){
		//SettingPanel.SetActive (false);
		ResetAll ();
		LightPanel.SetActive (true);
	}
	public void OnDayLightClick(){
		lightManager.ChangeDayLight ();
		//LightPanel.SetActive (false);
		ResetAll ();
		_pauser.Resume();
	}
	public void OnSunsetClick(){
		lightManager.ChangeSunset ();
		//LightPanel.SetActive (false);
		ResetAll ();
		_pauser.Resume();
	}
	public void OnNightClick(){
		lightManager.ChangeNight ();
		//LightPanel.SetActive (false);
		ResetAll ();
		_pauser.Resume();
	}
	
	public void OnRetireClick(){
		//SettingPanel.SetActive (false);
		ResetAll ();
		RetirePanel.SetActive (true);
	}
	public void OnYesClick(){
		_pauser.Resume();
		levelEnd.levelEnd ();
	}
	public void OnNoClick(){
		ResetAll ();
		_pauser.Resume();
	}
	
	
	public void OnQuitClick(){
		ResetAll ();
		_pauser.Resume();
	}
	
	public void ResetAll(){	
		ItemPanel.SetActive (false);
		SettingPanel.SetActive (false);
		_UIPanel.SetActive (false);
		LightPanel.SetActive (false);
		RetirePanel.SetActive (false);
	}
	
	
}