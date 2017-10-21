using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[System.Serializable]
	public class PlayerStats {
		public int health = 100;
	}

	//private Transform player;
	public int pitPosition = -5;
	public PlayerStats playerStats = new PlayerStats();

	void Awake() {
		//player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update() {
		if (transform.position.y <= pitPosition)
			DamagePlayer (99999);
	}

	public void DamagePlayer(int damage) {
		playerStats.health -= damage;

		if (playerStats.health <= 0) {
			GameController.KillPlayer (this);
		}
	}

}
