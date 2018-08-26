using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		
	}

	public void checkIfEmpty(){
		
		for(int i = 0; i<fields.Length; i++){
			if (fields[i].transform.childCount > 0) {
				//Debug.Log (fields[i].name + i +" ma " + fields[i].transform.childCount + " dzieci");
				fieldsEmpty[i] = 0;
			} else {
				//Debug.Log (fields[i].name + i + " nie ma dzieci");
				fieldsEmpty[i] = 1;
			}
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
}
