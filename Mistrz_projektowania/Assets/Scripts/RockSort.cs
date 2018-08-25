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
	public void sort(){
		dataOrder = rockOrder = gameController.getDataOrder ();
		findRockOrder ();
		StartCoroutine(selectionSort (2));
	}
	void findRockOrder(){
		for (int i = 0; i < dataOrder.Length; i++) {
			for (int j = 0; j < dataOrder.Length; j++) {
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
		int k;
		for( int i = 0; i < rockOrder.Length; i++ )
		{
			k = i;
			for( int j = i + 1; j < rockOrder.Length; j++ )
				if( rockOrder[ j ] < rockOrder[ k ] )
					k = j;

			//rockController.swapRocks (rockOrder[k], rockOrder[i], seconds);
			yield return new WaitForSeconds (seconds);
		}
	}
}
