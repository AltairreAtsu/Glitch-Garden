using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	[Tooltip ("Total Time until Level completion")]
	public float totalLevelTime = 30f;
	[Tooltip ("Sound Effect Played when a level is won.")]
	public AudioClip winSound;
	[Tooltip ("UI Used to display the Win Message")]
	public GameObject winMessageUI;

	private float loadTime = 0f;

	private Slider timeSlider;
	private MusicPlayer musicPlayer;
	private LevelManager levelManager;

	private bool won = false;

	private void Start(){
		timeSlider = gameObject.GetComponent<Slider>();
		timeSlider.maxValue = totalLevelTime;
		timeSlider.minValue = 0;

		musicPlayer = GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>();
		levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		winMessageUI.GetComponent<Text>().enabled = false;

		loadTime = Time.time;
	}

	private void Update () {
		if(!won){
			float timeRemanning = totalLevelTime - (Time.time - loadTime);
			timeSlider.value = timeRemanning;

			if (timeRemanning <= 0f){

				print ("winning!");
				print (totalLevelTime - (Time.time - loadTime));

				won = true;
				TriggerWin();
			}
		}
	}

	private void TriggerWin(){
		musicPlayer.StopAndPlay(winSound);
		winMessageUI.GetComponent<Text>().enabled = true;
		Invoke ("LoadNextLevel", winSound.length + 0.3f);
	}

	private void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}
}
