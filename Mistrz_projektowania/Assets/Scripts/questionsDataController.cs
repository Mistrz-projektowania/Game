using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questionsDataController : MonoBehaviour {

	public Text pointsText;
	public int pointsSum = 0;
	private XMLDataLoader dataLoader;
	Dropdown tNameDropdown;
	Dropdown pNrDropdown;
	Dropdown nppNrDropdown;
	Dropdown ptDropdown;
	Dropdown vehDropdown;
	Dropdown tlDropdown;
	// Use this for initialization
	void Start () {
		dataLoader = GameObject.Find ("QuestionsDataController").GetComponent<XMLDataLoader> ();

		tNameDropdown = GameObject.Find ("DropdownTripName").GetComponent<Dropdown> ();
		tNameDropdown.AddOptions (dataLoader.getQuestionsData ("tripName"));
		pNrDropdown = GameObject.Find ("DropdownParticipantsNr").GetComponent<Dropdown> ();
		pNrDropdown.AddOptions (dataLoader.getQuestionsData ("participantsNr"));
		nppNrDropdown = GameObject.Find ("DropdownNotPayingParticipantsNr").GetComponent<Dropdown> ();
		nppNrDropdown.AddOptions (dataLoader.getQuestionsData ("notPayingParticipantsNr"));
		ptDropdown = GameObject.Find ("DropdownParticipantsType").GetComponent<Dropdown> ();
		ptDropdown.AddOptions (dataLoader.getQuestionsData ("participantsType"));
		vehDropdown = GameObject.Find ("DropdownVehicle").GetComponent<Dropdown> ();
		vehDropdown.AddOptions (dataLoader.getQuestionsData ("vehicle"));
		tlDropdown = GameObject.Find ("DropdownTripLength").GetComponent<Dropdown> ();
		tlDropdown.AddOptions (dataLoader.getQuestionsData ("tripLength"));

		countPoints ();

		tNameDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
		});
		pNrDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
		});
		nppNrDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
		});
		ptDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
		});
		vehDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
		});
		tlDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
		});



	}

	void countPoints(){
		pointsSum = 0;
		pointsSum += dataLoader.checkPoints ("tripName", tNameDropdown.value);
		pointsSum += dataLoader.checkPoints ("tripLength", tlDropdown.value);
		pointsSum += dataLoader.checkPoints ("vehicle", vehDropdown.value);
		pointsSum += dataLoader.checkPoints ("participantsType", ptDropdown.value);
		pointsSum += dataLoader.checkPoints ("participantsNr", pNrDropdown.value);
		pointsSum += dataLoader.checkPoints ("notPayingParticipantsNr", nppNrDropdown.value);
		GameplayModel.gamePoints = pointsSum;
		pointsText.text = "Punkty: " + pointsSum.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
