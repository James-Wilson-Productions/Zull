using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;
using UnityEditor;

public class PlayerMovement : MonoBehaviour {
	public static PlayerMovement instance;

	Rigidbody2D rigid;
	Animator anim;

	public float jumpForce;
	public int speed;
	int moveX;
	int moveY;

	public bool slowMo;
	public bool moving;
	public bool canJump;
	public bool grounded;
	public bool shieldDraw;
	public bool onIce;
	public bool onLadder;
	public bool onJumpPad;
	bool canMove;

	void Awake(){
		instance = this;
		canMove = true;
	}

	void Start(){
		rigid = GetComponent <Rigidbody2D> ();
		anim = GetComponentInChildren<Animator> ();
	}

	void FixedUpdate(){
		moveX = (int)Input.GetAxisRaw ("Horizontal");
		moveY = (int)Input.GetAxisRaw ("Vertical");

		if (!onLadder && !onJumpPad){
			if (canMove){
				UpdateMoving ();
			}
				
			UpdateShieldDraw ();
		}

		UpdateJumping ();
		UpdateAnimator ();
		UpdateLadder ();
		UpdateJumpPad ();

		//update the time
		BendTime();
	}

	void BendTime(){
		if (shieldDraw){
			Time.timeScale = 0.3f;
			anim.speed = 1 / 0.3f;
		} else{
			Time.timeScale = 1;
			anim.speed = 1;
		}
	}

	void UpdateAnimator(){
		anim.SetBool ("Moving", moving);
		anim.SetBool ("Grounded", grounded);
		anim.SetBool ("ShieldDraw", shieldDraw);
		anim.SetBool ("Climbing", onLadder);
		anim.SetBool ("OnJumpPad", onJumpPad);
		anim.SetInteger ("YSpeed", moveY);
	}
		
	void UpdateMoving(){
		//player movement 
		moving = (moveX != 0);

		//if the player is on ice
		if (onIce){
			rigid.AddForce (new Vector2 (speed * moveX, 0));
		} else if (!shieldDraw && !onIce){
			rigid.velocity = new Vector2 (1 * speed * moveX, rigid.velocity.y);
		} else {
			rigid.velocity = new Vector2 (1 * speed * moveX, rigid.velocity.y);
		}
			

		//update the sprite orientation
		if (moveX != 0){
			transform.localScale = new Vector3 (moveX, 1, 1);
		}
	}

	void UpdateJumping (){
		if (moveY > 0 && canJump){
			Jump ();
		}
	}

	void UpdateJumpPad(){
	}

	void UpdateLadder(){
		if (onLadder){
			if (moveY > 0){
				rigid.velocity = new Vector2 (moveX * speed / 4, moveY * speed / 2);
			} else if (moveY < 0) {
				rigid.velocity = new Vector2 (moveX * speed / 4, moveY * speed);
			} else {
				rigid.velocity = new Vector2 (moveX * speed / 4, 0);
			}

		}
	}

	void UpdateShieldDraw(){
		shieldDraw = (moveY < 0);
		slowMo = shieldDraw;
	}

	void Jump(){
		rigid.velocity = Vector2.zero;
		rigid.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		canJump = false;
		grounded = false;
	}

	public void OnGround(){
		//player has come in contact with the ground
		//only called once
		grounded = true;
		canJump = true;
	}

	public void OnLadder(){
		//player has jumped on the ladder
		onLadder = true;
		rigid.isKinematic = true;
	}

	public void OffLadder(){
		//player has jumped on the ladder
		onLadder = false;
		rigid.isKinematic = false;
	}

	public void OnJumpPad(){
		rigid.isKinematic = true;
		onJumpPad = true;
	}

	public void OffJumpPad(){
		rigid.isKinematic = false;
		onJumpPad = false;
	}

	public void Push(Vector3 direction, float power, float airTime){
		//will push the player in the parsed direction with parsed power
		rigid.velocity = Vector2.zero;
		rigid.AddForce (direction*power, ForceMode2D.Impulse);

		//orientate the player to face the right direction
		if (rigid.velocity.x > 0){
			//player is moving to the right
			transform.localScale = new Vector3 (1,1,1);
		} else {
			//player is moving to the left
			transform.localScale = new Vector3 (-1,1,1);
		}
		StartCoroutine (DontMove(airTime));
	}

	IEnumerator DontMove(float airTime){
		canMove = false;
		yield return new WaitForSeconds (airTime);
		canMove = true;
	}
}
