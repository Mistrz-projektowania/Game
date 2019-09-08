using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentFieldController : MonoBehaviour {

	public GameObject[] fields;
	public int currentField = 0;
	private int[] fieldsEmpty;

	// Use this for initialization
	void Start () {
		fieldsEmpty = new int[fields.Length];
	}
	
	// Update is called once per frame
	void Update () {
		checkIfEmpty ();
	}

	public void checkIfEmpty(){
		
		for(int i = 0; i<fields.Length; i++){
			if (fields[i].transform.childCount > 0) {
				fieldsEmpty[i] = 0;
			} else {
				fieldsEmpty[i] = 1;
			}
		}
		if (fields [2].GetComponentInChildren<Text> ().text != "Wybierz datę rozpoczęcia...") {
			fieldsEmpty [2] = 0;
		} else {
			fieldsEmpty [2] = 1;
		}
	}
	public int getNextRockIndex(){
		for (int i = 0; i < fieldsEmpty.Length; i++) {
			if (fieldsEmpty[i] == 1) {
				return i;
			}
		}
		return 0;
	}

	public int getNextRockIndexForSunMop(){
		for (int i = 0; i < fieldsEmpty.Length; i++) {
			if (fieldsEmpty[i] == 1) {
				Debug.Log ("Next rock index: " + i);
				if (i > 2)
					i -= 1;
				return i;
			}
		}
		return 0;
	}

	public bool checkIfAllFilled(){
		int sum = 0;
		for (int i = 0; i < fieldsEmpty.Length; i++) {
			sum += fieldsEmpty [i];
		}
		if (sum == 0)
			return true;
		else
			return false;
	}

	public void emptyFieldsArray(){
		string fieldArr = "";
		for (int i = 0; i < fieldsEmpty.Length; i++) {
			fieldArr += fieldsEmpty [i];
		}
		Debug.Log (fieldArr);
	}
}
