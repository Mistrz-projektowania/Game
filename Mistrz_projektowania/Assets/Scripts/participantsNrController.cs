using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class participantsNrController : MonoBehaviour {
	private string participantsNr;
	// Use this for initialization
	void Start () {
		participantsNr = (GameplayModel.gameParticipantsNr + GameplayModel.gameNotPayingParticipantsNr).ToString();
		Text participantsNrField = GetComponent<Text> ();
		participantsNrField.text = participantsNr;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
