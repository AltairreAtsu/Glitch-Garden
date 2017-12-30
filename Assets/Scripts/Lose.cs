using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour {

	[Tooltip ("Amount of Enemies which can pass through the Garden before defeat triggered")]
	public int playerHealth = 3;

	private LevelManager levelManager;

	private void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManager>().GetComponent<LevelManager>();
	}

	private void OnTriggerEnter2D(Collider2D coll){
		Destroy(coll.gameObject);

		if(playerHealth > 0){
			playerHealth --;
		} else {
			TriggerLose();
		}
	}

	private void TriggerLose(){
		levelManager.LoadLevel("Lose");
	}
}
