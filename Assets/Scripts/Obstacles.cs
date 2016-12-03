using UnityEngine;
using System.Collections;

public class Obstacles : MonoBehaviour, IRecycle {

	public Sprite[] sprites;
	public Vector2 colliderOffset = Vector2.zero;

	public void Restart () {

		var renderer = GetComponent<SpriteRenderer> ();
		renderer.sprite = sprites [Random.Range (0, sprites.Length)];

		var collider = GetComponent<BoxCollider2D> ();
		var size = renderer.bounds.size;                     /* I should check to see what bounds does on this line*/
		size.y += colliderOffset.y;

		collider.size = size;

		// Not quite sure what this does. It might cause problems since I am switching stuff from moving along x axis to moving along the y axis.
		collider.offset = new Vector2 (-colliderOffset.x, collider.size.y / 2 - colliderOffset.y);
	}

	public void Shutdown () {


	}
}
