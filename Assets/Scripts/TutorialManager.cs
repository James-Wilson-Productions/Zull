using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour {

    public static TutorialManager instance;

    public bool deadzone1;
    public bool deadzone2;
    public bool deadzone3;

    public Transform respawnPoint;

    public GameObject useThis;
    public GameObject spongePad;
    public GameObject deadzonePads;
    public GameObject jumpDownHere;
    void Awake() {
        instance = this;
    }

	void Start () {
        PlayerMovement.instance.yDiePosition = -66;
        respawnPoint = GameObject.Find("RespawnPoint").GetComponent<Transform>();

        MusicManager.instance.PlayMusic();
        MusicManager.instance.Mute();
        MusicManager.instance.TransitionSpecific(0);
	}
	
	void Update () {
        if (PlayerMovement.instance.isDead() && deadzone1) {
            useThis.SetActive(true);
            foreach (Bullet e in GameObject.FindObjectsOfType<Bullet>()) {
                Destroy(e.gameObject);
            }

        } else if (PlayerMovement.instance.isDead() && deadzone2) {
            spongePad.SetActive(true);
            jumpDownHere.SetActive(false);
        } else if (PlayerMovement.instance.isDead() && deadzone3) {
            deadzonePads.SetActive(true);
        }
	}

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            respawnPoint.position = other.transform.position;
            PlayerMovement.instance.spawnPosition = new Vector3(respawnPoint.position.x, respawnPoint.position.y, respawnPoint.position.z);
        }
    }
}
