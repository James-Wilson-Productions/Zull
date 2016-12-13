using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
	public static PlayerMovement instance;

	public GameObject GameOverPanel;

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
	public bool onWarp;
	public bool canMove;
	bool dead;

	//temp
	public bool TutorialMode;
	public Vector3 spawnPosition;

	//warp clamps
	float warpPos;
	float warpClamp;

	//when the player drops below this point, the game will end
	public float yDiePosition;

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

		if (!onLadder && !onJumpPad && !onWarp){
			if (canMove){
				UpdateMoving ();
			}
			UpdateShieldDraw ();
		}

		UpdateJumping ();
		UpdateAnimator ();
		UpdateLadder ();
		UpdateJumpPad ();
		UpdateWarp ();
		UpdatePosition ();

		//update the time
		BendTime();

		if (Input.GetKeyDown (KeyCode.Q)){
			MusicManager.instance.Transition ();
		}
	}

	void BendTime(){
		//will make time slow do i slowmo is true
		if (slowMo){
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
		anim.SetFloat ("YFall", rigid.velocity.y);
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

	void UpdatePosition(){
		//checks if the player is above the kill line
		if (transform.position.y < yDiePosition){
			if (!TutorialMode){
				Die (transform.position, false);
			} else {
				Die (spawnPosition, true);
			}
			transform.position += Vector3.up * 1000;
			rigid.velocity = Vector2.zero;
				
		}
	}

	void UpdateShieldDraw(){
		if (!shieldDraw && moveY < 0){
			SoundManager.instance.PlayShieldDeploy ();
		}
		shieldDraw = (moveY < 0);
		if (shieldDraw && grounded){
			slowMo = true;
		}

		if (!shieldDraw && grounded){
			slowMo = false;
		}
			
	}

	void UpdateWarp(){
		if (onWarp){
			if (moveX > 0){
				rigid.velocity = new Vector2(speed * 2, 0);
			} else {
				rigid.velocity = new Vector2(speed / 2, 0);
			}
				
			//update the sprite orientation
			if (moveX != 0){
				transform.localScale = new Vector3 (moveX, 1, 1);
			}
		}
	}

	void Jump(){
		SoundManager.instance.PlayJump ();
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
		onJumpPad = true;
	}

	public void OffJumpPad(){
		onJumpPad = false;
        grounded = false;
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

	public void OnWarp(){
		rigid.isKinematic = true;
		onWarp = true;
		slowMo = true;
	}

	public void OffWarp(){
		rigid.isKinematic = false;
		onWarp = false;
		slowMo = false;
	}

	public void Die(Vector3 spawnPosition, bool TutorialMode){
		SoundManager.instance.PlaySplat ();
		dead = true;
		anim.SetTrigger ("Dead");

		if (TutorialMode){
			StartCoroutine (Revive(spawnPosition, TutorialMode));
		} else{
			OpenGameOver ();
		}
			
			
	}

	public IEnumerator Revive(Vector3 spawnPosition, bool TutorialMode){
		dead = false;
		yield return new WaitForSeconds(1.5f);
		anim.SetTrigger ("Revive");
		if (!TutorialMode){
			FragmentManager.instance.Revive();
		} else {
			transform.position = spawnPosition;
		}
			
	}

	public bool isDead(){
		return dead;
	}

	IEnumerator DontMove(float airTime){
		canMove = false;
		yield return new WaitForSeconds (airTime);
		canMove = true;
	}

	public void OpenGameOver(){
		GameOverPanel.GetComponent <Animator>().SetBool ("OpenSettings", true);
		rigid.isKinematic = true;
	}

	public void CloseGameOver(){
		GameOverPanel.GetComponent <Animator>().SetBool ("OpenSettings", false);
		rigid.isKinematic = false;
		StartCoroutine (Revive(spawnPosition, TutorialMode));
	}

	public void Back(){
		MusicManager.instance.TransitionMainMenu ();
		SceneManager.LoadScene ("MainMenu");
	}
}
