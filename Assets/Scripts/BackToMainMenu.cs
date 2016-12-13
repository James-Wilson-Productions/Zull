using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackToMainMenu : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            StartCoroutine("WaitForMainMenu");
        }
    }

    IEnumerator WaitForMainMenu() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }
}
