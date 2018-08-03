using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setRockPlaces : MonoBehaviour {
	public GameObject rock1;
	public GameObject rock2;
	public GameObject rock3;
	public GameObject rock4;
	public GameObject rock5;
	public GameObject rock6;
	public GameObject rock7;
	// Use this for initialization
	void Start () {
		//Vector3 pos1 = Camera.main.ScreenToWorldPoint (new Vector3((Screen.width-500)/7 , 0, 3));
		//rock1.transform.position = new Vector3(pos1.x, rock1.transform.position.y, rock1.transform.position.z);
		findCoordinates(rock1, 500, 0);
		findCoordinates(rock2, 500, 1);
		findCoordinates(rock3, 500, 2);
		findCoordinates(rock4, 500, 3);
		findCoordinates(rock5, 500, 4);
		findCoordinates(rock6, 500, 5);
		findCoordinates(rock7, 500, 6);

		Debug.Log (Screen.width);
		Debug.Log (Screen.width-500);
	}
	
	// Update is called once per frame
	void Update () {
	}
	void findCoordinates(GameObject rock, int leftGUIWidth, int i){
		Vector3 pos1 = Camera.main.ScreenToWorldPoint (new Vector3((Screen.width-leftGUIWidth)/7 * i + leftGUIWidth, Screen.height/2 + Mathf.Sin(i)  * 20, 7));
		Debug.Log (new Vector3((Screen.width-leftGUIWidth)/7 * i + leftGUIWidth, Screen.height/2 + Mathf.Sin(i)  * 20, 7));
		Debug.Log (pos1);
		rock.transform.position = new Vector3(pos1.x - 1, pos1.y, pos1.z);
		
	}
}
