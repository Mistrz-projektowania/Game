using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCompleted : MonoBehaviour {

	public GameObject PuzzleGame;
	public GameObject Puzzle;
	public GameObject PuzzleComplete;
	public GameObject GUI;
	public GameObject Game;
	public GameObject IntroPanel;
	public GameObject PuzzlePrefab;
	PuzzleState state; 
	keyG gts;
	GameManager manager;
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
		StateMachine.setState (4); 
		PuzzleGame.SetActive (false);
		GUI.SetActive (true);
		Game.SetActive (true);
	
		Puzzle.SetActive (false);
		PuzzleComplete.SetActive (false);   


	}
}
