using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSort : MonoBehaviour {

	// Use this for initialization
	setRockRandomPlaces rockController;
	GameController gameController;

	private int[] dataOrder;
	private int[] rockOrder;

	private StateMachine stateMachine;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		rockController = GameObject.Find("Rocks").GetComponent<setRockRandomPlaces>();
		dataOrder = gameController.getDataOrder ();
		rockOrder = new int[dataOrder.Length];
		stateMachine = GameObject.Find ("StateMachine").GetComponent<StateMachine> ();
	}
	
	// Update is called once per frame
	void Update () {
		//findRockOrder ();
	}
	public void sort(){
		dataOrder = gameController.getDataOrder ();
		findRockOrder ();
		StartCoroutine(selectionSort (2));
	}
	void findRockOrder(){
		for (int i = 0; i < dataOrder.Length; i++) {
			for (int j = 0; j < rockOrder.Length; j++) {
				if (dataOrder [i] == j) {
					rockOrder [j] = i;
				}
			}
		}
		string rockOrderString = "ROCK ORDER: ";
		for (int i = 0; i < rockOrder.Length; i++) {
			rockOrderString += rockOrder [i];
			rockOrderString += ", ";
		}
		//Debug.Log (rockOrderString);
	}

	IEnumerator selectionSort(float seconds){
		Debug.Log ("Sortujemy");
		int n = rockOrder.Length;

		for (int i = 0; i < n - 1; i++)
		{
			// Znajdź minimum w nieposortowanej tablicy
			int minIndex = i;
			for (int j = i + 1; j < n; j++)
				if (rockOrder[j] < rockOrder[minIndex])
                    minIndex = j;

			// Zamień minimum z pierwszym elementem
			int temp = rockOrder[minIndex];
			rockOrder[minIndex] = rockOrder[i];
			rockOrder[i] = temp;
			//Debug.Log ("SWAP rocks: " + minIndex + ", " + i);
			if (minIndex != i) {
				rockController.swapRocks (minIndex, i, seconds);
			}

			yield return new WaitForSeconds (seconds);
		}
		stateMachine.setState (0);
		/*
		string arr = "";
		for (int i = 0; i < n - 1; i++) {
			arr += rockOrder [i];
		}
		Debug.Log (arr);
		*/
	}
}
