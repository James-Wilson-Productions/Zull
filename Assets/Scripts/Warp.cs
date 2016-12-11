using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	bool onWarp;

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Player") {
			PlayerMovement.instance.OnWarp ();
		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		if (collider.tag == "Player") {
			PlayerMovement.instance.OffWarp ();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
