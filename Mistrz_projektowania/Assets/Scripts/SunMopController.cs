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
		ps.Stop ();
		speed = 2;
		rotateSpeed = 2;
		startPos = destinationPos = stayPos = transform.position;
		skyPos = stayPos + new Vector3 (0, 0, 0);
		rocks = GameObject.Find("Rocks").GetComponent<setRockRandomPlaces>().rocks;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime / timeToReachDestination;

		transform.Rotate (new Vector3(0, 0, Mathf.Sin (Time.timeSinceLevelLoad / 2 * rotateSpeed)/10));
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
		int minIndex = checkFieldFillOutOrder.getNextRockIndexForSunMop();
		int minIndexPosition = dataOrder[minIndex];

		rocks = GameObject.Find("Rocks").GetComponent<setRockRandomPlaces>().rocks;
		Vector3 newPos = rocks [minIndexPosition].transform.position;

		setDestination(new Vector3(newPos.x - 0.1f, newPos.y + 2.2f, newPos.z + 0.2f), 2);
		StopCoroutine ("showRocksOrder");
		StartCoroutine (showRocksOrder (2, minIndex, dataOrder));
	}

	void SunMopOff(){
		Debug.Log ("SUN MOP state 0");
		StateMachine.setState (0);
	}

	IEnumerator showRocksOrder(int seconds, int minIndex, int[] dataOrder){
		Time.timeScale = 1;
		yield return new WaitForSeconds (seconds);
		ps.Play ();
		while (minIndex < 6) {
			minIndex += 1;
			int minIndexPosition = dataOrder [minIndex];

			yield return new WaitForSeconds (3);
			ps.Stop ();
			Vector3 newPos = rocks [minIndexPosition].transform.position;
			setDestination (new Vector3 (newPos.x - 0.1f, newPos.y + 2.2f, newPos.z + 0.2f), 2);
			yield return new WaitForSeconds (3);
			ps.Play ();
		}
		yield return new WaitForSeconds (3);
		ps.Stop ();
		setDestination(stayPos, 2);
		yield return new WaitForSeconds (2);
		setDestination(skyPos, 2);
		yield return new WaitForSeconds (2);
		Debug.Log ("SUN MOP END");
		SunMopOff ();
	}

	public void setDestination(Vector3 destination, float time){
		t = 0;
		startPos = transform.position;
		timeToReachDestination = time;
		destinationPos = destination;
	}
}
