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

	}
	public void swapRocks(int index1, int index2, float timeToMove){
		GameObject rock1 = rocks [index1];
		GameObject rock2 = rocks [index2];
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
	}

	IEnumerator waitAndSetDestination(float seconds, GameObject rock, Vector3 destination, float animationTime){
		yield return new WaitForSeconds (seconds);
		rock.GetComponent<setRockPlaces> ().setDestination (destination,animationTime);
	}
}
