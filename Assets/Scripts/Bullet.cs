using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    GameObject turret;

	// Use this for initialization
	void Start () {
        turret = GameObject.Find("Turret");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += -turret.transform.right;
	}
}
