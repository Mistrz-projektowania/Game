using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finishGameController : MonoBehaviour {
	public Button finishButton;
	public GameObject finish;
	public GameObject finishGUI;

	private StateMachine stateMachine;

	public Dictionary<string,string> tripData = new Dictionary<string,string>();
	public Dictionary<string,string> playerData = new Dictionary<string,string>();

	// Dane potrzebne do rankingu
	public Text[] playerDataTexts;
	public Text[] tripDataTexts;

	// Use this for initialization
	void Start () {
		finishButton.enabled = false;
		finish.SetActive(false);
		finishGUI.SetActive(false);

		stateMachine = GameObject.Find ("StateMachine").GetComponent<StateMachine> ();
	}

	// Update is called once per frame
	void Update () {
		CurrentFieldController checkFieldFillOutOrder = GameObject.Find ("GameController").GetComponent<CurrentFieldController> ();
		if (checkFieldFillOutOrder.checkIfAllFilled () == true) {
			//Debug.Log("MOZNA SKONCZYC GRE");
			showFinishButton ();
			finishButton.onClick.AddListener (showFinishData);
		}

	}

	void showFinishButton(){
		finish.SetActive(true);
		finishButton.enabled = true;
		stateMachine.setState (7);
		StartCoroutine(fadeButton (finishButton, true, 0.5f));
	}

	IEnumerator fadeButton(Button button, bool fadeIn, float duration){
		float counter = 0f;

		float a, b;
		if (fadeIn)
		{
			a = 0;
			b = 1;
		}
		else
		{
			a = 1;
			b = 0;
		}
		CanvasGroup selectedButton = button.GetComponent<CanvasGroup>();

		while (counter < duration)
		{
			counter += Time.deltaTime;
			float alpha = Mathf.Lerp(a, b, counter / duration);
			//Debug.Log(alpha);

			selectedButton.alpha = alpha;

			yield return null;
		}
	}

	void getPlayerData(){
		string playerName; ///////////////////////////////////// Pobrac imie gracza
		string playerTime, playerPoints;
		string [] fields;
		playerName = "Ola";
		addDataToPlayerDataList ("Gracz", playerName);

		playerTime = GameObject.Find ("timerText").GetComponent<timeCounter> ().getTimerValue ();
		addDataToPlayerDataList ("Czas", playerTime);

		playerPoints = GameObject.Find ("playerPoints").GetComponent<showPlayerPoints> ().getPlayerPoints ().ToString();
		addDataToPlayerDataList ("Punkty", playerPoints);

		GetFieldData fieldData = GameObject.Find ("GameController").GetComponent<GetFieldData> ();
		fields = new string[fieldData.getFieldsSize ()];

		for (int i = 0; i < fields.Length-1; i++) { //////////////////// zlikwidowac pozniej -1
			fields [i] = fieldData.getFieldData (i);
		}
		addDataToTripDataList ("Nr imprezy", fields [0]);
		addDataToTripDataList ("Zleceniodawca", fields [1]);
		addDataToTripDataList ("Termin imprezy", fields [2]);
		//addDataToTripDataList ("Liczba osób", fields [3]);
		addDataToTripDataList ("Kontakt zleceniodawcy", fields [4]);
		addDataToTripDataList ("Trasa", fields [5]);
		addDataToTripDataList ("Hotel", fields [6]);
		addDataToTripDataList ("Wyżywienie", fields [7]);
		addDataToTripDataList ("Usługi", fields [8]);
	}

	void addDataToPlayerDataList(string dataType, string data){
		playerData.Add (dataType, data);
	}
	void addDataToTripDataList(string dataType, string data){
		tripData.Add (dataType, data);
	}

	void printPlayerData(){
		string data = "";
			foreach (KeyValuePair<string, string> kvp in playerData) {
				//Debug.Log (kvp.Key + " " + kvp.Value);
				data += string.Format ("{0}: {1}\n", kvp.Key, kvp.Value);
				//data += string.Format("{0}\n", kvp.Value);	
		}
		Debug.Log (data);
	}
	void printTripData(){
		string data = "";
			foreach (KeyValuePair<string, string> kvp in tripData) {
				//Debug.Log (kvp.Key + " " + kvp.Value);
				data += string.Format ("{0}: {1}\n", kvp.Key, kvp.Value);
				//data += string.Format("{0}\n", kvp.Value);	
		}
		Debug.Log (data);
	}

	void showPlayerData(){
		int i = 0;
		foreach(string key in playerData.Keys){
			playerDataTexts[i].text = key + ":\n" + playerData[key] + "\n";
			i++;
		}
	}
	void showTripData(){
		int i = 0;
		foreach(string key in tripData.Keys){
			tripDataTexts[i].text = key + ":\n" + tripData[key] + "\n";
			i++;
		}
	}
	void showFinishData(){
		getPlayerData ();
		finishGUI.SetActive(true);
		showPlayerData ();
		showTripData ();
	}
}
