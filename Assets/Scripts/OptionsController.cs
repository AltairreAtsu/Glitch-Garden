using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider, musicSlider, difficultySlider;
	public LevelManager levelManager;

	private MusicPlayer musicPlayer;

	// Use this for initialization
	void Start () {
		musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();

		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		musicSlider.value = PlayerPrefsManager.GetMusicVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
		musicPlayer.SetMusicVolume(musicSlider.value);
		AudioListener.volume = volumeSlider.value;
	}

	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetMusicVolume(musicSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);

		// Load Main Menu
		levelManager.LoadLevel(1);
	}

	public void SetDefaults(){
		PlayerPrefsManager.SetDifficulty(2);
		difficultySlider.value = 2;
		PlayerPrefsManager.SetMasterVolume(1.0f);
		volumeSlider.value = 1.0f;
		PlayerPrefsManager.SetMusicVolume(0.4f);
		musicSlider.value = 0.4f;
	}
}
