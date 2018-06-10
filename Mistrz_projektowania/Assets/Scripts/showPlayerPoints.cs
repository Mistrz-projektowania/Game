using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showPlayerPoints : MonoBehaviour {

	public Text playerPoints;
	private int points;
	// Use this for initialization
	void Start () {
		points = 0;
	}
	
	// Update is called once per frame
	void Update () {
		UpdatePlayerPoints ();
	}

	public void UpdatePlayerPoints(){
		playerPoints.text = "Punkty: " + points;
	}
}
