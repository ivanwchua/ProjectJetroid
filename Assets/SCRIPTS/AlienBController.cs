using UnityEngine;
using System.Collections;

public class AlienBController: MonoBehaviour {

	private Animator animator;
	private bool withinRange;

	public AudioClip attackSound;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	void PlayAttackSound () {
		if (attackSound) {
			AudioSource.PlayClipAtPoint (attackSound, transform.position);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D target) {
		if (target.gameObject.tag == "Player") {
			withinRange = true;
			animator.SetInteger("AnimState", 1);
			PlayAttackSound ();
		}
	}
	
	void OnTriggerExit2D(Collider2D target) {
		withinRange = false;
		animator.SetInteger ("AnimState", 0);
	}

	void Attack() {
		if (withinRange) {
			GameObject jetroid = GameObject.Find ("Player");
			jetroid.GetComponent<Explode> ().OnExplode();
			animator.SetInteger ("AnimState", 0);
		}
	}
}
