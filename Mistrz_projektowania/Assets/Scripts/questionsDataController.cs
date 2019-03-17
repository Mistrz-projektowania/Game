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

		tNameDropdown = GameObject.Find ("DropdownTripName").GetComponent<Dropdown> ();
		tNameDropdown.AddOptions (dataLoader.getQuestionsData (tripNameDatabaseName));
		GameplayModel.gameTripName = dataLoader.getGameData (tripNameDatabaseName, tNameDropdown.value);

		pNrDropdown = GameObject.Find ("DropdownParticipantsNr").GetComponent<Dropdown> ();
		pNrDropdown.AddOptions (dataLoader.getQuestionsData (participantsNrDatabaseName));
		GameplayModel.gameParticipantsNr = int.Parse(dataLoader.getGameData( participantsNrDatabaseName, pNrDropdown.value));

		nppNrDropdown = GameObject.Find ("DropdownNotPayingParticipantsNr").GetComponent<Dropdown> ();
		nppNrDropdown.AddOptions (dataLoader.getQuestionsData (notPayingParticipantsNrDatabaseName));
		GameplayModel.gameNotPayingParticipantsNr = int.Parse(dataLoader.getGameData(notPayingParticipantsNrDatabaseName, nppNrDropdown.value));

		ptDropdown = GameObject.Find ("DropdownParticipantsType").GetComponent<Dropdown> ();
		ptDropdown.AddOptions (dataLoader.getQuestionsData (participantsTypeDatabaseName));
		vehDropdown = GameObject.Find ("DropdownVehicle").GetComponent<Dropdown> ();
		vehDropdown.AddOptions (dataLoader.getQuestionsData (vehicleDatabaseName));
		tlDropdown = GameObject.Find ("DropdownTripLength").GetComponent<Dropdown> ();
		tlDropdown.AddOptions (dataLoader.getQuestionsData (tripLengthDatabaseName));
		GameplayModel.gameTripLength = int.Parse(dataLoader.getGameData(tripLengthDatabaseName, tlDropdown.value));

		countPoints ();

		tNameDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
			GameplayModel.gameTripName = dataLoader.getGameData (tripNameDatabaseName, tNameDropdown.value);
			Debug.Log (GameplayModel.gameTripName);
		});
		pNrDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
			GameplayModel.gameParticipantsNr = int.Parse(dataLoader.getGameData( participantsNrDatabaseName, pNrDropdown.value));
			Debug.Log (GameplayModel.gameParticipantsNr);
		});
		nppNrDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
			GameplayModel.gameNotPayingParticipantsNr = int.Parse(dataLoader.getGameData(notPayingParticipantsNrDatabaseName, nppNrDropdown.value));
			Debug.Log (GameplayModel.gameNotPayingParticipantsNr);
		});
		ptDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
		});
		vehDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
		});
		tlDropdown.onValueChanged.AddListener(delegate {
			countPoints ();
			GameplayModel.gameTripLength = int.Parse(dataLoader.getGameData(tripLengthDatabaseName, tlDropdown.value));
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
	
	// Update is called once per frame
	void Update () {
		
	}
}
