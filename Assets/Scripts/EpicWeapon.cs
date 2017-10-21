using UnityEngine;
using System.Collections;

public class MyWeapon : MonoBehaviour {

	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask whatToHit;

	private Transform player;
	public Transform bulletTrailPrefab;

	float timeToFire = 0;
	static Transform firePoint;

	// Use this for initialization
	void Awake () {
		//player = transform.Find ("Player");
		player = GameObject.Find("Player").transform;
		firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("No firePoint? WHAT?!");
		}
	}

	// Update is called once per frame
	void Update () {
		if (fireRate == 0) {
			if (Input.GetKeyDown (KeyCode.Q)) {
				ShootX();
			}
		}
		else {
			if (Input.GetKey (KeyCode.Q) && Time.time > timeToFire) {
				timeToFire = Time.time + 1/fireRate;
				ShootX();
			}
		} 
	}

	void ShootX () {
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		Vector2 bulletRange = new Vector2 (firePoint.position.x + 100, firePoint.position.y);

		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, bulletRange - firePointPosition, 100, whatToHit);
		EffectX(firePointPosition);

		Debug.DrawLine (firePointPosition, (bulletRange - firePointPosition) * 100, Color.cyan);
		if (hit.collider != null) {
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
			Debug.Log ("We hit " + hit.collider.name + " and did " + Damage + " damage.");
		}
	}

	void ShootY () {
		Vector2 firePointPosition = new Vector2 (player.position.x, firePoint.position.y + 1);
		Vector2 bulletRange = new Vector2 (firePoint.position.x, firePoint.position.y + 100);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, bulletRange - firePointPosition, 100, whatToHit); 
		EffectY(firePointPosition);
		Debug.DrawLine (firePointPosition, (bulletRange - firePointPosition) * 100, Color.cyan);
		if (hit.collider != null) {
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
			Debug.Log ("We hit " + hit.collider.name + " and did " + Damage + " damage.");
		}
	}

	void EffectX(Vector2 firePointPosition)
	{
		Instantiate (bulletTrailPrefab, firePointPosition, firePoint.rotation);
	}

	void EffectY(Vector2 firePointPosition)
	{
		Instantiate (bulletTrailPrefab, firePointPosition, firePoint.rotation);
	}
}
