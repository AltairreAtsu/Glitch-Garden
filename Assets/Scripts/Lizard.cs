using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;

	private void Start(){
		// Fetch Components
		animator = gameObject.GetComponent<Animator>();
		attacker = gameObject.GetComponent<Attacker>();
	}
	
	private void OnTriggerEnter2D(Collider2D coll){
		// Check what triggered the collider
		if (coll.gameObject.GetComponent<Defender>() != null) {
			// If Defender start attacking
			animator.SetBool("isAttacking", true);
			attacker.Attack(coll.gameObject);
			
		}
	}
}
