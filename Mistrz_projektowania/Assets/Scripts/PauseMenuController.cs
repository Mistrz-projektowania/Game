using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {
	
	public GameObject pauseMenu;
	public Button pauseMenuButton;
	public Button backToGameButton;
	public Button backToMenuButton;
	public Button quitGameButton;
	// Use this for initialization
	void Start () {
		pauseMenu.SetActive (false);
		pauseMenuButton.onClick.AddListener(handlePauseMenu);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			handlePauseMenu ();
		}

	}

	void backToGame(){
		pauseMenu.SetActive (false);
	}
	void backToMenu(){
		SceneManager.LoadScene(1);
	}
	void quitGame(){
		Application.Quit ();
	}

	void handlePauseMenu(){
		if (pauseMenu.activeSelf == true) {
			pauseMenu.SetActive (false);

		} else {
			pauseMenu.SetActive (true);
			backToGameButton.onClick.AddListener (backToGame);
			backToMenuButton.onClick.AddListener (backToMenu);
			quitGameButton.onClick.AddListener (quitGame);
		}
	}

}
