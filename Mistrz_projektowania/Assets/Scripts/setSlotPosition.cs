using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setSlotPosition : MonoBehaviour {
	public GameObject myObject;
	public GameObject parentObject;
	// Use this for initialization
	void Start () {
		//myObject.transform.parent = parentObject.transform;
		Vector3 pos = Camera.main.WorldToScreenPoint(parentObject.transform.position);
		myObject.transform.position = new Vector3(pos.x, pos.y, 0);
		//Debug.Log (myObject.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
