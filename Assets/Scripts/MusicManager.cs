using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour {

	public static MusicManager instance;

	public AudioMixerSnapshot[] trackStates;
	public AudioClip[] Stabs;
	public AudioMixerSnapshot mainMenu;
	public AudioSource StabSource;
	public AudioMixerGroup Master;

	public float Volume;
	public float transitionIn;

	void Awake(){
		if (instance == null){
			instance = this;
		}

	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		transitionIn = 1.3f;
	}

	public void Transition(){
		//will change the track to one of the game tracks
		int trackNumber = Random.Range (0, trackStates.Length);
		trackStates [trackNumber].TransitionTo (transitionIn);

		//play stab
		PlayStab ();
	}

	public void TransitionMainMenu(){
		//will transition to main menu track
		mainMenu.TransitionTo (transitionIn);
		//play stab
		PlayStab ();
	}

	void PlayStab(){
		int stabNumber = Random.Range (0, Stabs.Length);
		StabSource.PlayOneShot (Stabs[stabNumber]);
	}

	public void SetVolume(float value){
		Master.audioMixer.SetFloat ("MUsicVolume", value);
		Volume = value;
	}
}
