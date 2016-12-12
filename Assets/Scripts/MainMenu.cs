using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();
    }

	public void openSettings() {
        anim.SetBool("OpenSettings", true);
        StartCoroutine("WaitDebug");
    }

    IEnumerator WaitDebug() {
        yield return new WaitForSeconds(10);
        anim.SetBool("OpenSettings", false);
    }
}
