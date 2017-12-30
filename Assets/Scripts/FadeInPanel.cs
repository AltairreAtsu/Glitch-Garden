using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInPanel : MonoBehaviour {

	public float fadeTime = 1.5f;
	private float elapsedTime = 0.0f;
	private Image image;

	void Start(){
		image = gameObject.GetComponent<Image>();
	}

	void Update() {
		elapsedTime += Time.deltaTime;
		image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(1f, 0f, elapsedTime / fadeTime));
		if (image.color.a == 0){
			image.enabled = false;
		}
	}

}
