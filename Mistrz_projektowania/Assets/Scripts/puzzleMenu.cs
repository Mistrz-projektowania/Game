using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class puzzleMenu : MonoBehaviour {

	public GameObject leftArrow;
	public GameObject rightArrow;
	private GameObject PuzzleMenu;
	public GameObject puzzleCamera;
	public GameObject EntryPanel;
	public GameObject PuzzlesPictures;
	public GameObject PuzzlesPictures2;
	public GameObject Puzzle;
	public GameObject EndGame;
	public GameObject GUI;
	public GameObject Flashcard;
	public GameObject CompletedMenu;
	public GameObject PanelPlay;
	public GameController gameController;
	public Button giveUpButton;


	void Start() {
		Puzzle.SetActive (false);
		EndGame.SetActive (false);
		PuzzlesPictures.SetActive(true);
		leftArrow = GameObject.Find ("LeftArrow");
		rightArrow = GameObject.Find ("RightArrow");
	}

	public void PlayPuzzle() { 
		EntryPanel.SetActive(false);
		Puzzle.SetActive (false);
		puzzleCamera.SetActive(true);
		PuzzleMenu.SetActive(true);
		PuzzlesPictures.SetActive(true);
		EndGame.SetActive (false);
	}

	public void GoLeftMenu() { 
		PuzzlesPictures2.SetActive(false);
		PuzzlesPictures.SetActive(true);
	}

	public void GoRightMenu() {  
		PuzzlesPictures.SetActive(false);
		PuzzlesPictures2.SetActive(true);
	}

	public void GiveUp() {  
		gameController.subtractPoints(3);
		GameManager.puzzle_state.state = PuzzleState.State.loose;
		PuzzlesPictures.SetActive(true);
		PuzzlesPictures2.SetActive(false);
		EndGame.SetActive (true);
		Puzzle.SetActive (false);
		PuzzlesPictures.SetActive(true);
	}

	public void GiveUpUltimately() {  
		PuzzleMenu.SetActive(true);
		EndGame.SetActive (false);
	}

	public void OtherPicture() {  
		PuzzlesPictures.SetActive(false);
		PuzzlesPictures2.SetActive(true);
		EndGame.SetActive (false);
		Puzzle.SetActive (false);
		GUI.SetActive(true);
	}

	public void GoToCompletePanel() {  
		CompletedMenu.SetActive (true);
		Puzzle.SetActive (false);
		Flashcard.SetActive (false);
		PuzzlesPictures.SetActive(false);
	}
		
	void Update() {
		if (PanelPlay.activeSelf == true) {
			giveUpButton.interactable = false;
		} else giveUpButton.interactable = true;
	}
}
