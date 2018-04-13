using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider, musicSlider;
	public LevelManager levelManager;

	private MusicPlayer musicPlayer;

	// Use this for initialization
	void Start () {
		musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();

		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		musicSlider.value = PlayerPrefsManager.GetMusicVolume();
	}
	
	// Update is called once per frame
	void Update () {
		musicPlayer.SetMusicVolume(musicSlider.value);
		AudioListener.volume = volumeSlider.value;
	}

	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetMusicVolume(musicSlider.value);

		// Load Main Menu
		levelManager.LoadLevel(1);
	}

	public void SetDefaults(){
		PlayerPrefsManager.SetMasterVolume(1.0f);
		volumeSlider.value = 1.0f;
		PlayerPrefsManager.SetMusicVolume(0.4f);
		musicSlider.value = 0.4f;
	}
}
