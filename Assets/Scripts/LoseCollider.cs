using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	
    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.CompareTag("playerParent")){
            col.gameObject.SetActive(false);
            col.gameObject.transform.Translate(0, -2, 0);
            GameManager.offScreen = true;
            AddForce.rotateLeft = false;
            AddForce.rotateRight = false;
        }
    }
}
