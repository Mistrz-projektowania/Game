using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleMenu : MonoBehaviour {

	private GameObject leftArrow;
	private GameObject rightArrow;
	private GameObject PuzzleMenu;
	private GameObject PuzzleMenu2;


	void Start() {
		leftArrow = GameObject.Find("LeftArrow");
		rightArrow = GameObject.Find("RightArrow");

	 
	}

	void Update() {
	}
}
