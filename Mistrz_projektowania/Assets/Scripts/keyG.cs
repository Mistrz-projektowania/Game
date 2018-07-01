using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyG : MonoBehaviour {

	public string inputKey;
	public Button GTSbutton;
	// Use this for initialization
	void Start () {
		//GTSbutton = GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			Debug.Log ("Kliknales G");
			GTSbutton.onClick.Invoke ();		
		}
	}
}
