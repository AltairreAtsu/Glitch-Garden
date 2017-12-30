using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	[Tooltip ("Insert Enemy Prefabs into this Array!")]
	public GameObject[] enemyPrefabs;

	[Tooltip ("Minimum Seconds Between Enemy Spawns")]
	public float spawnFrequencyMin;

	[Tooltip ("Maximum Seconds Between Enemy Spawns")]
	public float spawnFrequencyMax;

	private float lastSpawnTime;
	private float[] lastEnemySpawn;
	

	void Start () {
		// Intilize the Last Spawn times
		lastSpawnTime = Time.time;
		lastEnemySpawn = new float[enemyPrefabs.Length];

		// Set Defualt Values in the Array
		for (int i = 0; i < lastEnemySpawn.Length; i++){
			lastEnemySpawn[i] = Time.time;
		}

	}
	

	void Update () {
		// Check if the Spawner itself may now spawn another enemy
		if (Time.time - lastSpawnTime > Random.Range(spawnFrequencyMin, spawnFrequencyMax + 1f)){
			// Loop over the list of enemies
			for (int i = 0; i < enemyPrefabs.Length; i++){
				// Check if the enemy can spawn
				if(canSpawn(enemyPrefabs[i], i)){
					// Spawn the Enemy and return to avoid spawning more than one enemy per operation
					Spawn (enemyPrefabs[i]);
					return;
				}
			}
		}
	}

	void Spawn(GameObject enemy){
		// Randomly select a lane
		Transform newTransform = transform.GetChild(Random.Range (0, transform.childCount));
		// Innstantiate the Enemy
		GameObject newEnemy = Instantiate(enemy, newTransform.position, Quaternion.identity) as GameObject;
		newEnemy.transform.parent = newTransform;
		// Set the Last Spawn Time
		lastSpawnTime = Time.time;

	}

	public bool canSpawn(GameObject attacker, int index){
		Attacker attackerScript = attacker.GetComponent<Attacker>();

		if (Time.time - lastEnemySpawn[index] > attackerScript.seenEverySeconds){
			lastEnemySpawn[index] = Time.time;
			return true;
		}
		
		return false;
	}
}
