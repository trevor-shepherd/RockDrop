using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] prefabs;
	public float delay = 10.0f;
	public bool active = true;
	public Vector2 delayRange = new Vector2 (10, 15);

	private float spawnRange = 9f;

	// Use this for initialization
	void Start () {

		StartCoroutine (EnemyGenerator ());
	}
	
	IEnumerator EnemyGenerator () {

		yield return new WaitForSeconds (delay);

		if (active) {

			Vector3 newTransform = new Vector3 (transform.position.x + Random.Range(-spawnRange, spawnRange), transform.position.y, transform.position.z);

			GameObjectUtil.Instantiate (prefabs [Random.Range (0, prefabs.Length)], newTransform);
			ResetDelay();
		}

		StartCoroutine (EnemyGenerator ());
	}

	void ResetDelay () {

		delay = Random.Range (delayRange.x, delayRange.y);
	}
}
