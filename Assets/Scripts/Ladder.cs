using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	bool playerOnLadder;

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player"){
			PlayerMovement.instance.OnLadder ();
			playerOnLadder = true;
		}
	}

//	void OnTriggerStay2D(Collider2D collider){
//		if (collider.tag == "Player" && !PlayerMovement.instance.onLadder){
//			PlayerMovement.instance.OnLadder ();
//			playerOnLadder = true;
//		}
//	}

	void OnTriggerExit2D(Collider2D collider){
		if (collider.tag == "Player" && PlayerMovement.instance.onLadder){
			PlayerMovement.instance.OffLadder ();
			playerOnLadder = false;
		}
	}

	void Update(){
		if (playerOnLadder) {
			if (transform.position.x > PlayerMovement.instance.transform.position.x) {
				//player is on the left of the ladder
				PlayerMovement.instance.transform.localScale = new Vector3 (1, 1, 1);
			} else if (transform.position.x < PlayerMovement.instance.transform.position.x) {
				PlayerMovement.instance.transform.localScale = new Vector3 (-1, 1, 1);
			}

			if (Mathf.Abs (PlayerMovement.instance.transform.position.x - transform.position.x) > 3) {
				PlayerMovement.instance.OffLadder ();
				playerOnLadder = false;
			}

		}
	}
}
