using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class MusicManager : MonoBehaviour {

	public static MusicManager instance;

	public float Volume;

//	public Music[] Tracks;


	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetVolume(float value){
		Volume = value;
	}
}
