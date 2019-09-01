using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundController : MonoBehaviour {

	private static AudioSource ambientGameplaySound;
	// Use this for initialization
	void Start () {
		ambientGameplaySound = GameObject.Find ("ambientGameplaySound").GetComponent<AudioSource> ();
		AudioListener.volume = GameplayModel.gameVolume;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void pauseSound(AudioSource sound){
		if(sound.isPlaying) sound.Pause();
	}

	public static void playSound(AudioSource sound){
		if(!sound.isPlaying) sound.Play ();
	}

	public static void playAmbientGameplaySound(){
		playSound (ambientGameplaySound);
	}
	public static void pauseAmbientGameplaySound(){
		pauseSound (ambientGameplaySound);
	}
}
