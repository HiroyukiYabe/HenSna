//キャラクタを生成する
//Attach to GameController

//ポーズ対応

using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Transform[] WayPoints;
	int posNum;
	public GameObject[] CharacterPrefabs;
	int charNum;

	// Use this for initialization
	void Start () {
		posNum = WayPoints.Length;
		charNum = CharacterPrefabs.Length;
		for (int i=0; i<5; i++) RandomSpawn ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void RandomSpawn(){
		int pos = Random.Range (0, posNum);
		int cha = Random.Range (0, charNum);
		string s = "pos:" + pos + ",  char:" + cha;
		Debug.Log (s);
		Instantiate (CharacterPrefabs[cha],WayPoints[pos].position+new Vector3(0,2,0),Quaternion.identity);
	}

}
