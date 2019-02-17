using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questionsDataController : MonoBehaviour {

	private XMLDataLoader dataLoader;
	// Use this for initialization
	void Start () {
		dataLoader = new XMLDataLoader ();

		dataLoader.getQuestionsData ("participantsNr");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
