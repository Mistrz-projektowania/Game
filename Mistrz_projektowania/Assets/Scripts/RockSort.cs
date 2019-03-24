using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockSort : MonoBehaviour {

	// Use this for initialization
	setRockRandomPlaces rockController;
	GameController gameController;

	private int[] dataOrder;
	private int[] rockOrder;
	private Image systemInfo;


	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		systemInfo = gameController.systemInfo;
		rockController = GameObject.Find("Rocks").GetComponent<setRockRandomPlaces>();
		dataOrder = gameController.getDataOrder ();
		rockOrder = new int[dataOrder.Length];
	}
	
	// Update is called once per frame
	void Update () {
		//findRockOrder ();
	}
	public void sort(){
		systemInfo.GetComponentInChildren<Text>().text = "GTS włączony";
		StartCoroutine (gameController.fadeMessage (systemInfo, true, 0.5f));

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
		StartCoroutine (gameController.fadeMessage (systemInfo, false, 0.5f));
		StateMachine.setState (0);
		/*
		string arr = "";
		for (int i = 0; i < n - 1; i++) {
			arr += rockOrder [i];
		}
		Debug.Log (arr);
		*/
	}
}
