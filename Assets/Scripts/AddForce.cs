using UnityEngine;
using System.Collections;

public class AddForce : MonoBehaviour {

	public float vel = 1.5f;
	public float speed = 10f;
	public float ispeed = 10f;

	private Rigidbody2D rb;
    private GameObject leaf;
	public static bool rotateRight = false;
	public static bool rotateLeft = false;


	// This script is attached to the Player to Addforce when the empty GameObject comes into contact with an Obstacle.

	// Finds the Rigidbody2D on the Player.
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
        leaf = transform.Find("Leaf").gameObject;
	}

	void Update(){

        // This makes sure that the Leaf keeps moving towards y=12
		transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, 12f, transform.position.z), Time.deltaTime * speed);

        // After the Leaf is done rotating right or left, it rotates back to straight
		if (!rotateLeft & !rotateRight) {
			leaf.transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0, 0, 0), Time.deltaTime * ispeed);
		}

		if (rotateRight) {
            RotateRight();
		}

		if (rotateLeft) {
            RotateLeft();
		}

	}

	private IEnumerator Delay()
	{
		yield return new WaitForSeconds (.5f);
	}

    // This is called when the leaf makes contact with the right side of the rock, and it rotates the leaf to the right
    void RotateRight()
    {
        leaf.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 50), Time.deltaTime * ispeed);
        Delay();
    }

    // This is called when the leaf makes contact with the left side of the rock, and it rotates the leaf to the left
    void RotateLeft ()
    {
        leaf.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 310), Time.deltaTime * ispeed);
        Delay();
    }

	// Compares the x position of player to the obstacle when first colliding and adds force left or right depending on the position.
	void OnTriggerStay2D (Collider2D col) {

		if (col.gameObject.CompareTag("Obstacle")){
			
			if (this.transform.position.x >= col.transform.position.x) {

				rb.AddForce (new Vector2 (vel, 0f));
				rotateRight = true;

			} else {

				rb.AddForce(new Vector2 (-vel, 0f));
				rotateLeft = true;
			}
		}
	}

	// After the GameObject attached to the player exits the obstacle, both bools are set to false
	void OnTriggerExit2D (Collider2D col) {

        rotateLeft = false;
        rotateRight = false;
    }
}
