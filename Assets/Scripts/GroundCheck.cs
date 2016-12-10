using UnityEngine;
using System.Collections;
using UnityEditorInternal;

public class GroundCheck : MonoBehaviour {

	PlayerMovement playerMovement;

	// Use this for initialization
	void Start () {
		playerMovement = PlayerMovement.instance;
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.layer == LayerMask.NameToLayer ("Ground")){
			playerMovement.OnGround ();
		} else if (collider.gameObject.layer == LayerMask.NameToLayer ("Ice")){
			if (!collider.GetComponent <Ice>().canJump){
				playerMovement.canJump = false;
			}
			playerMovement.grounded = true;
			playerMovement.onIce = true;
		}
				
	}

	void OnTriggerExit2D(Collider2D collider){
//		playerMovement.grounded = false;
		playerMovement.onIce = false;
	}

	void OnTriggerStay2D(Collider2D collider){
		if (collider.gameObject.layer == LayerMask.NameToLayer ("Ice")){
			playerMovement.onIce = true;
		}
	}
}
