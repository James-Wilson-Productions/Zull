using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

	public AudioSource Player;
	public AudioSource ElevatorSource;
    public float Volume;

	public AudioClip[] JumpPad;
	public AudioClip[] Splat;
	public AudioClip[] Thud;
	public AudioClip Death;
	public AudioClip Elevator;
	public AudioClip FootStep1;
	public AudioClip FootStep2;
	public AudioClip Jump;
	public AudioClip LadderClimb;
	public AudioClip LadderHeadHit;
	public AudioClip LadderSlideLoop;
	public AudioClip PlatformIn;
	public AudioClip ShieldDeploy;
	public AudioClip ShieldHit;
	public AudioClip SpongePadUp;
	public AudioClip SpongePadDown;
	public AudioClip TurretShoot;
	public AudioClip Warp;

	float lowPitch = 0.8f;
	float highPitch = 1.2f;

	float lowVolume = 0.6f;
	float highVolume = 1f;

	bool walk;

	void Awake(){
		DontDestroyOnLoad (gameObject);
		if (instance == null){
			instance = GameObject.FindObjectOfType <SoundManager>().GetComponent <SoundManager>();
		}
			
	}

	public void PlayDeath(){
		Player.clip = Death;
		AutoPlay ();
	}

	public void PlayElevator(){
		Player.clip = Elevator;
		Player.Play ();
	}
	public void PlayWalk(){
		if (walk){
			Player.clip = FootStep1;
		} else{
			Player.clip = FootStep2;
		}
		walk = !walk;
		Play ();
	}
	public void PlayJump(){
		Player.clip = Jump;
		AutoPlay ();
	}
	public void PlayJumpPad(){
		Player.clip = JumpPad[Random.Range (0, JumpPad.Length)];
		AutoPlay ();
	}
	public void PlayLadderClimb(){
		Player.clip = LadderClimb;
		AutoPlay ();
	}
	public void PlayLadderHeadHit(){
		Player.clip = LadderHeadHit;
		Play ();
	}
	public void PlayLadderSlideLoop(){
		Player.clip = LadderSlideLoop;
		Play ();
	}
	public void PlayPlatformIn(){
		Player.clip = PlatformIn;
		Play ();
	}
	public void PlayShieldDeploy(){
		Player.clip = ShieldDeploy;
		AutoPlay ();
	}
	public void PlayShieldHit(){
		Player.clip = ShieldHit;
		AutoPlay ();
	}
	public void PlaySplat(){
		Player.clip = Splat[Random.Range (0, Splat.Length)];
		AutoPlay ();
	}
	public void PlaySpongePadUp(){
		Player.clip = SpongePadUp;
		AutoPlay ();
	}
	public void PlaySpongePadDown(){
		Player.clip = SpongePadDown;
		AutoPlay ();
	}
	public void PlayThud(){
		Player.clip = Thud[Random.Range (0, Thud.Length)];
		AutoPlay ();
	}
	public void PlayTurretShoot(){
		Player.clip = TurretShoot;
		AutoPlay ();
	}
	public void PlayTurretStartUp(){
		print ("insert turret start up sound");
	}
	public void PlayWarp(){
		Player.clip = Warp;
		Play ();
	}

	void BendPitch(){
		Player.pitch = Random.Range (lowPitch, highPitch);
	}

	void BendVolume(){
		Player.volume = Random.Range (lowVolume, highVolume);
	}

	void Bend(){
		BendPitch ();
		BendVolume ();
	}

	void Reset(){
		Player.pitch = 1;
		Player.volume = Volume;
	}

	void AutoPlay(){
//		Bend ();
		Play ();
	}

	void Play(){
		Player.PlayOneShot (Player.clip);
//		Reset ();
	}

	void SetVolume(float value){
		Player.volume = value;
	}
}
