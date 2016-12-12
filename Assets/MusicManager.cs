using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour {

	public static MusicManager instance;

	public AudioMixerSnapshot[] trackStates;
	public AudioMixerSnapshot mainMenu;

	public float Volume;

	float bpm = 75;
	public float transitionIn;
	float quarterNote;

	void Awake(){
		if (instance == null){
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		//get the value of one beat
		quarterNote = 60 / bpm;
		//track will take one beat to transition in
		transitionIn = 1 * quarterNote; 
	}

	public void Transition(){
		//will change the track to one of the game tracks
		int trackNumber = Random.Range (0, trackStates.Length);
		trackStates [trackNumber].TransitionTo (transitionIn);
		print ("Transition");
	}

	public void TransitionMainMenu(){
		//will transition to main menu track
	}

	public void SetVolume(float value){
		Volume = value;
	}
}
