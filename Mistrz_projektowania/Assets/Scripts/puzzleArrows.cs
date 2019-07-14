using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleArrows : MonoBehaviour {

	public GameObject PuzzleMenu; 
	public GameObject PuzzlesPictures;
	public GameObject PuzzlesPictures2;

	 

	public void GoLeftMenu() { 
			PuzzlesPictures2.SetActive(false);
			PuzzlesPictures.SetActive(true);
		 
	}

	public void GoRightMenu() {  
			PuzzlesPictures.SetActive(false);
			PuzzlesPictures2.SetActive(true);
	 
	}
}
