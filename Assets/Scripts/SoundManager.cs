using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

	public AudioSource ShroudSFX;
	public AudioSource SFX;
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
	public AudioClip TurretStartup;
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
		ShroudSFX.clip = Death;
		AutoPlay ();
	}

	public void PlayElevator(){
		ShroudSFX.clip = Elevator;
		ShroudSFX.Play ();
	}
	public void PlayWalk(){
		if (walk){
			ShroudSFX.clip = FootStep1;
		} else{
			ShroudSFX.clip = FootStep2;
		}
		walk = !walk;
		Play ();
	}
	public void PlayJump(){
		ShroudSFX.clip = Jump;
		AutoPlay ();
	}
	public void PlayJumpPad(){
		SFX.clip = JumpPad[Random.Range (0, JumpPad.Length)];
		SFXAutoPlay ();
	}
	public void PlayLadderClimb(){
		ShroudSFX.clip = LadderClimb;
		AutoPlay ();
	}
	public void PlayLadderHeadHit(){
		ShroudSFX.clip = LadderHeadHit;
		Play ();
	}
	public void PlayLadderSlideLoop(){
		SFX.clip = LadderSlideLoop;
		SFXAutoPlay ();
	}
	public void PlayPlatformIn(){
		SFX.clip = PlatformIn;
		SFXAutoPlay ();
	}
	public void PlayShieldDeploy(){
		ShroudSFX.clip = ShieldDeploy;
		AutoPlay ();
	}
	public void PlayShieldHit(){
		ShroudSFX.clip = ShieldHit;
		AutoPlay ();
	}
	public void PlaySplat(){
		ShroudSFX.clip = Splat[Random.Range (0, Splat.Length)];
		AutoPlay ();
	}
	public void PlaySpongePadUp(){
		SFX.clip = SpongePadUp;
		SFXAutoPlay ();
	}
	public void PlaySpongePadDown(){
		SFX.clip = SpongePadDown;
		SFXAutoPlay ();
	}
	public void PlayThud(){
		ShroudSFX.clip = Thud[Random.Range (0, Thud.Length)];
		AutoPlay ();
	}
	public void PlayTurretShoot(){
		SFX.clip = TurretShoot;
		SFXAutoPlay ();
	}
	public void PlayTurretStartUp(){
        SFX.clip = TurretStartup;
        SFXAutoPlay();
	}
	public void PlayWarp(){
		SFX.clip = Warp;
		SFXAutoPlay ();
	}

	void BendPitch(){
		ShroudSFX.pitch = Random.Range (lowPitch, highPitch);
	}

	void BendVolume(){
		ShroudSFX.volume = Random.Range (lowVolume, highVolume);
	}

	void Bend(){
		BendPitch ();
		BendVolume ();
	}

	void Reset(){
		ShroudSFX.pitch = 1;
		ShroudSFX.volume = Volume;
	}

	void AutoPlay(){
//		Bend ();
		Play ();
	}

	void SFXAutoPlay(){
		SFX.PlayOneShot (SFX.clip);
	}

	void Play(){
		ShroudSFX.PlayOneShot (ShroudSFX.clip);
//		Reset ();
	}

	void SetVolume(float value){
		ShroudSFX.volume = value;
		SFX.volume = value;
	}
}
