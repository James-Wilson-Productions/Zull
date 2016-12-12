using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour {

	void Start () {
        MusicManager.instance.PlayMusic();
        MusicManager.instance.Mute();
        MusicManager.instance.TransitionSpecific(0);
	}
	
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
<<<<<<< HEAD
//            PlayerMovement.instance.Revive();
=======

>>>>>>> ae31993e70c7ad237715e1b258a6f1c224994dec
        }
    }
}
