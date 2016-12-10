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
		}
	}

	void OnTriggerStay2D(Collider2D collider){
		if (collider.gameObject.layer == LayerMask.NameToLayer ("Ground")){
			playerMovement.grounded = true;
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		if (collider.gameObject.layer == LayerMask.NameToLayer ("Ground")){
			playerMovement.grounded = false;
		}
	}
}
