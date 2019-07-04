using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleMenu : MonoBehaviour {

	private GameObject leftArrow;
	private GameObject rightArrow;

	void Start() {
		leftArrow = GameObject.Find("LeftArrow");
		rightArrow = GameObject.Find("RightArrow");

		if (SceneManager.GetActiveScene ().name == "PuzzleMenu") {
			leftArrow.SetActive (false);
		}

		if (SceneManager.GetActiveScene ().name == "PuzzleMenuSecond") {
			rightArrow.SetActive (false);
		}
	}

	void Update() {
	}
}
