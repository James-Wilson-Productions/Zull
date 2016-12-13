using UnityEngine;
using System.Collections;

public class Deadzone2 : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            TutorialManager.instance.deadzone2 = true;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        OnTriggerEnter2D(other);
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            TutorialManager.instance.deadzone2 = false;
        }
    }
}
