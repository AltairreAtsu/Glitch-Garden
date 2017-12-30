using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float splashDelay = 3.0f;
	private bool autoLoad = false;

	public GameObject musicPlayerPrefab;
	private GameObject musicPlayerInstance;

	// Use this for initialization
	private void Start () {
		if(Application.loadedLevel == 0 || autoLoad)
			// Call Next Level
			Invoke("LoadNextLevel", splashDelay);
		FindOrCreateMusicPlayer();
	}

	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void LoadLevel (int index){;
		Application.LoadLevel(index);
	}

	public void LoadLevel (string name){;
		Application.LoadLevel(name);
	}

	// Quit Application
	public void QuitRequest(){
		Application.Quit();
	}

	private void OnLevelWasLoaded(){
		FindOrCreateMusicPlayer();
	}

	private void FindOrCreateMusicPlayer(){
		musicPlayerInstance = GameObject.Find("MusicPlayer");

		if(musicPlayerInstance == null){
			musicPlayerInstance = Instantiate(musicPlayerPrefab) as GameObject;
			musicPlayerInstance.name = "MusicPlayer";
		}
	}

	// Getters and Setters
	public bool getAutoLoad(){
		return autoLoad;
	}
	public void setAutoLoad(bool autoLoad){
		this.autoLoad = autoLoad;
	}
	

}
