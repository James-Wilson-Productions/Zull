using UnityEngine;
using System.Collections;
using System.Text;

public class Elevator : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		StartCoroutine (OpenElevator());
		PlayerMovement.instance.enabled = false;
        RenderSettings.ambientLight = MainMenu.ambientLighting;
	}

	IEnumerator OpenElevator(){
		yield return new WaitForEndOfFrame ();
		MusicManager.instance.Mute ();
		SoundManager.instance.PlayElevator ();
		yield return new WaitForSeconds (10.612f);
		anim.SetBool ("openElevator", true);
        yield return new WaitForSeconds(2f);
        PlayerMovement.instance.enabled = true;
        MusicManager.instance.PlayMusic();
		MusicManager.instance.TransitionSpecific (2);
	}

}
