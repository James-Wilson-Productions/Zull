using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour {

	public static MusicManager instance;

	public AudioMixerSnapshot[] trackStates;
	public AudioClip[] Stabs;
    public AudioSource[] music;
	public AudioMixerSnapshot mainMenu;
	public AudioSource StabSource;
	public AudioMixerGroup Master;
	public AudioMixerSnapshot MuteAudio;

	public float Volume;
	public float transitionIn;
	int currentNumber;

	void Awake(){
		if (instance == null){
			instance = GameObject.FindObjectOfType <MusicManager>().GetComponent <MusicManager>();
		}
		currentNumber = 2;
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		transitionIn = 1.3f;
	}

	public void Transition(){
		//will change the track to one of the game tracks
		int trackNumber = Random.Range (0, trackStates.Length);
		if (trackNumber == currentNumber){
			currentNumber = (trackNumber + 1) % trackStates.Length;
		} else{
			currentNumber = trackNumber;
		}
		trackStates [currentNumber].TransitionTo (transitionIn);

		//play stab
		PlayStab ();
	}

	public void TransitionSpecific(int i){
		//will play a specific song
		trackStates [i].TransitionTo (transitionIn);
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
		Volume = value;
		Master.audioMixer.SetFloat ("MusicVolume", Volume);
	}

    public void PlayMusic() {
        for(int i = 0; i < music.Length; i++) {
            music[i].Play();
        }
    }

	public void Mute(){
		MuteAudio.TransitionTo (5);
	}
}
