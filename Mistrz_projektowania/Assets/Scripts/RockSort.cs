﻿using System.Collections;
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
		dataOrder = gameController.getDataOrder ();
		rockOrder = new int[dataOrder.Length];

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
		Debug.Log (rockOrderString);
	}

	IEnumerator selectionSort(float seconds){
		Debug.Log ("Sortujemy");
		int n = rockOrder.Length;

		// One by one move boundary of unsorted subarray
		for (int i = 0; i < n - 1; i++)
		{
			// Find the minimum element in unsorted array
			int min_idx = i;
			for (int j = i + 1; j < n; j++)
				if (rockOrder[j] < rockOrder[min_idx])
					min_idx = j;

			// Swap the found minimum element with the first
			// element
			int temp = rockOrder[min_idx];
			rockOrder[min_idx] = rockOrder[i];
			rockOrder[i] = temp;
			rockController.swapRocks (rockOrder[min_idx], rockOrder[i], seconds);


			yield return new WaitForSeconds (seconds);
		}

	}
}
