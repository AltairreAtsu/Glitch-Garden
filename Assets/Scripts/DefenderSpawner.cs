using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private GameObject defenderParent;
	private StarDisplay starDisplay;

	// Use this for initialization
	private void Start () {
		// Fetch the linked Game Objects
		defenderParent = GameObject.Find("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();

		// Create a Defender Parent Object if none exists
		if(defenderParent == null){
			defenderParent = new GameObject("Defenders");
		}
	}


	private void OnMouseDown(){
		Defender defender = Button.selectedDefender.GetComponent<Defender>();

		// Check if you have enough stars to purchase the Defender
		if(starDisplay.UseStars(defender.starCost) == StarDisplay.Status.SUCESS){
			CreateDefender();
		} else {
			Debug.Log ("Not Enough Stars!");
		}
	}

	private void CreateDefender(){
		// Spawn And Child the Defender
		GameObject defender = Instantiate(Button.selectedDefender, MouseToWorldPoint(), Quaternion.identity) as GameObject;
		defender.transform.SetParent(defenderParent.transform);
	}

	private Vector2 MouseToWorldPoint(){
		// Get the World Position from the Mouse Click Position
		Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// Round the values to whole numbers
		worldPoint.x = Mathf.Round(worldPoint.x);
		worldPoint.y = Mathf.Round (worldPoint.y);

		return worldPoint;
	}
}
