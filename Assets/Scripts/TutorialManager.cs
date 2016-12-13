using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour {

    public static TutorialManager instance;

    public bool deadzone1;
    public bool deadzone2;

    Transform respawnPoint;
    void Awake() {
        instance = this;
    }

	void Start () {
        respawnPoint = GameObject.Find("RespawnPoint").GetComponent<Transform>();
        MusicManager.instance.PlayMusic();
        MusicManager.instance.Mute();
        MusicManager.instance.TransitionSpecific(0);
	}
	
	void Update () {
        if (PlayerMovement.instance.isDead()) {

        }
	}

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            respawnPoint.position = other.transform.position;
            PlayerMovement.instance.spawnPosition = new Vector3(respawnPoint.position.x, respawnPoint.position.y, respawnPoint.position.z);
        }
    }
}
