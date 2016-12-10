using UnityEngine;
using System.Collections;
using UnityEditor;

public class Bullet : MonoBehaviour {

    Transform turretBullets;
	public float speed;

	// Use this for initialization
	void Start () {
        turretBullets = GetComponentInParent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += -transform.right * Time.deltaTime * speed;
	}
}