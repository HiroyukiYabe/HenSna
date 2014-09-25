//キャラクタを生成する
//Attach to GameController

//ポーズ対応

using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	GameObject[] WayPoints;
	int posNum;
	public GameObject[] CharacterPrefabs;
	int charNum;
	int Parcent;
	public int SpawnNum;

	Score score;


	// Use this for initialization
	void Start () {
		WayPoints = GameObject.FindGameObjectsWithTag("Respawn");
		posNum = WayPoints.Length;
		charNum = CharacterPrefabs.Length;
		RandomSpawn (SpawnNum);

		score = GetComponent<Score> ();
		score.charNum = GameObject.FindGameObjectsWithTag ("Character").Length + GameObject.FindGameObjectsWithTag ("NPC").Length;
	}
	
	// Update is called once per frame
	//void Update () {}


	void RandomSpawn(int _spawnNum){
		//int pos = Random.Range (0, posNum);
		//int cha = Random.Range (0, charNum);
		Shuffle (WayPoints);

		for (int i=0; i<_spawnNum; i++) {
			int rand = GetRandom(CharacterPrefabs);
			string s = "pos:" + WayPoints[i].name + ",  char:" + CharacterPrefabs [rand].name;
			Debug.Log (s);
			if(CharacterPrefabs [rand].name!="Wizard")
				Instantiate (CharacterPrefabs [rand], WayPoints [i].transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (new Vector3 (0, Random.Range (0f, 360f), 0)));
			else{ 
				Vector2 newPosition = Random.insideUnitCircle * 50;
				Instantiate (CharacterPrefabs [rand], new Vector3(newPosition.x,0,newPosition.y)+new Vector3(100,40,100), Quaternion.Euler (new Vector3 (0, Random.Range (0f, 360f), 0)));
			}
				
		}
		Vector2 newPositionn = Random.insideUnitCircle * 50;
		
		Instantiate (CharacterPrefabs [6], new Vector3(newPositionn.x,0,newPositionn.y)+new Vector3(100,40,100), Quaternion.Euler (new Vector3 (0, Random.Range (0f, 360f), 0)));
		
	}

	void Shuffle(GameObject[] ary){
		int n = ary.Length;
		for(int i = n - 1; i > 0; i--) {
			int j = (int)Mathf.Floor(Random.value * (i + 1));
			GameObject tmp = ary[i];
			ary[i] = ary[j];
			ary[j] = tmp;
		} 
	}

	int GetRandom(GameObject[] list){
		int total=0;
		foreach (GameObject obj in list) total += obj.GetComponent<CharInfo>().spawnParcentage;

		float randomPoint = Random.value * total;
		for (int i = 0; i < list.Length; i++) {
			if (randomPoint < list[i].GetComponent<CharInfo>().spawnParcentage)
				return i;
			else
				randomPoint -= list[i].GetComponent<CharInfo>().spawnParcentage;
		}
		return list.Length - 1;
	}

}
