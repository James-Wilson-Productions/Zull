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
			} else {
				playerMovement.canJump = true;
			}
			playerMovement.grounded = true;
			playerMovement.onIce = true;
		}
		int y = -120;
		print (PlayerMovement.instance.rigid.velocity.y);
		if (PlayerMovement.instance.rigid.velocity.y < y){
            PlayerMovement.instance.rigid.velocity = Vector2.zero;
			PlayerMovement.instance.Die (TutorialManager.instance.respawnPoint.position, true);
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		playerMovement.onIce = false;
	}

	void OnTriggerStay2D(Collider2D collider){
		if (collider.gameObject.layer == LayerMask.NameToLayer ("Ice")){
			playerMovement.onIce = true;
		} else if (collider.gameObject.layer == LayerMask.NameToLayer ("Ground")){
			playerMovement.OnGround ();
		}
	}
}
