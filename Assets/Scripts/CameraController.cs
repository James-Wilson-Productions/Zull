using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target; //player we want to follow
	public float smoothing;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target != null && !PlayerMovement.instance.slowMo) {
			transform.position = Vector3.Lerp (transform.position, target.position + new Vector3(0,0,-1), 
				smoothing*Time.deltaTime);			
		} else{
			transform.position = Vector3.Lerp (transform.position, target.position + new Vector3(0,0,-1), 
				1*Time.deltaTime);		
		}
	}

	public void setTarget (GameObject target){
		this.target = target.transform;
	}

	public void setSmooth(float smoothing){
		this.smoothing = smoothing;
	}
}
