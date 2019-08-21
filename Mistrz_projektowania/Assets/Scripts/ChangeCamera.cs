using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject questionsCamera;
    public GameObject GTSBtn;
    public GameObject HelpfulQuestionsButton;
    public GameObject RoundGoodOverPanel;
	public GameObject PuzzleGame;
    public GameObject questionDisplay;
    public GameObject roundBadEndDisplay;
    public GameObject AnswerPanel;
    public GameObject roundGoodOverDisplay;
	public GameObject HelpsInGame;
	public GameObject puzzleMenu;

    public void ShowMainView()
    {
        mainCamera.SetActive(true);
        leftGUI.SetActive(true);
        Game.SetActive(true);
        rockLabels.SetActive(true);
        QuestionPanel.SetActive(false);
        questions.SetActive(false);
        questionsCamera.SetActive(false);
        mainCamera.GetComponent<AudioListener>().enabled = true;
        questionsCamera.GetComponent<AudioListener>().enabled = false;
        GTSBtn.SetActive(true);
        HelpfulQuestionsButton.SetActive(true);
		HelpsInGame.SetActive (false);
		PuzzleGame.SetActive (false);
		Quiz.SetActive (false);


    }

    public void ShowPuzzleView()
    {
        leftGUI.SetActive(false);
        Game.SetActive(false);
        mainCamera.SetActive(false);
        noPointMessage.SetActive(false);
        wrongInputMEssage.SetActive(false);
        puzzleCamera.SetActive(true);
		puzzleMenu.SetActive(true);
		PuzzleGame.SetActive (true);
        QuestionPanel.SetActive(false);
		GTSBtn.SetActive(false);
        questions.SetActive(false);
        questionsCamera.SetActive(false);
		HelpsInGame.SetActive (false);
		Quiz.SetActive (false);

    }

    public void ShowQuestionsView()
    {
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
        questionsCamera.GetComponent<AudioListener>().enabled = true;

    }

    public void ShowNextQuestionView() {
       
        roundBadEndDisplay.SetActive(false);
		HelpsInGame.SetActive (false);
    }

	public void ShowHelpsInGame() {

		HelpsInGame.SetActive (true);
		leftGUI.SetActive(false);
		HelpfulQuestionsButton.SetActive(false);
		PuzzleGame.SetActive (false);
		Quiz.SetActive (false);
		GTSBtn.SetActive(false);
		rockLabels.SetActive(false);
	}
}

 
 

    

