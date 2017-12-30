using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarDisplay : MonoBehaviour {

	public int stars = 100;
	private Text text;

	public enum Status {SUCESS, FAILURE};

	public void Start(){
		// 
		text = gameObject.GetComponent<Text>();
		text.text = stars.ToString();
	}

	public void AddStars(int amount){
		stars += amount;
		text.text = stars.ToString();
	}

	public Status UseStars(int amount){
		if (stars >= amount){
			stars -= amount;
			text.text = stars.ToString();
			return Status.SUCESS;
		}
		return Status.FAILURE;
	}
}
