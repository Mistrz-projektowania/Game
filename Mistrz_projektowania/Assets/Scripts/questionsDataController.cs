using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questionsDataController : MonoBehaviour {

	private XMLDataLoader dataLoader;
	// Use this for initialization
	void Start () {
		dataLoader = GameObject.Find ("QuestionsDataController").GetComponent<XMLDataLoader> ();

		Dropdown tNameDropdown = GameObject.Find ("DropdownTripName").GetComponent<Dropdown> ();
		tNameDropdown.AddOptions (dataLoader.getQuestionsData ("tripName"));
		Dropdown pNrDropdown = GameObject.Find ("DropdownParticipantsNr").GetComponent<Dropdown> ();
		pNrDropdown.AddOptions (dataLoader.getQuestionsData ("participantsNr"));
		Dropdown nppNrDropdown = GameObject.Find ("DropdownNotPayingParticipantsNr").GetComponent<Dropdown> ();
		nppNrDropdown.AddOptions (dataLoader.getQuestionsData ("notPayingParticipantsNr"));

	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
