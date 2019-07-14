using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleMenu : MonoBehaviour {

	public GameObject leftArrow;
	public GameObject rightArrow;
	private GameObject PuzzleMenu;
	public GameObject EntryPanel;
	public GameObject PuzzlesPictures;
	public GameObject PuzzlesPictures2;


	void Start() {
		 
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
		PuzzleMenu.SetActive(true);
		PuzzlesPictures.SetActive(true);
	}

	public void GoLeftMenu() { 
		PuzzlesPictures2.SetActive(false);
		PuzzlesPictures.SetActive(true);
	}

	public void GoRightMenu() {  
		PuzzlesPictures.SetActive(false);
		PuzzlesPictures2.SetActive(true);
	}

	void Update() {
	}
}
