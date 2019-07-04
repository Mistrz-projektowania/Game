using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleArrows : MonoBehaviour {

	private void OnMouseDown () {
		if (gameObject.name == "LeftArrow") {
			SceneManager.LoadScene ("PuzzleMenu");
		}

		if (gameObject.name == "RightArrow") {
			SceneManager.LoadScene ("PuzzleMenuSecond");
		}

	}
}
