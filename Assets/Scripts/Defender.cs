using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {
	// Being used as a Tag

	[Tooltip ("The Cost in Stars to place this defender.")]
	public int starCost = 100;

	private StarDisplay starDisplay;

	public void Start(){
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}

	public void AddStars(int amount){
		starDisplay.AddStars(amount);
	}
}
