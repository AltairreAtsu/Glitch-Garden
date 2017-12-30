using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;

	private void Start(){
		// Fetch Components
		animator = gameObject.GetComponent<Animator>();
		attacker = gameObject.GetComponent<Attacker>();
	}

	private void OnTriggerEnter2D(Collider2D coll){
		// Check what Triggered the Collider
		if (coll.gameObject.tag == "Stone"){
			// Jump Over Stones
			animator.SetTrigger("jump");

		} else if (coll.gameObject.GetComponent<Defender>() != null) {
			// Attack Other Defenders
			animator.SetBool("isAttacking", true);
			attacker.Attack(coll.gameObject);

		}
	}
}
