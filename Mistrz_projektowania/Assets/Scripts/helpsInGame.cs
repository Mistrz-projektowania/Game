using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helpsInGame : MonoBehaviour {

	public Button sunMopOn;
	public GameController gameController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
		if (gameController.getPoints () < 2) {
			sunMopOn.interactable = false;
		}
		else sunMopOn.interactable = true;
	} 
}
