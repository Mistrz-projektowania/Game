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
	// Use this for initialization
	void Start () {
		GameObject GUI = GameObject.Find ("GUI");
		localScale = GUI.GetComponent<RectTransform> ().localScale.x;
		leftGUI = GameObject.Find("leftGUI");
		LeftGUIwidth = 500 * localScale;
		screenWidth = Screen.width;

		findCoordinates (rock, LeftGUIwidth, index);
		randomRotation (rock);
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	void findCoordinates(GameObject rock, float leftGUIWidth, int i){
		Vector3 newPosition = new Vector3 ((Screen.width - LeftGUIwidth) / 7 * i + LeftGUIwidth, Screen.height / 2 - 20 * Mathf.Cos (i) + 30, 8 - 2 * Mathf.Cos (i));
		Vector3 pos1 = Camera.main.ScreenToWorldPoint (newPosition);

		BoxCollider rockCollider = rock.GetComponent<BoxCollider>();
		float rockWidth = rockCollider.size.x * rockCollider.transform.localScale.x;
		rock.transform.position = new Vector3(pos1.x + rockWidth/2 + 0.1f, rockToTerrainPosY, pos1.z);
		
	}
	void randomRotation(GameObject rock){
		Quaternion rRot = Random.rotation;
		rock.transform.rotation = new Quaternion (0, rRot.y, 0, 1);
	}
}
