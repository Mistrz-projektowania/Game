using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMopController : MonoBehaviour {

	public GameObject SunMop;
	public GameObject [] rocks;

	public ParticleSystem ps;

	private Vector3 startPos;
	private Vector3 destinationPos;
	private Vector3 stayPos;
	private Vector3 skyPos;

	float t;
	float timeToReachDestination;

	float speed;
	float rotateSpeed;
	float movingSpeed;

	float xScale = 0.1f;
	float yScale = 0.1f;
	// Use this for initialization
	void Start () {
		speed = 2;
		rotateSpeed = 100;
		startPos = destinationPos = stayPos = transform.position;
		skyPos = stayPos + new Vector3 (0, 0, 0);
		rocks = GameObject.Find("Rocks").GetComponent<setRockRandomPlaces>().rocks;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime / timeToReachDestination;

		//transform.Rotate (new Vector3(0,Time.deltaTime * rotateSpeed, 0));
		transform.position = Vector3.Lerp (startPos, destinationPos + (Vector3.right * Mathf.Sin (Time.timeSinceLevelLoad / 2 * speed) * xScale - Vector3.up * Mathf.Sin (Time.timeSinceLevelLoad * speed) * yScale), t);
		if (transform.position == destinationPos) {
			transform.position = transform.position + (Vector3.right * Mathf.Sin (Time.timeSinceLevelLoad / 2 * speed) * xScale - Vector3.up * Mathf.Sin (Time.timeSinceLevelLoad * speed) * yScale);	
		}
	}
	public void SunMopON(){
		StateMachine.setState (3);
		SunMop.SetActive (true);
		Debug.Log ("Sun Mop ON");
		CurrentFieldController checkFieldFillOutOrder = GameObject.Find ("GameController").GetComponent<CurrentFieldController> ();
		checkFieldFillOutOrder.checkIfEmpty ();

		int[] dataOrder = GameObject.Find ("GameController").GetComponent<GameController> ().getDataOrder();
		int minIndex = checkFieldFillOutOrder.getNextRockIndex();
		int minIndexPosition = dataOrder[minIndex];

		//Debug.Log ("MIN INDEX: " + minIndex);
		//Debug.Log ("MIN INDEX POSITION: " + minIndexPosition);
		rocks = GameObject.Find("Rocks").GetComponent<setRockRandomPlaces>().rocks;
		Vector3 newPos = rocks [minIndexPosition].transform.position;

		setDestination(new Vector3(newPos.x, newPos.y + 2.5f, newPos.z), 2);
		StartCoroutine (waitFor (2));

		SunMopOff ();
		//Debug.Log (SunMop.transform.position);
	}

	void SunMopOff(){
		StateMachine.setState (0);
	}

	IEnumerator waitFor(int seconds){
		yield return new WaitForSeconds (seconds);
		yield return new WaitForSeconds (3);
		setDestination(stayPos, 2);
		yield return new WaitForSeconds (2);
		setDestination(skyPos, 2);
		yield return new WaitForSeconds (2);
	}

	public void setDestination(Vector3 destination, float time){
		t = 0;
		startPos = transform.position;
		timeToReachDestination = time;
		destinationPos = destination;
	}
}
