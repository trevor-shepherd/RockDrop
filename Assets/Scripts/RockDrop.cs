using UnityEngine;
using System.Collections;

public class RockDrop : MonoBehaviour {

	public GameObject rock;

	private float delayTimer = 2f;
	private bool delay;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		delayTimer += Time.deltaTime;

		if (delayTimer < 1) {

			delay = false;

		} else {

			delay = true;
		}

		if (Input.GetButtonDown ("Fire1") && delay) {

			Vector3 touchPos = Input.mousePosition;
			touchPos.z = 10f;
			touchPos = Camera.main.ScreenToWorldPoint (touchPos);

			if (Physics2D.OverlapPoint (touchPos)) {

				Debug.Log ("Detected object");
			
			} else {

				GameObjectUtil.Instantiate (rock, touchPos);
			}

			delayTimer = 0;
		}
	}
}
