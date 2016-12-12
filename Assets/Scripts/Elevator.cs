using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		StartCoroutine (OpenElevator());
        RenderSettings.ambientLight = MainMenu.ambientLighting;
	}

	IEnumerator OpenElevator(){
		yield return new WaitForEndOfFrame ();
		SoundManager.instance.PlayElevator ();
        PlayerMovement.instance.canMove = false;
		yield return new WaitForSeconds (10.612f);
		anim.SetBool ("openElevator", true);
        yield return new WaitForSeconds(2f);
        PlayerMovement.instance.canMove = true;
        MusicManager.instance.PlayMusic();
	}

}
