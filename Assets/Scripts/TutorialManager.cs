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
            PlayerMovement.instance.Revive();
        }
    }
}
