using UnityEngine;
using System.Collections;

public class SoundReference : MonoBehaviour {

	SoundManager soundManager;

	void Start(){
		soundManager = GameObject.FindObjectOfType <SoundManager>().GetComponent <SoundManager>();
	}
		
	public void PlayLadderClimb(){
		SoundManager.instance.PlayLadderClimb ();
	}
	public void PlayLadderHeadHit(){
		SoundManager.instance.PlayLadderHeadHit ();
	}
	public void PlayLadderSlideLoop(){
		SoundManager.instance.PlayLadderSlideLoop ();
	}
	public void PlayShieldDeploy(){
		SoundManager.instance.PlayShieldDeploy ();
	}
	public void PlayWalk(){
		SoundManager.instance.PlayWalk ();
	}
}
