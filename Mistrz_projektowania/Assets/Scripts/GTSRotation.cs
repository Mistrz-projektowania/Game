using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTSRotation : MonoBehaviour {
	private Vector3 startPos;
	public Vector3 transformVector;
	float speed;
	float rotateSpeed;
	float xScale = 0.1f;
	float yScale = 0.1f;

	// Use this for initialization
	void Start () {
		speed = 2;
		rotateSpeed = 100;
		startPos = transform.position;
	}
	public void setNewStartPos(Vector3 pos){
		startPos = pos;
	}

	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0,Time.deltaTime * rotateSpeed, 0));
		transform.position = startPos + (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad/2*speed)*xScale - Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * speed)*yScale);
	}
}
