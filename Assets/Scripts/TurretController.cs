using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class TurretController : MonoBehaviour {
    public GameObject bullet;
    public Transform turretMuzzle;
    public Transform turretBullets;
    Animator animController;

	// Use this for initialization
	void Start () {
        animController = GetComponent<Animator>();
	}

    void Shoot() {
		SoundManager.instance.PlayTurretShoot();
        GameObject instance = (GameObject) Instantiate(bullet, turretMuzzle.position, transform.rotation);
        instance.transform.SetParent(turretBullets);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            StartCoroutine("WaitForShoot");
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        StopCoroutine("WaitForShoot");
        animController.SetBool("Shoot", false);
    }

    IEnumerator WaitForShoot() {
        SoundManager.instance.PlayTurretStartUp ();
        yield return new WaitForSeconds(0.4f);
        while (true) {
            animController.SetBool("Shoot", true);
            yield return new WaitForSeconds(2);
            animController.SetBool("Shoot", false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}