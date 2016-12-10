using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour {
	public static PlayerMovement instance;

	//players states
	public enum State{
		MOVE, IDLE, AIR
	}
	State state;

	public Collider2D groundCheck;

	Rigidbody2D rigid;
	Animator anim;

	public float speed;
	public int maxSpeed;

	int moveX;
	int moveY;

	public bool grounded;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		state = State.IDLE;
		rigid = GetComponent <Rigidbody2D> ();
		anim = GetComponentInChildren <Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//player will call respective update based on state
		moveX = (int)Input.GetAxisRaw ("Horizontal");
		moveY = (int)Input.GetAxisRaw ("Horizontal");

		//will make updates that are generic to the player. eg. check if the player is on the ground
		UpdateComponents ();
		UpdateAnimator ();

		//update player based on his current state
		//will also update the animator on the players current state
		switch (state){
		case State.MOVE:
			UpdateMovement ();
			anim.SetBool ("Moving", (moveX!=0));
			break;
		case State.IDLE:
			UpdateIdle ();
			anim.SetBool ("Moving", (moveX!=0));
			break;
		case State.AIR:
			UpdateAir ();
			anim.SetBool ("Grounded", grounded);
			break;
		}
	}

	void UpdateAir(){
		if (grounded) {
			SwitchState (State.IDLE);
		}

		rigid.AddForce (new Vector2(moveX*speed, 0));
	}

	void UpdateAnimator(){
		anim.SetBool ("Grounded", grounded);
	}

	void UpdateIdle(){
		if (moveX != 0){
			state = State.MOVE;
		}
		
		rigid.velocity = new Vector2 (0, rigid.velocity.y);
	}

	void UpdateComponents(){
		//orientate the player to face right or left
		UpdateSpriteFlip ();

		//check if the player is in the air
		if (!grounded){
			SwitchState (State.AIR);
		}
		print ("running");
		if (moveX==0){
			Time.timeScale = 0.1f;
			anim.speed = 10;
		} else {
			Time.timeScale = 1;
			anim.speed = 1;
		}
	}

	void UpdateMovement(){
		if (moveX == 0){
			//the player is not moving-switch to idle
			SwitchState (State.IDLE);
		}

		if (moveY > 0){
			//the player wants to jump
		}

		rigid.AddForce (new Vector2 (1, 0)*moveX*speed, ForceMode2D.Impulse);
		//clamp players max speed
		if (rigid.velocity.magnitude > maxSpeed){
			rigid.velocity = rigid.velocity.normalized * maxSpeed;
		}

	}

	void UpdateSpriteFlip(){
		if (moveX > 0){
			transform.localScale = new Vector3 (1, 1, 1);
		} else if (moveX < 0){
			transform.localScale = new Vector3 (-1, 1, 1);
		}
	}


	public void SwitchState(State state){
		//will switch the players current state given state
		this.state = state;
	}

	public void OnGround(){
		//will set enable the player to leave the AIR state
		SwitchState (State.IDLE);
		grounded = true;
	}
}
