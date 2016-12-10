using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player"){
			PlayerMovement.instance.OnLadder ();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
