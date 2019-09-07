using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startPuzzle : MonoBehaviour {

	public GameObject mainCamera;
	public GameObject puzzleCamera;
	public GameObject leftGUI;
	public GameObject Game;
	public GameObject PuzzleGame;
	public GameObject HelpsInGame;
	public GameObject puzzleMenu;
	public GameObject EndGame;
	public GameController gameController;
	public GameObject noPointMessage;
	public GameObject wrongInputMEssage;
	public GameObject QuestionPanel;
	public GameObject Scoreboard;
	public GameObject questions;
	public GameObject questionsCamera;
	public GameObject Quiz;

	// Use this for initialization
	void Start () {
		
	}

	public void ShowPuzzleView()
	{
		leftGUI.SetActive(false);
		Game.SetActive(true);
		mainCamera.SetActive(false);
		noPointMessage.SetActive(false);
		wrongInputMEssage.SetActive(false);
		puzzleCamera.SetActive(true);
		puzzleMenu.SetActive(true);
		PuzzleGame.SetActive (true);
		QuestionPanel.SetActive(false);
		questions.SetActive(false);
		questionsCamera.SetActive(false);
		HelpsInGame.SetActive (false);
		Quiz.SetActive (false);
		Scoreboard.SetActive (false);
		EndGame.SetActive (false);
		StateMachine.setState (5);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
