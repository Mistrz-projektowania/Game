using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSort : MonoBehaviour {

	// Use this for initialization
	setRockRandomPlaces rockController;
	GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		rockController = GameObject.Find("Rocks").GetComponent<setRockRandomPlaces>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void selectionSort(){
		Debug.Log ("Sortujemy");
	}
}
