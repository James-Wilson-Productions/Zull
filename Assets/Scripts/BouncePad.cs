using UnityEngine;
using System.Collections;

public class BouncePad : MonoBehaviour {

    Rigidbody2D rigid;
    public float bounceHeight;

	void Start () {
	
	}

	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other){
        print("OnTriggerEnter2D!");
        if (other.tag == "Player") {
            print("It's player!");
            rigid = other.GetComponent<Rigidbody2D>();
            rigid.AddForce(new Vector2(rigid.velocity.x, 50  * bounceHeight * Time.deltaTime), ForceMode2D.Impulse);
        }
    }
}
