using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public AudioClip[] music;
	public float splashVolume = 1.0f;
	public float musicVolume = 0.40f;

	private AudioSource audioSource;

	private void Start () {
		// Prevent Destruction of Music PLayer
		GameObject.DontDestroyOnLoad(gameObject);

		audioSource = gameObject.GetComponent<AudioSource>();

		audioSource.volume = PlayerPrefsManager.GetMusicVolume();
		AudioListener.volume = PlayerPrefsManager.GetMasterVolume();

		if(Application.loadedLevel == 0){
			audioSource.loop = false;
			audioSource.volume = splashVolume;
			audioSource.Play();
		} else {
			audioSource.clip = music[Application.loadedLevel];
			audioSource.loop = true;
			audioSource.Play();
		}

		foreach (AudioClip clip in music){
			if(clip == null){
				Debug.LogWarning("Audio Clip missing from music Array!\n" + "All array entries must have values!");
			}
		}
	}
	
	public void OnLevelWasLoaded(){
		AudioListener.volume = PlayerPrefsManager.GetMasterVolume();
		if(music[Application.loadedLevel] != null && music[Application.loadedLevel] != audioSource.clip){
			audioSource.Stop();
			audioSource.clip = music[Application.loadedLevel];
			if(Application.loadedLevel > 0){
				audioSource.loop = true;
				audioSource.volume = musicVolume;
				audioSource.Play();
			}
		}
	}

	public void StopAndPlay(AudioClip clip){
		audioSource.Stop();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
		audioSource.loop = false;
		audioSource.clip = clip;
		audioSource.Play();
	}

	public void SetMusicVolume(float musicVolume){
		this.musicVolume = musicVolume;
		audioSource.volume = musicVolume;
	}

}
