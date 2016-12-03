using UnityEngine;
using System.Collections;

public class MissedGate : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D col) {

		if (col.gameObject.CompareTag("GameOver")) {

			GameManager.missedGate = true;
		}
	}
}
