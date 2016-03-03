using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {
	
	public AudioClip pickUpSound;

	// Use this for initialization
	void Start () {
	
	}
	
	void PlayPickUpSound () {
		if (pickUpSound) {
			AudioSource.PlayClipAtPoint (pickUpSound, transform.position);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D target) {
		if(target.gameObject.tag == "Player") {
			PlayPickUpSound ();
			Destroy (gameObject);
		}

	}
}
