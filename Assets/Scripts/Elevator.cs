using UnityEngine;
using System.Collections;
using System.Text;

public class Elevator : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		StartCoroutine (OpenElevator());
<<<<<<< HEAD
		PlayerMovement.instance.enabled = false;
=======
        RenderSettings.ambientLight = MainMenu.ambientLighting;
>>>>>>> 593fc6e09a9e3e24c6f4d39b86af1cb246acaf99
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
