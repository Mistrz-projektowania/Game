using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCompleted : MonoBehaviour {

	public GameObject PuzzleGame;
	public GameObject GUI;
	public GameObject Game;
	public GameObject IntroPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public enum Completed {
		win,
	}

	public void PuzzleDone() {

		keyG keyG = new keyG();
		PuzzleGame.SetActive (false);
		GUI.SetActive (true);
		Game.SetActive (true);
		StateMachine.setState (4);

	}
}
