using UnityEngine;
using System.Collections;
//using UnityStandardAssets._2D;

//[RequireComponent(typeof (PlatformerCharacter2D))]
public class GameController : MonoBehaviour {

	//public static PlatformerCharacter2D p;
	public static GameController gc;
	//public static PrefabManager pm;

	void Start()
	{
		if (gc == null)
			gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();

		//if (p == null)
		//	p = GameObject.FindGameObjectWithTag ("Player").GetComponent<Platformer2DUserControl> ();
	}

	public Transform playerPrefab;
	public Transform spawnPoint;
	public int spawnDelay = 2;

	public IEnumerator RespawnPlayer () {
		yield return new WaitForSeconds (spawnDelay);

		Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
	}

	public static void KillPlayer (Player player) {

		Destroy (player.gameObject);
		gc.StartCoroutine (gc.RespawnPlayer ());
	}

}
