using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject gun;
	private GameObject projectileParent;

	public float shotDelay = 0.7f;
	private float shotTime = 0.0f;

	private Animator animator;

	private GameObject myLaneSpawner;

	private void Start(){
		//Debug.Log (gameObject.name + " Finding Parent");
		projectileParent = GameObject.Find ("Projectiles");
		animator = gameObject.GetComponent<Animator>();
		SetMyLaneSpawner();

		if (projectileParent == null){
			CreateProjectileParent();
		}
	}

	private void Update(){
		if(IsAttackerAheadInLane()){
			animator.SetBool("isAttacking", true);
		} else {
			animator.SetBool("isAttacking", false);
		}
	}

	private void SetMyLaneSpawner(){
		GameObject mainSpawner = GameObject.Find("Spawners");

		// Loop over every child Object
		foreach (Transform child in mainSpawner.transform){
			// Check if Child Object matches Defender Lane
			if (child.position.y == gameObject.transform.position.y){
				myLaneSpawner = child.gameObject;
				return;
			}
		}

		Debug.LogError("Could not Find Lane Spawner!");
	}

	private bool IsAttackerAheadInLane(){
		if(myLaneSpawner.transform.childCount >= 0){
			foreach (Transform child in myLaneSpawner.transform){
				if(child.transform.position.x > transform.position.x)
					return true;
			}
		}

		return false;
	}

	private void CreateProjectileParent(){
		//Debug.Log (gameObject.name + " Creating Parent");
		projectileParent = new GameObject("Projectiles");
	}

	private void Fire(){
		// Check if can fire
		if(Time.time - shotTime >= shotDelay){
			GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity) as GameObject;
			newProjectile.transform.SetParent(projectileParent.transform);
			shotTime = Time.time;
		}
	}
}
