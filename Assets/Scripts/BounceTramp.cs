using UnityEngine;
using System.Collections;

public class BounceTramp : MonoBehaviour {

    Rigidbody2D rigid;
    Animator anim;
    public float bounceHeight;

	void Start () {
        anim = GetComponent<Animator>();
	}

	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player") {
            //TODO: Insert Hydraulic swoosh sound here
			PlayerMovement.instance.grounded = false;
            anim.SetTrigger("DisperseParticle");
            rigid = other.GetComponent<Rigidbody2D>();
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.AddForce(new Vector2(rigid.velocity.x, 50  * bounceHeight * Time.deltaTime), ForceMode2D.Impulse);
        }
    }
}
