using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setRockRandomPlaces : MonoBehaviour {
	public GameObject[] rocks;
	public Vector3[] rockPlaces;

	float t;
	float timeToReachDestination;
	// Use this for initialization
	void Start () {
		rockPlaces = new Vector3[rocks.Length];
		Debug.Log (rockPlaces.Length);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			for (int i = 0; i < rockPlaces.Length; i++) {
				Debug.Log ("Pozycja " + i + ": " + rockPlaces [i]);

			}
			swapRocks (rocks [0], rocks [1]);
		}
	}
	void swapRocks(GameObject rock1, GameObject rock2){
		Vector3 startPos1 = rock1.transform.position;
		Vector3 startPos2 = rock2.transform.position;
		Debug.Log (startPos1);
		Debug.Log (startPos2);
		rock1.GetComponent<setRockPlaces> ().setDestination (new Vector3(startPos1.x,startPos1.y,startPos1.z - 1.0f),2);
		//rock1.transform.position = startPos2;
		//rock2.transform.position = startPos1;
	}
}
