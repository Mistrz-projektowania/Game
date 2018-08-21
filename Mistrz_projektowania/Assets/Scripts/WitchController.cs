using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchController : MonoBehaviour {

	private Vector3 startPos;
	private Vector3 destinationPos;
	private Quaternion rotation;
	private Quaternion nextRotation;

	float speed = 2;
	float rotateSpeed = 0.02f;
	float xScale = 0.1f;
	float yScale = 0.1f;

	float animationTime;
	bool keyWPressed;
	float lastKeyWPressedTime;
	int swapNr;

	float t;
	float timeToReachDestination;

	setRockRandomPlaces rockController;
	GameController gameController;
	ParticleSystem ps;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		rockController = GameObject.Find("Rocks").GetComponent<setRockRandomPlaces>();
		swapNr = 3;
		animationTime = 2.0f;
		lastKeyWPressedTime = Time.time - animationTime * swapNr;
		startPos = destinationPos = transform.position;
		rotation = nextRotation = transform.rotation;
		ps = GameObject.Find ("WitchSpell").GetComponent<ParticleSystem> ();
		ps.Stop ();
	}

	// Update is called once per frame
	void Update () {
		fly ();
		if (Input.GetKeyDown (KeyCode.W) && (Time.time - lastKeyWPressedTime > animationTime * swapNr)) {
			int flyingTime = 2;
			setDestination(startPos - new Vector3(0.0f, 0.0f, 4.0f), 180.0f, flyingTime);
			StartCoroutine (waitForAndStartSwapingRocks (flyingTime));
	

			lastKeyWPressedTime = Time.time;
		}
	}

	void swapRocksFewTimes(int times){
		for (int i = 0; i < times; i++) {
			int[] randomIndexes = GameController.drawTheOrder (7, 2);

			StartCoroutine (waitAndSwap (i*animationTime, randomIndexes[0],randomIndexes[1],animationTime));	
		}
	}
	IEnumerator waitForAndStartSwapingRocks(float seconds){
		yield return new WaitForSeconds (seconds);
		ps.Play ();
		yield return new WaitForSeconds (1);
		swapRocksFewTimes (swapNr);
		yield return new WaitForSeconds (animationTime * swapNr);
		ps.Stop ();
	}
	IEnumerator waitAndSwap(float seconds, int index1, int index2, float animationTime){
		yield return new WaitForSeconds (seconds);
		rockController.swapRocks (index1,index2,animationTime);
	}

	void fly(){
		t += Time.deltaTime / timeToReachDestination;
		transform.rotation = Quaternion.Lerp(rotation, nextRotation, t * rotateSpeed);

		transform.position = Vector3.Lerp (startPos, destinationPos + (Vector3.right * Mathf.Sin (Time.timeSinceLevelLoad / 2 * speed) * xScale - Vector3.up * Mathf.Sin (Time.timeSinceLevelLoad * speed) * yScale), t);
		if (transform.position == destinationPos) {
			//transform.Rotate (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad/2*speed)*xScale - Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * speed)*yScale);
			transform.position = startPos + (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad/2*speed)*xScale - Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * speed)*yScale);
		}

	}

	public void setDestination(Vector3 destination, float rot, float time){
		t = 0;
		startPos = transform.position;
		timeToReachDestination = time;
		destinationPos = destination;
		rotation = transform.rotation;
		nextRotation = new Quaternion(0,rot,0,0);
	}
}
