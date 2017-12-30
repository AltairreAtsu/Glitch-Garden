using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {
	// Constant Player Prefs Keys
	const string MASTER_VOLUME_KEY = "master_volume";
	const string MUSIC_VOLUME_KEY = "music_volume";
	const string DIFFICULTY_KEY = "difficulty";
	//const string LEVEL_KEY = "level_unlocked_";

	// Getters and Setters
	// Master Audio Pref
	public static void SetMasterVolume(float volume){
		if (volume >= 0f && volume <= 1f){
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master Volume out of range!");
		}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	// Music Audio Pref
	public static void SetMusicVolume(float volume){
		if (volume >= 0f && volume <= 1f){
			PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Music Volume out of range!");
		}
	}
	
	public static float GetMusicVolume(){
		return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);
	}

	// Difficulty
	public static void SetDifficulty(float difficulty){
		if(difficulty >= 1f && difficulty <= 3f){
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogWarning("Difficulty out of range!");
		}
	}

	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
}
