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

		if (PlayerMovement.instance.onWarp){
			transform.position += -transform.right * Time.deltaTime * speed*1.5f;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player"){
			if (PlayerMovement.instance.shieldDraw){
				SoundManager.instance.PlayShieldHit ();
			} else {
				SoundManager.instance.PlayThud ();
			}

			Destroy (gameObject);
		}
	}
}