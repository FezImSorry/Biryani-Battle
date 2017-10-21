using UnityEngine;
using System.Collections;

public class EpicWeapon : MonoBehaviour {

	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask whatToHit;

	private Transform player;
	public Transform bulletTrailPrefab;
	public Transform bulletTrailPrefabY;
	public Transform bulletTrailPrefabLeft;
	public Transform bulletTrailPrefabDown;

	private Animator m_Anim;

	float timeToFire = 0;
	static Transform firePoint;

	// Use this for initialization
	void Awake () {
		//player = transform.Find ("Player");
		player = GameObject.FindGameObjectWithTag("Player").transform;
		m_Anim = GetComponentInParent<Animator>(); //player.GetComponent<Animator>();

		firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("No firePoint? WHAT?!");
		}
	}

	// Update is called once per frame
	void Update () {

		m_Anim.SetBool ("FaceUp", false);
		m_Anim.SetBool ("FaceDown", false);

		if (m_Anim.GetBool ("Ground")) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				
				if (fireRate == 0) {
					if (Input.GetKeyDown (KeyCode.Q)) {
						m_Anim.SetBool ("Shooting", true);
						m_Anim.SetBool ("FaceUp", true);
						ShootY ();
					} else
						m_Anim.SetBool ("Shooting", false);
				} else {
					if (Input.GetKey (KeyCode.Q) && Time.time > timeToFire) {
						timeToFire = Time.time + 1 / fireRate;
						m_Anim.SetBool ("Shooting", true);
						m_Anim.SetBool ("FaceUp", true);
						ShootY ();
					} else
						m_Anim.SetBool ("Shooting", false);
				}
			} else {
				if (fireRate == 0) {
					if (Input.GetKeyDown (KeyCode.Q)) {
						m_Anim.SetBool ("Shooting", true);
						ShootX ();
					} else
						m_Anim.SetBool ("Shooting", false);
				} else {
					if (Input.GetKey (KeyCode.Q) && Time.time > timeToFire) {
						timeToFire = Time.time + 1 / fireRate;
						m_Anim.SetBool ("Shooting", true);
						ShootX ();
					} else
						m_Anim.SetBool ("Shooting", false);
				}
			}
		} else {
			if (Input.GetKey (KeyCode.UpArrow)) {

				if (fireRate == 0) {
					if (Input.GetKeyDown (KeyCode.Q)) {
						m_Anim.SetBool ("Shooting", true);
						m_Anim.SetBool ("FaceUp", true);
						ShootY ();
					} else
						m_Anim.SetBool ("Shooting", false);
				} else {
					if (Input.GetKey (KeyCode.Q) && Time.time > timeToFire) {
						timeToFire = Time.time + 1 / fireRate;
						m_Anim.SetBool ("Shooting", true);
						m_Anim.SetBool ("FaceUp", true);
						ShootY ();
					} else
						m_Anim.SetBool ("Shooting", false);
				}
			} 
			else if (Input.GetKey (KeyCode.DownArrow)) {

				if (fireRate == 0) {
					if (Input.GetKeyDown (KeyCode.Q)) {
						m_Anim.SetBool ("Shooting", true);
						m_Anim.SetBool ("FaceDown", true);
						ShootYDown ();
					} else
						m_Anim.SetBool ("Shooting", false);
				} else {
					if (Input.GetKey (KeyCode.Q) && Time.time > timeToFire) {
						timeToFire = Time.time + 1 / fireRate;
						m_Anim.SetBool ("Shooting", true);
						m_Anim.SetBool ("FaceDown", true);
						ShootYDown ();
					} else
						m_Anim.SetBool ("Shooting", false);
				}
			} else {
				if (fireRate == 0) {
					if (Input.GetKeyDown (KeyCode.Q)) {
						m_Anim.SetBool ("Shooting", true);
						ShootX ();
					} else
						m_Anim.SetBool ("Shooting", false);
				} else {
					if (Input.GetKey (KeyCode.Q) && Time.time > timeToFire) {
						timeToFire = Time.time + 1 / fireRate;
						m_Anim.SetBool ("Shooting", true);
						ShootX ();
					} else
						m_Anim.SetBool ("Shooting", false);
				}
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

	void ShootYDown () {
		Vector2 firePointPosition = new Vector2 (player.position.x, firePoint.position.y - 1);
		Vector2 bulletRange = new Vector2 (firePoint.position.x, firePoint.position.y - 100);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, bulletRange - firePointPosition, 100, whatToHit); 
		EffectYDown(firePointPosition);
		Debug.DrawLine (firePointPosition, (bulletRange - firePointPosition) * 100, Color.cyan);
		if (hit.collider != null) {
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
			Debug.Log ("We hit " + hit.collider.name + " and did " + Damage + " damage.");
		}
	}

	void EffectX(Vector2 firePointPosition)
	{
		if(player.localScale.x > 0) {
			Instantiate (bulletTrailPrefab, firePointPosition, firePoint.rotation);
		}
		else if (player.localScale.x < 0) {
			Instantiate (bulletTrailPrefabLeft, firePointPosition, firePoint.rotation);
		}
	}

	void EffectY(Vector2 firePointPosition)
	{
		Instantiate (bulletTrailPrefabY, firePointPosition, firePoint.rotation);
	}

	void EffectYDown(Vector2 firePointPosition)
	{
		Instantiate (bulletTrailPrefabDown, firePointPosition, firePoint.rotation);
	}
}
