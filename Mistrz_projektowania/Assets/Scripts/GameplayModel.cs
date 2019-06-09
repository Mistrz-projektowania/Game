using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayModel : MonoBehaviour {

	static public bool gamePause = true;

	static public int gameLevel = 1;
	static public string gameCharacter = "Łukasz";

	static public int gameTripID = 0;
	static public string gameTripName = "";
	static public int gameParticipantsNr = 0;
	static public int gameNotPayingParticipantsNr = 0;
	static public int gameTripLength = 1;
	static public string gameVehicleType = "";
	static public string gameParticipantsType = "";

	static public int gamePoints = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
