using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setRockRandomPlaces : MonoBehaviour {
	public GameObject[] rocks;
	public Vector3[] rockPlaces;

	float animationTime;
	float lastKeyWPressedTime;
	// Use this for initialization
	void Start () {
		lastKeyWPressedTime = Time.time;
		animationTime = 3.0f;
		rockPlaces = new Vector3[rocks.Length];
		Debug.Log (rockPlaces.Length);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W) && (Time.time - lastKeyWPressedTime > animationTime)) {
			for (int i = 0; i < rockPlaces.Length; i++) {
				Debug.Log ("Pozycja " + i + ": " + rockPlaces [i]);

			}
			swapRocks (rocks [0], rocks [5], animationTime);
			lastKeyWPressedTime = Time.time;
		}
	}
	void swapRocks(GameObject rock1, GameObject rock2, float timeToMove){
		Vector3 startPos1 = rock1.transform.position;
		Vector3 startPos2 = rock2.transform.position;
		Debug.Log (startPos1);
		Debug.Log (startPos2);
		float firstMoveTime, lastMoveTime, changePlaceTime;
		firstMoveTime = lastMoveTime = 0.5f;
		changePlaceTime = timeToMove - firstMoveTime - lastMoveTime;
		rock1.GetComponent<setRockPlaces> ().setDestination (new Vector3(startPos1.x,startPos1.y,startPos1.z - 1.0f),firstMoveTime);
		rock2.GetComponent<setRockPlaces> ().setDestination (new Vector3(startPos2.x,startPos2.y,startPos2.z - 2.0f),firstMoveTime);
		StartCoroutine (waitAndSetDestination (firstMoveTime, rock2, new Vector3(startPos1.x,startPos2.y,startPos2.z - 2.0f),changePlaceTime));
		StartCoroutine (waitAndSetDestination (firstMoveTime, rock1, new Vector3(startPos2.x,startPos1.y,startPos1.z - 1.0f),changePlaceTime));
		StartCoroutine (waitAndSetDestination (changePlaceTime + firstMoveTime, rock2, new Vector3(startPos1.x,startPos1.y,startPos1.z),lastMoveTime));
		StartCoroutine (waitAndSetDestination (changePlaceTime + firstMoveTime, rock1, new Vector3(startPos2.x,startPos2.y,startPos2.z),lastMoveTime));
		/*
		 * rock2.GetComponent<setRockPlaces> ().setDestination (new Vector3(startPos1.x,startPos2.y,startPos1.z),1);
		rock1.GetComponent<setRockPlaces> ().setDestination (new Vector3(startPos2.x,startPos2.y,startPos1.z),1);
		StartCoroutine (waitFor (1));
		rock2.GetComponent<setRockPlaces> ().setDestination (new Vector3(startPos1.x,startPos1.y,startPos1.z),1);
		rock1.GetComponent<setRockPlaces> ().setDestination (new Vector3(startPos2.x,startPos2.y,startPos2.z),1);
		*/
		//rock1.transform.position = startPos2;
		//rock2.transform.position = startPos1;
	}

	IEnumerator waitAndSetDestination(float seconds, GameObject rock, Vector3 destination, float animationTime){
		yield return new WaitForSeconds (seconds);
		rock.GetComponent<setRockPlaces> ().setDestination (destination,animationTime);
	}
}
