using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	//private static GameObject selectedDefender;

	public Color highlightedColor;
	private Color defualtColor;
	private SpriteRenderer spriteRenderer;

	public GameObject defender;
	public static GameObject selectedDefender;

	private static Button[] buttons;


	void Start(){
		if(!defender){
			Debug.LogError("You Must define a Defender to spawn! " + gameObject.name);
		}

		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		defualtColor = spriteRenderer.color;

		if(buttons == null)
			buttons = GameObject.FindObjectsOfType<Button>();
	}

	public void ResetColor (){
		spriteRenderer.color = defualtColor;
	}

	private void OnMouseDown(){
		//selectedDefender = gameObject;
		foreach (Button button in buttons){
			button.ResetColor();
		}
		selectedDefender = defender;
		spriteRenderer.color = highlightedColor;

	}

	private void OnLevelWasLoaded(){
		if(buttons != null || selectedDefender != null){
			buttons = null;
			selectedDefender = null;
		}
	}
}
