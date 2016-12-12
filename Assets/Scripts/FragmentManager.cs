using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public class FragmentManager : MonoBehaviour {

	public static FragmentManager instance;
	public GameObject[] fragments;
	//the first fragment the player starts on
	public Fragment initial;
	public GameObject Elevator;
	//how far the player must be from the fragment to load a new fragment
	public float loadDistance;


	//managing the fragments on the current screen
	//previous is the fragment behind the player
	//next is the fragment infront of the player
	Fragment Previous;
	Fragment Current;
	Fragment Next;

	int currentFragment;

	public int transitionNumber;
	public int transitionCount;

	void Awake(){
		instance = this;
	}
	// Use this for initialization
	void Start () {
		//set the initial fragment
		Current = initial;
		int i = Random.Range (0, fragments.Length);
		GameObject newFragment = Instantiate (fragments [i], Current.endNode.position, transform.rotation) as GameObject;
		Next = newFragment.GetComponent <Fragment> ();
		currentFragment = 1;
		transitionCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (getDistance(Current) < loadDistance){
			//remove previous fragment
			if (Previous != null){
				Destroy ((Previous.gameObject));
			}

			//make previous fragment = current fragment
			Previous = Current;
			//make current fragment = next fragment
			Current = Next;
			//instantiate a new fragment as next and make next fragment = new fragment
			int i = Random.Range (0, fragments.Length);
			//makes sure there are no repeating fragments
			if (i == currentFragment){
				i = (i + 1) % (fragments.Length);
			} else{
				currentFragment = i;
			}
			GameObject newFragment = Instantiate (fragments [currentFragment], Current.endNode.position, transform.rotation) as GameObject;
			Next = newFragment.GetComponent <Fragment> ();

			//change the track
			if (transitionCount++ > transitionNumber){
				MusicManager.instance.Transition ();
				transitionCount = 0;
			}
		}

		if (Input.GetKeyDown (KeyCode.Q)){
			MusicManager.instance.Transition ();
		}
	}

	public void Revive(){
		GameObject initialPlatform = (GameObject)Instantiate (Elevator, transform.position, transform.rotation);
		if (Next != null){
			Destroy (Next.gameObject);
		}
		if (Previous != null){
			Destroy (Previous.gameObject);
		}
		if (Current != null){
			Destroy (Current.gameObject);
		}
		
		Current = initialPlatform.GetComponent <Fragment> ();

		int i = Random.Range (0, fragments.Length);
		GameObject newFragment = Instantiate (fragments [i], Current.endNode.position, transform.rotation) as GameObject;
		Next = newFragment.GetComponent <Fragment> ();

		PlayerMovement.instance.transform.position = initialPlatform.transform.position;
		PlayerMovement.instance.Revive ();
		CameraController.instance.transform.position = PlayerMovement.instance.transform.position;
	}

	float getPlayerX(){
		//will return the x position of the player
		return PlayerMovement.instance.transform.position.x;
	}

	float getDistance(Fragment fragment){
		//returns the distance from the player and the current fragent end node
		return Mathf.Abs ( getPlayerX () - Current.endNode.position.x);
	}
}
