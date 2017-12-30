using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]
public class Stone : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
	}

	void OnTriggerStay2D(Collider2D coll){
		if(!coll.gameObject.GetComponent<Projectile>() && !coll.gameObject.GetComponent<Fox>())
			animator.SetTrigger("underAttack");
	}
}
