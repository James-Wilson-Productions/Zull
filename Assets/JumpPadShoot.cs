using UnityEngine;
using System.Collections;

public class JumpPadShoot : MonoBehaviour {

	public Animator anim;

	public float power;
	[Tooltip("How long the player will be pushed: The player cannot control their movement in the air for this time")]
	public float airTime;

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Player") {
			//shoot player in the air
			PlayerMovement.instance.Push(transform.up, power, airTime);
			anim.SetTrigger ("Launch");
		}
	}
}
