//Attach to Food

//ポーズ対応必要なし

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Food : MonoBehaviour {

	public float ExistingTime=30f;
	float deleteTimer;
	public float Scope = 25f;
	GameObject[] characters;
	float charmInterval=2.0f;
	float charmTimer;

	// Use this for initialization
	void Start () {
		characters = GameObject.FindGameObjectsWithTag("Character");
		deleteTimer = 0f;
		charmTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		deleteTimer += Time.deltaTime;
		charmTimer += Time.deltaTime;

		if (deleteTimer > ExistingTime) {
			foreach (GameObject chara in characters) {
				CharacterAI ai = chara.GetComponent<CharacterAI>();
				ai.FoodFlag = false;
			}
			Destroy (gameObject);
		}

		//Reduce call of Function
		if (charmTimer > charmInterval) {
			CharmCharacters();
			charmTimer = 0f;
		}
	}


	void CharmCharacters(){
		foreach (GameObject chara in characters) {
			if((transform.position-chara.transform.position).sqrMagnitude  < Scope*Scope){
				CharacterAI ai = chara.GetComponent<CharacterAI>();
				ai.FoodFlag = true;
				ai.nav.SetDestination(transform.position);
				ai.nav.speed = 2.0f;
				Debug.Log("Charm "+chara.name);
			}
		}
	}

}
