using UnityEngine;
using System.Collections;

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
			transform.position += -transform.right * Time.deltaTime * speed * 1.5f;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player" && !PlayerMovement.instance.isDead()){
			if (PlayerMovement.instance.shieldDraw){
				SoundManager.instance.PlayShieldHit ();
            } else {
				SoundManager.instance.PlayThud ();
                if (PlayerMovement.instance.TutorialMode) {
                    PlayerMovement.instance.Die(PlayerMovement.instance.spawnPosition, true);
                } else {
                    PlayerMovement.instance.Die(transform.position, false);
                }
            }
            Destroy (gameObject);
		}
	}
}