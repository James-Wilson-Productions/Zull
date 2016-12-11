﻿using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {

	public Transform flipNode;
	public float flipDistance;
	public bool flipUp;
	Animator anim;

	void Awake(){
		transform.rotation = Quaternion.EulerAngles (90f, 0, 0);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		print (flipNode.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (getDistance () < flipDistance){
			if (flipUp){
				anim.SetTrigger ("FlipUp");
			} else {
				anim.SetTrigger ("FlipDown");
			}
				
		} else if (getDistance () > 1.3f * flipDistance){
			anim.SetTrigger ("FlipIdle");
		}

		if (Input.GetKeyDown (KeyCode.Q)){
			PrintDistance ();
		}
			

	}

	void PrintDistance(){
		print ((PlayerMovement.instance.transform.position - flipNode.transform.position).magnitude);
	}

	float getDistance(){
		return (PlayerMovement.instance.transform.position - flipNode.transform.position).magnitude;
	}
}
