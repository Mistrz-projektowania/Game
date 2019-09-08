using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetFieldData : MonoBehaviour {

	public GameObject[] fields;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getFieldsSize(){
		return fields.Length;
	}

	public string getFieldData(int index){
		
		if (fields [index].GetComponentsInChildren<Text> () != null) {
			return fields [index].GetComponentsInChildren<Text> () [0].text;
		} else
			return "";
	}
}
