using UnityEngine;
using System.Collections;

public class DestroyOffscreen : MonoBehaviour {

	public float offset = 16.0f;
	public delegate void ONDestroy ();
	public event ONDestroy DestroyCallback;

	private bool offscreen;
	private float offscreenY = 36f;
	private Rigidbody2D body2D;


	void Awake () {
	
		body2D = GetComponent<Rigidbody2D> ();
	}


	void Update () {

		var posY = transform.position.y;

		if (posY > offscreenY) {

			offscreen = true;
		
		} else {

			offscreen = false;
		}

		if (offscreen) {

			OnOutOfBounds ();
		}
	}

		public void OnOutOfBounds () {

			offscreen = false;
			GameObjectUtil.Destroy(gameObject);

			if(DestroyCallback != null) {

				DestroyCallback();
			}
		}
}
