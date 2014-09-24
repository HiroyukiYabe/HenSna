//Attach to BottunManager

//ポーズ対応


using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {

	UseFood useFood;
	TapDetect tapDetect;
	LightManager lightManager;
	LevelEnd levelEnd;

	Pauser _pauser;
	Transform PanelParent;
	GameObject _Main;
	UIPanel MainPanel;
	GameObject _Item;
	UIPanel ItemPanel;
	GameObject _Setting;
	UIPanel SettingPanel;
	GameObject _UI;
	UIPanel _UIPanel;
	GameObject _Light;
	UIPanel LightPanel;
	GameObject _Retire;
	UIPanel RetirePanel;
	
	// Use this for initialization
	void Start () {
		useFood = GameObject.Find("FoodGenerate").GetComponent<UseFood> (); 
		tapDetect = GameObject.FindWithTag ("GameController").GetComponent<TapDetect> ();
		lightManager = GameObject.Find ("LightManager").GetComponent<LightManager> ();
		levelEnd = GameObject.FindWithTag ("GameController").GetComponent<LevelEnd> ();
		_pauser = GetComponent<Pauser> ();
		_pauser.Resume();

		PanelParent = GameObject.Find ("Anchor").transform;
		_Main = PanelParent.Find ("MainPanel").gameObject;
		_Main.SetActive (true);
		MainPanel = _Main.GetComponent<UIPanel> ();
		_Item = PanelParent.Find("ItemPanel").gameObject;
		_Item.SetActive (true);
		ItemPanel=_Item.GetComponent<UIPanel> ();
		_Setting = PanelParent.Find ("SettingPanel").gameObject;
		_Setting.SetActive (true);
		SettingPanel=_Setting.GetComponent<UIPanel> ();
		_UI = PanelParent.Find("UIPanel").gameObject;
		_UI.SetActive (true);
		_UIPanel=_UI.GetComponent<UIPanel> ();
		_Light = PanelParent.Find ("LightPanel").gameObject;
		_Light.SetActive (true);
		LightPanel=_Light.GetComponent<UIPanel> ();
		_Retire = PanelParent.Find ("RetirePanel").gameObject;
		_Retire.SetActive (true);
		RetirePanel=_Retire.GetComponent<UIPanel> ();
		ResetAll ();
	}
	
	// Update is called once per frame
	//void Update () {}


	public void OnItemClick(){
		_pauser.Pause ();
		ResetAll ();
		ItemPanel.alpha=1.0f;
	}
		public void OnFoodClick(){
			if (useFood.CanThrow ()) {	
				useFood.ThrowFood();
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
		ResetAll ();
		SettingPanel.alpha=1.0f;
	}
	
		public void OnUIClick(){
			ResetAll ();
			_UIPanel.alpha=1.0f;
		}
			public void OnUDClick(){
				tapDetect.SetUIController("UpDown");
				ResetAll ();
				_pauser.Resume();
			}
			public void OnLRClick(){
				tapDetect.SetUIController("RightLeft");
				ResetAll ();
				_pauser.Resume();
			}

		public void OnLightClick(){
			ResetAll ();
			LightPanel.alpha=1.0f;
		}
			public void OnDayLightClick(){
				lightManager.ChangeDayLight ();
				ResetAll ();
				_pauser.Resume();
			}
			public void OnSunsetClick(){
				lightManager.ChangeSunset ();
				ResetAll ();
				_pauser.Resume();
			}
			public void OnNightClick(){
				lightManager.ChangeNight ();
				ResetAll ();
				_pauser.Resume();
			}

		public void OnRetireClick(){
			ResetAll ();
			RetirePanel.alpha=1.0f;
		}
			public void OnYesClick(){
				ResetAll ();
				_pauser.Resume();
				levelEnd.isend = true;
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
		ItemPanel.alpha=0.0f;
		SettingPanel.alpha=0.0f;
		_UIPanel.alpha=0.0f;
		LightPanel.alpha=0.0f;
		RetirePanel.alpha=0.0f;
	}
	public void InVisibleAll(){
		MainPanel.alpha = 0.0f;
		ItemPanel.alpha=0.0f;
		SettingPanel.alpha=0.0f;
		_UIPanel.alpha=0.0f;
		LightPanel.alpha=0.0f;
		RetirePanel.alpha=0.0f;
	}

}
