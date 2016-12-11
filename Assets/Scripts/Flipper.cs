using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {


	public float flipDistance;
	public bool flipUp;
	Animator anim;

	void Awake(){
		transform.rotation = Quaternion.EulerAngles (90f, 0, 0);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.EulerAngles (90f, 0, 0);

		print ("Rotation: "+transform.rotation.x);

		if (Mathf.Abs (PlayerMovement.instance.transform.position.x - transform.position.x) < flipDistance){
			if (flipUp){
				anim.SetTrigger ("FlipUp");
			} else {
				anim.SetTrigger ("FlipDown");
			}
				
		}

	}

	void PrintDistance(){
		print (Mathf.Abs (PlayerMovement.instance.transform.position.x - transform.position.x));
	}
}
