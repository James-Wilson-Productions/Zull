using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class TurretController : MonoBehaviour {
    public GameObject bullet;
    public Transform turretMuzzle;
    public Transform turretBullets;

	// Use this for initialization
	void Start () {

	}

    void Shoot() {
        //Insert SoundManager Here
        GameObject instance = (GameObject) Instantiate(bullet, turretMuzzle.position, Quaternion.identity);
        instance.transform.SetParent(turretBullets);
    }
}
