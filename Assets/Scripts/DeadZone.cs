using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	public int deadZoneTime;
	public Transform spawnPosition;

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player"){
			Invoke ("KillPlayer", deadZoneTime);
			print ("Player die");
		}
		print ("Player die");
	}

	void KillPlayer(){
		if (!PlayerMovement.instance.isDead()){
			if (spawnPosition == null){
				PlayerMovement.instance.Die (FragmentManager.instance.transform.position, false);
			} else{
				PlayerMovement.instance.Die (spawnPosition.transform.position, true);
			}
				
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
