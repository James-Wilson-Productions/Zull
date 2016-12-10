using UnityEngine;
using System.Collections;
using UnityEditorInternal;

public class GroundCheck : MonoBehaviour {

	PlayerMovement playerMovement;

	// Use this for initialization
	void Start () {
		playerMovement = PlayerMovement.instance;
	}
}
