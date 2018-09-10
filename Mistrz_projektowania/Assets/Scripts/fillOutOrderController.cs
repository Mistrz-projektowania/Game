using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fillOutOrderController : MonoBehaviour {

	CurrentFieldController checkCurrentField;

	// Use this for initialization
	void Start () {
		checkCurrentField = GameObject.Find ("GameController").GetComponent<CurrentFieldController> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	int getFieldIndex(string type){
		if (type == "Nr imprezy") {
			return 0;
		} else if (type == "Zleceniodawca") {
			return 1;
		} else if (type == "Kontakt zleceniodawcy") {
			return 3;
		} else if (type == "Hotel") {
			return 4;
		} else if (type == "Wyżywienie") {
			return 5;
		} else if (type == "Usługi") {
			return 6;
		} else {
			return -1;
		}
	}

	public bool wrongField(string type){
		checkCurrentField.checkIfEmpty ();
		int minIndex = checkCurrentField.getNextRockIndex();
		if (minIndex == getFieldIndex (type)) {
			Debug.Log ("MIN INDEX: " + minIndex);
			Debug.Log ("field INDEX: " + getFieldIndex (type));
			return false;
		} else {
			Debug.Log ("MIN INDEX: " + minIndex);
			return true;
		}
	
	}
}
