using UnityEngine;
using System.Collections;

public class MovingObstacle : MonoBehaviour {

	public Vector2 speed = new Vector2 (0f, 3f);
	public Vector2 direction = new Vector2 (0f, 1);
	
	// Attached to the Obstacles to move at the same speed as Background
	void FixedUpdate () {
	
		Vector3 movement = new Vector3 (speed.x * direction.x, speed.y * direction.y, 0f);

		movement *= Time.deltaTime;
		transform.Translate (movement);
	}
}
