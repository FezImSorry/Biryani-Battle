using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

public class MyTiling : MonoBehaviour {

	public const int offsetX = 2;
	public bool leftBuddyExists = false;
	public bool rightBuddyExists = false;
	public bool reverseScale = false;
	private float spriteWidth = 0f;
	private Camera cam;
	private Transform myTransform;

	void Awake (){
		cam = Camera.main;
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer> ();
		spriteWidth = sRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (leftBuddyExists == false || rightBuddyExists == false) {
			float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;
			float rightEdge = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
			float leftEdge = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;

			if (cam.transform.position.x >= rightEdge - offsetX && rightBuddyExists == false) {
				MakeNewBuddy (1);
				rightBuddyExists = true;
			}
			else if (cam.transform.position.x <= leftEdge + offsetX && leftBuddyExists == false) {
				MakeNewBuddy (-1);
				leftBuddyExists = true;
			} 
		}
	}

	void MakeNewBuddy (int direction) {
		Vector3 newPosition = new Vector3 (myTransform.position.x + spriteWidth * direction, myTransform.position.y, myTransform.position.z);
		Transform newBuddy = Instantiate (myTransform, newPosition, myTransform.rotation) as Transform;

		if (reverseScale == true) {
			newBuddy.localScale = new Vector3 (newBuddy.localScale.x*-1, newBuddy.localScale.y, newBuddy.localScale.z);
		}
			
		newBuddy.parent = myTransform;
		if (direction > 0) {
			newBuddy.GetComponent<MyTiling>().leftBuddyExists = true;
		}
		else {
			newBuddy.GetComponent<MyTiling>().rightBuddyExists = true;
		}
	}
}
