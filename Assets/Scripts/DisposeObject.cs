using UnityEngine;
using System.Collections;

public class DisposeObject : MonoBehaviour {

    public float destroyAfterSecs;

	void Start () {
        Destroy(gameObject, destroyAfterSecs);
	}
}