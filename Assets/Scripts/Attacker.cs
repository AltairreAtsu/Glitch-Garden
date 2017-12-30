using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Tooltip ("Average Number of Seconds Between Apearances")]
	public float seenEverySeconds;

	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
		Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
		myRigidBody.isKinematic = true;

		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

		if(!currentTarget){
			animator.SetBool("isAttacking", false);
		}
	}

	// Called from Animator durring strike
	public void StrikeCurrentTarget(float damage){
		// Check there is a target before attempting to attack
		if(currentTarget){
			currentTarget.GetComponent<Health>().Damage(damage);
		}
	}

	// Used to Enter Attack Mod
	public void Attack(GameObject target){
		// Check Target Has Health Script
		if(target.GetComponent<Health>()) {
			currentTarget = target;
		} else {
			Debug.LogWarning("No Health Script Attached to current Target!");
		}
	}

	// Getters and Setters
	public void setSpeed(float speed){
		currentSpeed = speed;
	}
}
