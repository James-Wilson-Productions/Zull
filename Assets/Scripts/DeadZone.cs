using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	public int deadZoneTime;

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player"){
			Invoke ("KillPlayer", deadZoneTime);
			print ("Player die");
		}
		print ("Player die");
	}

	void KillPlayer(){
		if (!PlayerMovement.instance.isDead()){
			PlayerMovement.instance.Die ();
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
