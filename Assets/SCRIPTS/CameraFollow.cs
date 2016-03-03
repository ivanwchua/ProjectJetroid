using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	private Transform t;
	void Awake () {
		GetComponent<Camera> ().orthographicSize = ((Screen.height / 2.0f) / 100f);
	}

	// Use this for initialization
	void Start () {
		t = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			transform.position = new Vector3 (t.position.x, t.position.y, transform.position.z);
		}
	}
}
