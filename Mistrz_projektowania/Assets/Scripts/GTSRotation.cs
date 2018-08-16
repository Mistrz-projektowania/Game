using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTSRotation : MonoBehaviour {
	private Vector3 startPos;
	private Vector3 destinationPos;
	public Vector3 transformVector;
	bool moving = false;
	float speed;
	float rotateSpeed;
	float movingSpeed;
	float xScale = 0.1f;
	float yScale = 0.1f;

	float t;
	float timeToReachDestination;


	// Use this for initialization
	void Start () {
		movingSpeed = 0.02f;
		speed = 2;
		rotateSpeed = 100;
		startPos = destinationPos = transform.position;
	}
	public void setNewStartPos(Vector3 pos){
		startPos = pos;
	}
	public void setDestinationPosition(Vector3 pos){
		destinationPos = pos;
	}

	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime / timeToReachDestination;

		transform.Rotate (new Vector3(0,Time.deltaTime * rotateSpeed, 0));
		transform.position = Vector3.Lerp (startPos, destinationPos + (Vector3.right * Mathf.Sin (Time.timeSinceLevelLoad / 2 * speed) * xScale - Vector3.up * Mathf.Sin (Time.timeSinceLevelLoad * speed) * yScale), t);
		if (transform.position == destinationPos) {
			transform.position = transform.position + (Vector3.right * Mathf.Sin (Time.timeSinceLevelLoad / 2 * speed) * xScale - Vector3.up * Mathf.Sin (Time.timeSinceLevelLoad * speed) * yScale);	
		}
	}

	public void setDestination(Vector3 destination, float time){
		t = 0;
		startPos = transform.position;
		timeToReachDestination = time;
		destinationPos = destination;
	}
}
