using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setSlotPosition : MonoBehaviour {
	public GameObject myObject;
	public GameObject parentObject;
	private Vector3 pos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		pos = Camera.main.WorldToScreenPoint(parentObject.transform.position - new Vector3(0,0.5f,0));
		myObject.transform.position = new Vector3(pos.x, pos.y, 0);
	}
}
