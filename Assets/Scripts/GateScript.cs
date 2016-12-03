using UnityEngine;
using System.Collections;

public class GateScript : MonoBehaviour {


	private GameObject player;


	// Use this for initialization
	void Awake () {
	
		player = GameObject.FindGameObjectWithTag ("Player");
	}


	void OnTriggerExit2D(Collider2D obj) {

		if (obj.gameObject.CompareTag ("Player")) {

			GameManager.currentScore ++;

		} else {

			return;
		}

	}
}
