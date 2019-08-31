using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

	public Button backToMenuButton;

	// Use this for initialization
	void Start () {
		backToMenuButton = GetComponent<Button> ();
		backToMenuButton.onClick.AddListener (backToMenu);
	}

	void backToMenu(){
		SceneManager.LoadScene(0);
	}
}
