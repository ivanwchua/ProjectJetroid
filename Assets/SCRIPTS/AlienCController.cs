using UnityEngine;
using System.Collections;

public class AlienCController : MonoBehaviour {
	public float attackDelay = 1f;
	public float aimDelay = 1f;
	private Animator animator;
	public Projectile projectile;

	public AudioClip attackSound;

	// Use this for initialization
	void Start () {
		animator = GetComponent <Animator> ();
		StartCoroutine(OnAttack());
	}

	void PlayAttackSound () {
		if (attackSound) {
			AudioSource.PlayClipAtPoint (attackSound, transform.position);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OnAttack(){
		yield return new WaitForSeconds(aimDelay);
		Aim ();
		yield return new WaitForSeconds(attackDelay); 
		Fire ();
		StartCoroutine (OnAttack ());
	}
	void Fire(){
		animator.SetInteger ("AnimState", 1);
	}
	void Aim(){
		animator.SetInteger ("AnimState", 0);
	}

	void OnShoot(){
		if (projectile) {
			Projectile falling_gem = Instantiate (projectile, transform.position, Quaternion.identity) as Projectile;
			PlayAttackSound ();
		}
	}
}
