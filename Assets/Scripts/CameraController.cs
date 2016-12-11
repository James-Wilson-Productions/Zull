using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target; //player we want to follow
	public float smoothing;
	public float followDistance;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target != null && !PlayerMovement.instance.slowMo) {
			transform.position = Vector3.Lerp (transform.position, target.position + new Vector3(0,0,-followDistance), 
				smoothing*Time.deltaTime);			
		} else{
			transform.position = Vector3.Lerp (transform.position, target.position + new Vector3(0,0,-followDistance), 
				smoothing* 1/0.3f *Time.deltaTime);		
		}
	}

	public void setTarget (GameObject target){
		this.target = target.transform;
	}

	public void setSmooth(float smoothing){
		this.smoothing = smoothing;
	}
}
