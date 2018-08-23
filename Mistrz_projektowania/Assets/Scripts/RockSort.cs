using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSort : MonoBehaviour {

	// Use this for initialization
	setRockRandomPlaces rockController;
	GameController gameController;

	private int[] dataOrder;
	private int[] rockOrder;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		rockController = GameObject.Find("Rocks").GetComponent<setRockRandomPlaces>();
		dataOrder = rockOrder = gameController.getDataOrder ();
		findRockOrder ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void findRockOrder(){
		for (int i = 0; i < dataOrder.Length; i++) {
			for (int j = 0; j < dataOrder.Length; j++) {
				if (dataOrder [i] == j) {
					rockOrder [j] = i;
				}
			}
		}
		for (int i = 0; i < rockOrder.Length; i++) {
			Debug.Log (">>>>>>>>>>>>>>>>>>>>>");
			Debug.Log(rockOrder[i]);
		}
	}

	public void selectionSort(){
		Debug.Log ("Sortujemy");
	}
}
