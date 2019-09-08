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
	public GameObject mainCamera;
	public GameObject PuzzlePrefab;
	public GameObject PuzzleCamera;
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
		PuzzleCamera.SetActive (false);
		GUI.SetActive (true);
		mainCamera.SetActive (true);

		PuzzleComplete.SetActive (false); 
		Puzzle.SetActive (false);
		PuzzleGame.SetActive (false);
	}
}
