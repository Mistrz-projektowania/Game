using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockSort : MonoBehaviour {

	// Use this for initialization
	setRockRandomPlaces rockController;
	GameController gameController;
	GTSRotation gtsController;
	public ParticleSystem ps;

	private int[] dataOrder;
	private int[] rockOrder;
	private Image systemInfo;


	// Use this for initialization
	void Start () {
		ps.Stop ();
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		systemInfo = gameController.systemInfo;
		rockController = GameObject.Find("Rocks").GetComponent<setRockRandomPlaces>();
		gtsController = GameObject.Find ("Frisbee").GetComponent<GTSRotation> ();
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
		gtsController.setDestination (new Vector3(54.0f, 2.5f, 8.0f), 2.0f);
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
	}

	IEnumerator selectionSort(float seconds){
		yield return new WaitForSeconds (1);
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
			if (minIndex != i) {
				rockController.swapRocks (minIndex, i, seconds);
			}

			yield return new WaitForSeconds (seconds);
		}
		gtsController.setDestination (new Vector3(54.0f, 2.8f, 16.0f), 2.0f);
		StartCoroutine (gameController.fadeMessage (systemInfo, false, 0.5f));
		StateMachine.setState (0);
		ps.Stop ();
	}
}
