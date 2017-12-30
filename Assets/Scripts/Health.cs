using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	// Health Value
	public float health;

	public void Damage(float damage){
		// Deal damage and check death condition
		health -= damage;
		if (health <= 0){
			DestroyGameObject();
		}

	}

	// Method for Animator Use
	public void DestroyGameObject(){
		// Destroy Gameobject
		Destroy(gameObject);
	}

}
