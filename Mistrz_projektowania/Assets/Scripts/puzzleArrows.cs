using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleArrows : MonoBehaviour {

	public GameObject PuzzleMenu;
	public GameObject PuzzleMenu2;

	private void OnMouseDown () {
		if (gameObject.name == "LeftArrow") {
			PuzzleMenu2.SetActive(false);
			PuzzleMenu.SetActive(true);
		}

		if (gameObject.name == "RightArrow") {
			PuzzleMenu.SetActive(false);
			PuzzleMenu2.SetActive(true);
		}

	}
}
