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

	void Awake(){
		instance = this;
	}

	void Start(){
		rigid = GetComponent <Rigidbody2D> ();
		anim = GetComponentInChildren<Animator> ();
	}

	void FixedUpdate(){
		moveX = (int)Input.GetAxisRaw ("Horizontal");
		moveY = (int)Input.GetAxisRaw ("Vertical");

		UpdateMoving ();
		UpdateJumping ();
	}

	void UpdateMoving(){
		if (moveX != 0){
			rigid.velocity = new Vector2 (1, 0) * speed * moveX;
			moving = true;
			anim.SetBool ("Moving", moving);
		} else{
			moving = false;
			anim.SetBool ("Moving", moving);
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

	void Jump(){
		rigid.AddForce (Vector2.up * jumpForce);
	}

}
