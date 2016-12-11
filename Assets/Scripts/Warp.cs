using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public GameObject bullet;
	public Transform[] spawnPositions;

	public float shootDelay;
	float nextShoot;
	bool onWarp;


	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Player") {
			PlayerMovement.instance.OnWarp ();
			onWarp = true;
		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		if (collider.tag == "Player") {
			PlayerMovement.instance.OffWarp ();
			onWarp = false;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (onWarp){
			//will only shoot if the player is in the warp
			if (Time.time > nextShoot){
				//update time
				nextShoot = Time.time + shootDelay;
				//shoot a bullet
				//choose 2 spawn positions to shoot the bullet
				int spawnPoint1 = Random.Range (0, spawnPositions.Length);
				int spawnPoint2 = Random.Range (0, spawnPositions.Length);
				if (spawnPoint2 == spawnPoint1){
					spawnPoint2 = (spawnPoint2 + 1) % spawnPositions.Length;
				}
				Instantiate (bullet, spawnPositions[spawnPoint1].position, Quaternion.Euler (transform.rotation.x,
					transform.rotation.y, 180));
//				Instantiate (bullet, spawnPositions[spawnPoint2].position, Quaternion.Euler (transform.rotation.x,
//					transform.rotation.y, 180));
			}
		}
	}
}
