using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setRockPlaces : MonoBehaviour {
	public GameObject rock;
	public int index;
	private int LeftGUIwidth;
	// Use this for initialization
	void Start () {
		LeftGUIwidth = 500;
		//Vector3 pos1 = Camera.main.ScreenToWorldPoint (new Vector3((Screen.width-500)/7 , 0, 3));
		//rock1.transform.position = new Vector3(pos1.x, rock1.transform.position.y, rock1.transform.position.z);
		/*
		findCoordinates(rock1, 500, 0);
		findCoordinates(rock2, 500, 1);
		findCoordinates(rock3, 500, 2);
		findCoordinates(rock4, 500, 3);
		findCoordinates(rock5, 500, 4);
		findCoordinates(rock6, 500, 5);
		findCoordinates(rock7, 500, 6);
		*/

		findCoordinates (rock, LeftGUIwidth, index);
		Debug.Log (Screen.width);
		Debug.Log (Screen.width-500);
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	void findCoordinates(GameObject rock, int leftGUIWidth, int i){
		Vector3 pos1 = Camera.main.ScreenToWorldPoint (new Vector3((Screen.width-leftGUIWidth)/7 * i + leftGUIWidth, Screen.height/2 - 20 * Mathf.Cos(i) + 30, 8 - Mathf.Cos(i)/2));
		Debug.Log (new Vector3((Screen.width-leftGUIWidth)/7 * i + leftGUIWidth, Screen.height/2 + Mathf.Sin(i), 7));
		Debug.Log (pos1);
		rock.transform.position = new Vector3(pos1.x, pos1.y, pos1.z);
		
	}
}
