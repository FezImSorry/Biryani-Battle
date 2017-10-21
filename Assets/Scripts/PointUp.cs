using UnityEngine;
using System.Collections;

public class PointUp : MonoBehaviour {

	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.localScale.x < 0) {
			Vector3 theScale = player.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
/*
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (player.localScale.x > 0) {
				if (transform.position.x > player.position.x && transform.rotation.z < 90) {
					transform.Translate (Vector3.up * Time.deltaTime * 0.5f);
					transform.Rotate (0, 0, 90);
				}
			} 
			else {
				if (transform.position.x < player.position.x && transform.rotation.z > -90) {
					transform.Translate (Vector3.up * Time.deltaTime * 0.5f);
					transform.Rotate (0, 0, 90);
				}
			}
		}

		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			if (player.localScale.x > 0) {
				if (transform.position.x > player.position.x && transform.rotation.z < 90) {
					transform.Translate (Vector3.up * Time.deltaTime * 0.5f);
					transform.Rotate (0, 0, -90);
				}
			} 
			else {
				if (transform.position.x < player.position.x && transform.rotation.z > -90) {
					transform.Translate (Vector3.up * Time.deltaTime * 0.5f);
					transform.Rotate (0, 0, -90);
				}
			}
		}*/
	}
}
