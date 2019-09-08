using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helpsInGame : MonoBehaviour {

	public Button sunMopOn;
	public GameController gameController;
	public GameObject leftGUI;
	public GameObject HelpfulQuestionsButton;
	public GameObject PuzzleGame;
	public GameObject Quiz;
	public GameObject GTS;
	public GameObject Scoreboard;
	public GameObject rockLabels;
	public GameObject HelpsInGame;
	// Use this for initialization
	void Start () {
		
	}

	public void ShowHelpsInGame() {
		HelpsInGame.SetActive (true);
		leftGUI.SetActive(false);
		HelpfulQuestionsButton.SetActive(false);
		PuzzleGame.SetActive (false);
		Quiz.SetActive (false);
		rockLabels.SetActive(false);
		Scoreboard.SetActive (false);
		GTS.SetActive (true);
		StateMachine.setState (9);
	}
	
	// Update is called once per frame
	void Update() {
		if (gameController.getPoints () < 2) {
			sunMopOn.interactable = false;
		}
		else sunMopOn.interactable = true;
	} 
}
