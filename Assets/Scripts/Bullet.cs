using UnityEngine;
using System.Collections;
using UnityEditor;

public class Bullet : MonoBehaviour {

    GameObject turret;
	public float speed;

	// Use this for initialization
	void Start () {
        turret = GameObject.Find("Turret");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += -turret.transform.right * Time.deltaTime * speed;
	}
}
