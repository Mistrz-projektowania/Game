using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setRockPlaces : MonoBehaviour {
	public GameObject rock;
	public int index;
	private float LeftGUIwidth;
	private int screenWidth;
	private GameObject leftGUI; 
	private float localScale;

	private float rockToTerrainPosY = -0.2f;
	float t;
	float timeToReachDestination;
	private Vector3 startPos;
	private Vector3 destinationPos;

	// Use this for initialization
	void Start () {
		GameObject GUI = GameObject.Find ("GUI");
		localScale = GUI.GetComponent<RectTransform> ().localScale.x;
		leftGUI = GameObject.Find("leftGUI");
		LeftGUIwidth = 550 * localScale;
		screenWidth = Screen.width;

		startPos = destinationPos = transform.position;

		findCoordinates (rock, LeftGUIwidth, index);
		randomRotation (rock);


	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime / timeToReachDestination;
		transform.position = Vector3.Lerp (startPos, destinationPos, t);
	}

	public void setDestination(Vector3 destination, float time){
		t = 0;
		startPos = transform.position;
		timeToReachDestination = time;
		destinationPos = destination;
	}
		
	void findCoordinates(GameObject rock, float leftGUIWidth, int i){
		//Vector3 newPosition = new Vector3 ((Screen.width - LeftGUIwidth) / 7 * i + LeftGUIwidth, Screen.height *2/ 3 - 20 * Mathf.Cos (i) + 30, 8 - 2 * Mathf.Cos (i));
		Vector3 newPosition = new Vector3 ((Screen.width - LeftGUIwidth) / 7 * i + LeftGUIwidth - 20, Screen.height /2, 8);
		Vector3 pos1 = Camera.main.ScreenToWorldPoint (newPosition);

		BoxCollider rockCollider = rock.GetComponent<BoxCollider>();
		float rockWidth = rockCollider.size.x * rockCollider.transform.localScale.x;
		rock.transform.position = new Vector3(pos1.x + rockWidth/2 + 0.1f, rockToTerrainPosY, pos1.z);
		destinationPos = rock.transform.position;
		GameObject.Find ("Witch").GetComponent<setRockRandomPlaces> ().rockPlaces [i] = rock.transform.position;
		/*
		 * float newPosZ = 5;
		if (i < 4) {
			newPosZ = i * 3 + 5;
		} else {
			newPosZ = i * 2 - 5;
		}
		rock.transform.position = new Vector3(pos1.x + rockWidth/2 + 0.1f, rockToTerrainPosY, newPosZ);
		*/
	}
	void randomRotation(GameObject rock){
		Quaternion rRot = Random.rotation;
		rock.transform.rotation = new Quaternion (0, rRot.y, 0, 1);
	}
}
