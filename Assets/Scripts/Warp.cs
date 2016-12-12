using UnityEngine;
using System.Collections;
using System;

public class Warp : MonoBehaviour {

	bool onWarp;

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Player") {
			PlayerMovement.instance.OnWarp ();
			SoundManager.instance.PlayWarp ();
			CenterPlayer ();
		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		if (collider.tag == "Player") {
			PlayerMovement.instance.OffWarp ();
			SoundManager.instance.PlayPlatformIn ();
		}
	}

	void Update(){
		if (onWarp){
			if (Mathf.Abs (PlayerMovement.instance.transform.position.x - transform.position.x) > 80){
				PlayerMovement.instance.OffWarp ();
			}
		}
	}

	void CenterPlayer(){
		PlayerMovement.instance.transform.position = new Vector3 (PlayerMovement.instance.transform.position.x, 
			transform.position.y + 3, PlayerMovement.instance.transform.position.z);
	}
}
