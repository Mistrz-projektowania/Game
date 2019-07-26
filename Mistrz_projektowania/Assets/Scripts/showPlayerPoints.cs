using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showPlayerPoints : MonoBehaviour {

	public Text playerPoints;
	public GameController gameController;
	public int points;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if(gameControllerObject != null){
			gameController = gameControllerObject.GetComponent<GameController>();	
		}

	}
	
	// Update is called once per frame
	void Update () {
		points = gameController.getPoints ();
		UpdatePlayerPoints ();
	}

	public void UpdatePlayerPoints(){
		playerPoints.text = points.ToString();
	}

	public int getPlayerPoints(){
		return points;
	}
}
