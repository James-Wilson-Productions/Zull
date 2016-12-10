using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	bool playerOnLadder;
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player"){
			PlayerMovement.instance.OnLadder ();
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		if (collider.tag == "Player"){
			PlayerMovement.instance.OffLadder ();
		}
	}
}
