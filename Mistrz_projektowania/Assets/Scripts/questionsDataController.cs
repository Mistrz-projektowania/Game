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

	string tripNameDatabaseName = "tripName";
	string participantsNrDatabaseName = "participantsNr";
	string notPayingParticipantsNrDatabaseName = "notPayingParticipantsNr";
	string participantsTypeDatabaseName = "participantsType";
	string vehicleDatabaseName = "vehicle";
	string tripLengthDatabaseName = "tripLength";

	// Use this for initialization
	void Start () {
		dataLoader = GameObject.Find ("QuestionsDataController").GetComponent<XMLDataLoader> ();

		handleTripNameDropdown ();
		handleParticipantsNrDropdown ();
		handleNotPayingParticipantsNrDropdown ();
		handleParticipantsTypeDropdown ();
		handleVehicleTypeDropdown ();
		handleTripLengthDropdown ();

		countPoints ();
	}

	void handleTripNameDropdown(){
		tNameDropdown = GameObject.Find ("DropdownTripName").GetComponent<Dropdown> ();
		tNameDropdown.AddOptions (dataLoader.getQuestionsData (tripNameDatabaseName));
		GameplayModel.gameTripName = setGlobalData(tripNameDatabaseName, tNameDropdown.value);
		GameplayModel.gameTripID = tNameDropdown.value;
		tNameDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
			GameplayModel.gameTripName = setGlobalData(tripNameDatabaseName, tNameDropdown.value);
			Debug.Log (GameplayModel.gameTripName);
			GameplayModel.gameTripID = tNameDropdown.value;
		});
	}
	void handleParticipantsNrDropdown(){
		pNrDropdown = GameObject.Find ("DropdownParticipantsNr").GetComponent<Dropdown> ();
		pNrDropdown.AddOptions (dataLoader.getQuestionsData (participantsNrDatabaseName));
		GameplayModel.gameParticipantsNr = int.Parse(setGlobalData( participantsNrDatabaseName, pNrDropdown.value));
		pNrDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
			GameplayModel.gameParticipantsNr = int.Parse(setGlobalData( participantsNrDatabaseName, pNrDropdown.value));
			Debug.Log (GameplayModel.gameParticipantsNr);
		});
	}

	void handleNotPayingParticipantsNrDropdown(){
		nppNrDropdown = GameObject.Find ("DropdownNotPayingParticipantsNr").GetComponent<Dropdown> ();
		nppNrDropdown.AddOptions (dataLoader.getQuestionsData (notPayingParticipantsNrDatabaseName));
		GameplayModel.gameNotPayingParticipantsNr = int.Parse(setGlobalData(notPayingParticipantsNrDatabaseName, nppNrDropdown.value));
		nppNrDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
			GameplayModel.gameNotPayingParticipantsNr = int.Parse(setGlobalData(notPayingParticipantsNrDatabaseName, nppNrDropdown.value));
			Debug.Log (GameplayModel.gameNotPayingParticipantsNr);

		});
	}
	void handleParticipantsTypeDropdown(){
		ptDropdown = GameObject.Find ("DropdownParticipantsType").GetComponent<Dropdown> ();
		ptDropdown.AddOptions (dataLoader.getQuestionsData (participantsTypeDatabaseName));
		ptDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
			GameplayModel.gameParticipantsType = setGlobalData(participantsTypeDatabaseName, ptDropdown.value);
		});
	}

	void handleVehicleTypeDropdown(){
		vehDropdown = GameObject.Find ("DropdownVehicle").GetComponent<Dropdown> ();
		vehDropdown.AddOptions (dataLoader.getQuestionsData (vehicleDatabaseName));
		GameplayModel.gameVehicleType = setGlobalData(vehicleDatabaseName, vehDropdown.value);
		vehDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
			GameplayModel.gameVehicleType = setGlobalData(vehicleDatabaseName, vehDropdown.value);
		});
	}

	void handleTripLengthDropdown(){
		tlDropdown = GameObject.Find ("DropdownTripLength").GetComponent<Dropdown> ();
		tlDropdown.AddOptions (dataLoader.getQuestionsData (tripLengthDatabaseName));
		GameplayModel.gameTripLength = int.Parse(setGlobalData(tripLengthDatabaseName, tlDropdown.value));
		tlDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
			GameplayModel.gameTripLength = int.Parse(setGlobalData(tripLengthDatabaseName, tlDropdown.value));
			Debug.Log("Length");
			Debug.Log(GameplayModel.gameTripLength);
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

	string setGlobalData(string databaseName, int id){
		return dataLoader.getGameData (databaseName, id);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
