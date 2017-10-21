using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour {

	public int moveSpeed = 1;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * Time.deltaTime * moveSpeed);
		Destroy (gameObject, 1);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Obstacle")
			Destroy (gameObject);
	}
}
