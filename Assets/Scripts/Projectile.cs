using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed = 1f;
	public float damage = 10;

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D coll){
		Health health = coll.gameObject.GetComponent<Health>();
		Attacker attacker = coll.gameObject.GetComponent<Attacker>();
		if(health && attacker){
			health.Damage(damage);
			Destroy(gameObject);
		}
	}
}
