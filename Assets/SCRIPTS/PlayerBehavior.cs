using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {
	public float speed = 10f;
	public float jetSpeed = 15f;
	public Vector2 maxVelocity = new Vector2(3, 5);
	public float airSpeedMultiplier = .3f;
	public bool standing = true;

	private PlayerController controller;
	private Animator animator;

	public AudioClip leftFootSound;
	public AudioClip rightFootSound;
	public AudioClip thudSound;
	public AudioClip rocketSound;

	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController> ();
		animator = GetComponent<Animator> ();
	}

	void PlayLeftFootSound () {
		if (leftFootSound) {
			AudioSource.PlayClipAtPoint (leftFootSound, transform.position);
		}
	}

	void PlayRightFootSound () {
		if (rightFootSound) {
			AudioSource.PlayClipAtPoint (rightFootSound, transform.position);
		}
	}
	
	void OnCollisionEnter2D () {
		if (!standing) {
			var absVelocityX = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);
			var absVelocityY = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.y);

			if (absVelocityX <= .1f && absVelocityY <= .1f) {
				AudioSource.PlayClipAtPoint (thudSound, transform.position);
			}
		}
	}

	void PlayRocketSound ()  {
		bool checkRocketPlaying = GameObject.Find ("RocketSound");

		if (rocketSound && !checkRocketPlaying) {
			GameObject go = new GameObject ("RocketSound");
			AudioSource src = go.AddComponent<AudioSource> ();
			src.clip = rocketSound;
			src.volume = 0.1f;
			src.Play ();
			Destroy (GameObject.Find("RocketSound"), rocketSound.length);
		}
	}
	
	// Update is called once per frame
	void Update () {
		var forceX = 0f;
		var forceY = 0f;

		var absValx = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x);
		var absValy = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y);

		if (absValy < .2f) {
			standing = true;
		} else {
			standing = false;
		}

		if (controller.moving.x != 0) {
			if (absValx < maxVelocity.x) {
				forceX = standing ? speed * controller.moving.x : (speed * controller.moving.x * airSpeedMultiplier);
				transform.localScale = new Vector3 (forceX > 0 ? 1 : -1, 1, 1);
			}
			animator.SetInteger ("AnimState", 1);
		} else {
			animator.SetInteger("AnimState",0);
		}
		if (controller.moving.y > 0) { 
			PlayRocketSound ();
			if (absValy < maxVelocity.y) {
				forceY = jetSpeed * controller.moving.y;
			}
			animator.SetInteger ("AnimState", 2);
		}

		GetComponent<Rigidbody2D>().AddForce (new Vector2(forceX, forceY));
	}
}
