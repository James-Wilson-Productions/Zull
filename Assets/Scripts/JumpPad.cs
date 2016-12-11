using UnityEngine;
using System.Collections;

public class JumpPad : MonoBehaviour {

	public HingeJoint2D hinge;

	bool onJumpPad;

	void OnTriggerEnter2D(Collider2D collider){
		//if the player enter this object, then make the player a child of this object
		if (collider.tag == "Player"){
			PlayerMovement.instance.OnJumpPad();
			PlayerMovement.instance.OnGround();
			onJumpPad = true;
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		if (collider.tag == "Player"){
			PlayerMovement.instance.OffJumpPad();
			onJumpPad = false;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (onJumpPad) {
			//player can control pad with left and right
			//player can leave jump pad by jumping
			int x = (int)Input.GetAxisRaw ("Horizontal");
			JointMotor2D motor = hinge.motor;

			if (x > 0) {
				//rotate up
				motor.motorSpeed = 40f;
			} else if (x < 0) {
				//rotate down
				motor.motorSpeed = -40f;
			} else {
				motor.motorSpeed = 0f;
			}
				
			hinge.motor = motor;
		}
	}
}
