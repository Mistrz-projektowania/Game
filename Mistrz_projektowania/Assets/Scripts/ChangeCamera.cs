using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCamera : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject puzzleCamera;
    public GameObject leftGUI;
    public GameObject Game;
    public GameObject rockLabels;
    public GameObject noPointMessage;
    public GameObject wrongInputMEssage;
    public GameObject QuestionPanel;
    public GameObject questions;
	public GameObject Quiz;
	public GameObject GUI;
    public GameObject questionsCamera;
    public GameObject GTSBtn;
    public GameObject HelpfulQuestionsButton;
    public GameObject RoundGoodOverPanel;
	public GameObject PuzzleGame;
	public GameObject Puzzle;
	public GameObject PuzzleCompleted;
    public GameObject questionDisplay;
    public GameObject roundBadEndDisplay;
    public GameObject AnswerPanel;
    public GameObject roundGoodOverDisplay;
	public GameObject PuzzlePictures1;
	public GameObject PuzzlePictures2;
	public GameObject HelpsInGame;
	public GameObject puzzleMenu;
	public GameObject Scoreboard;
	public GameObject ScoreBoardPanelEnterName; 
	public GameObject endButton;
	public GameObject EndGame;
	public GameObject textNoPoints;
	public GameObject textNoQuestions;
	public Button sunMopOn;
	public GameController gameController;

    public void ShowMainView()
    {
        mainCamera.SetActive(true);
		HelpfulQuestionsButton.SetActive(true);
		leftGUI.SetActive(true);
		Game.SetActive(true);
		HelpsInGame.SetActive (false);
		rockLabels.SetActive(true);
		QuestionPanel.SetActive(false);
		questions.SetActive(false);
		mainCamera.GetComponent<AudioListener>().enabled = true;
		questionsCamera.GetComponent<AudioListener>().enabled = false;
		GTSBtn.SetActive(false);
		Quiz.SetActive (false);
		Scoreboard.SetActive (false);
		EndGame.SetActive (false);
		PuzzleGame.SetActive (false);
    }

    public void ShowPuzzleView()
	{	StateMachine.setState (5);
        leftGUI.SetActive(false);
       // Game.SetActive(false);
        mainCamera.SetActive(false);
        noPointMessage.SetActive(false);
        wrongInputMEssage.SetActive(false);
        puzzleCamera.SetActive(true);
		puzzleMenu.SetActive(true);
		PuzzleGame.SetActive (true);
		Puzzle.SetActive (false);
        QuestionPanel.SetActive(false);
		GTSBtn.SetActive(false);
        questions.SetActive(false);
        questionsCamera.SetActive(false);
		HelpsInGame.SetActive (false);
		Quiz.SetActive (false);
		Scoreboard.SetActive (false);
		EndGame.SetActive (false);
		PuzzlePictures1.SetActive (true);
		PuzzlePictures2.SetActive (false);
    }

    public void ShowQuestionsView()
    {
		StateMachine.setState (6);
		HelpsInGame.SetActive (false);
        leftGUI.SetActive(false);
        GTSBtn.SetActive(false);
        HelpfulQuestionsButton.SetActive(false);
        Game.SetActive(false);
        mainCamera.SetActive(false);
        questionsCamera.SetActive(true);
		PuzzleGame.SetActive (false);
        noPointMessage.SetActive(false);
        wrongInputMEssage.SetActive(false);
        puzzleCamera.SetActive(false);
        QuestionPanel.SetActive(true);
		Quiz.SetActive (true);
        questions.SetActive(false);
        roundGoodOverDisplay.SetActive(false);
        roundBadEndDisplay.SetActive(false);
        mainCamera.GetComponent<AudioListener>().enabled = false;
		Scoreboard.SetActive (false);
        questionsCamera.GetComponent<AudioListener>().enabled = true;
    }

    public void ShowNextQuestionView() {
       
        roundBadEndDisplay.SetActive(false);
		HelpsInGame.SetActive (false);
    }

	public void ShowHelpsInGame() {
		
		StateMachine.setState (9);
		Debug.Log (StateMachine.getState ());
		HelpsInGame.SetActive (true);
		leftGUI.SetActive(false);
		HelpfulQuestionsButton.SetActive(false);
		PuzzleGame.SetActive (false);
		Quiz.SetActive (false);
		GTSBtn.SetActive(false);
		rockLabels.SetActive(false);
		Scoreboard.SetActive (false);
	}

	public void ShowScoreboardView()
	{	StateMachine.setState (7);
		Scoreboard.SetActive (true);
		//Time.timeScale = 0;
		endButton.SetActive (false);
	}

	public void ScoreboardSave()
	{	
		ScoreBoardPanelEnterName.SetActive (false);
	}

	public void SetState0() {
		StateMachine.setState (0);
	}

	public void SetState3() {
		StateMachine.setState (3);
	}

	public void SetState4() {
		StateMachine.setState (4);
	}

	public void ShowEndButton() {
		endButton.SetActive (true);
	}

	public void beforeRoundBadOverNoPoints() {
		textNoPoints.SetActive (false);
	}

	public void beforeRoundBadOverNoQuestions() {
		textNoQuestions.SetActive (false);
	}



}

 
 

    

