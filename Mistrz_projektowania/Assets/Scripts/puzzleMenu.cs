using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
	public GameController gameController;




	void Start() {
		Puzzle.SetActive (false);
		EndGame.SetActive (false);
		leftArrow = GameObject.Find ("LeftArrow");
		rightArrow = GameObject.Find ("RightArrow");

		 if (PuzzlesPictures.activeSelf == false) {
			rightArrow.SetActive (false);
			leftArrow.SetActive (true);
		}

		if (PuzzlesPictures2.activeSelf == false) {
			leftArrow.SetActive (false);
			rightArrow.SetActive (true);
		}  
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
		PuzzlesPictures.SetActive(false);
		PuzzlesPictures2.SetActive(true);
		EndGame.SetActive (true);
		PuzzleMenu.SetActive(false);
		Puzzle.SetActive (false);
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
	}


	void Update() {
	}
}
