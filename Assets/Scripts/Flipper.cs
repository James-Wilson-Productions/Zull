using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {

	public Transform flipNode;
	public float flipDistance;
	public bool flipUp;
	bool flip;
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
			flip = true;
		} else if (getDistance () > 1.1f * flipDistance){
			flip = false;
		}

		if (flipUp) {
			anim.SetBool ("FlipUp", flip);
		} else {
			anim.SetBool ("FlipDown", flip);
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
