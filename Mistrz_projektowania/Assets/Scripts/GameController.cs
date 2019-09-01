﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
	private int points;
	public Canvas noPointMessagePanel;
	public Image noPointsMessage;
	private bool noPointsMessageDisplay;
	public Image wrongInputMessage;
	public Image wrongOrderMessage;
	public Image systemInfo;
	private int tripID;

  
	public XMLDataLoader dataLoader;
	public List<Dictionary<string,string>> thisLevelTrip;

	private int[] dataOrder;
	private int[] rockOrder;

	void Awake(){
		Application.targetFrameRate = 300;
	}
	// Use this for initialization
	void Start () {
		StartCoroutine(fadeMessage(noPointsMessage, false, 0.0000001f));
		StartCoroutine(fadeMessage(wrongInputMessage, false, 0.0000001f));
		StartCoroutine(fadeMessage(wrongOrderMessage, false, 0.0000001f));
		StartCoroutine(fadeMessage(systemInfo, false, 0.0000001f));
		noPointsMessageDisplay = false;
		points = GameplayModel.gamePoints;
		tripID = GameplayModel.gameTripID; 
		print (GameplayModel.gameTripName);

		dataLoader = GetComponent<XMLDataLoader> ();      
		dataLoader.GetData(tripID, "Plan");
		thisLevelTrip = dataLoader.getCurrentTripData();
		//Debug.Log ((thisLevelTrip [1]) ["Nr"]);
		//Debug.Log ((thisLevelTrip [2]) ["NazwaZleceniodawcy"]);
		//Debug.Log ((thisLevelTrip [0]) ["Nr"]);
		dataOrder = drawTheOrder(7, 7);
		string dataOrderString = "";
		for (int i = 0; i < dataOrder.Length; i++) {
			dataOrderString += dataOrder [i];
			dataOrderString += ", ";
		}
		//Debug.Log ("DATA ORDER: " + dataOrderString);
		dataLoader.setDataSlots (dataOrder);

		showFPS (GameplayModel.gameFPSOn);
    }
		

	// Update is called once per frame
	void Update () {
		
	}

	public void printDataOrder(){
		string dataOrderString = "";
		for (int i = 0; i < dataOrder.Length; i++) {
			dataOrderString += dataOrder [i];
			dataOrderString += ", ";
		}
		Debug.Log ("DATA ORDER: " + dataOrderString);
	}

	public void showFPS(bool show){
		GameObject fpsCounter = GameObject.Find ("FPScounterController");
		fpsCounter.SetActive (show);
	}

	public int[] getDataOrder(){
		return dataOrder;
	}

	public void swapDataOrder(int index1, int index2){
		int temp = dataOrder[index1];
		dataOrder [index1] = dataOrder [index2];
		dataOrder [index2] = temp;
	}

	public void changePoints(int value){
		points += value;
		//Debug.Log (points);
		if (points <= 0) {
			points = 0;
			if (noPointsMessageDisplay == false && StateMachine.getState() != 7) {
				StateMachine.setState (10);
				StartCoroutine (fadeMessage (noPointsMessage, true, 0.5f));
				noPointsMessageDisplay = true;
				//StartCoroutine (closePointsMessage(10f));
			}
		}
		GameplayModel.gamePoints = points;
	}
    public void subtractPoints(int value)
    {
        points -= value;
        //Debug.Log (points);
        if (points <= 0)
        {
            points = 0;
            if (noPointsMessageDisplay == false)
            {
                StartCoroutine(fadeMessage(noPointsMessage, true, 0.5f));
                noPointsMessageDisplay = true;
                //StartCoroutine (closePointsMessage(10f));
            }
        }
		GameplayModel.gamePoints = points;
    }

    public int getPoints(){
		return points;
	}


	IEnumerator closePointsMessage(float seconds){
		yield return new WaitForSeconds (seconds);
		StartCoroutine (fadeMessage (noPointsMessage, false, 0.5f));
		noPointsMessageDisplay = false;
	}
	IEnumerator openPointsMessage(float seconds){
		yield return new WaitForSeconds (seconds);
		StartCoroutine (fadeMessage (noPointsMessage, true, 0.5f));
		noPointsMessageDisplay = true;
	}
	public void showPointsMessage(){
		StartCoroutine (openPointsMessage(10f));
	}
	public IEnumerator fadeMessage(Image message, bool fadeIn, float duration){
		float counter = 0f;

		float a, b;
		if (fadeIn)
		{
			if(message == noPointsMessage) 
				message.transform.position = new Vector3 (0.0f, Screen.height, 0.0f);
			else if (message == systemInfo)
				message.transform.position = new Vector3 (Screen.width / 2, Screen.height - 80,0.0f);
			else
				message.transform.position = new Vector3 (Screen.width / 2, 120,0.0f);
			a = 0;
			b = 1;
		}
		else
		{
			a = 1;
			b = 0;
		}

		CanvasGroup selectedMessage = message.GetComponent<CanvasGroup>();

		while (counter < duration)
		{
			counter += Time.deltaTime;
			float alpha = Mathf.Lerp(a, b, counter / duration);

			selectedMessage.alpha = alpha;

			yield return null;
		}
		if (fadeIn == false) {
			message.transform.position = new Vector3 (-message.GetComponent<RectTransform>().rect.width, message.GetComponent<RectTransform>().rect.height,0.0f);
		}
	}

	public static int[] drawTheOrder(int n,int k)
	{
		// Debug.Log("DRAW THE ORDER");
		int[] order = new int[k];
		// wypełnianie tablicy liczbami 1,2...n
		int[] numbers = new int[n];
		for (int i = 0; i < n; i++)
			numbers[i] = i + 1;
		// losowanie k liczb
		for (int i = 0; i < k; i++)
		{
			// tworzenie losowego indeksu pomiędzy 0 i n - 1
			int r = Random.Range(0, n);

			// wybieramy element z losowego miejsca
			//Debug.Log(numbers[r]);
			order [i] = numbers [r] - 1;

			// przeniesienie ostatniego elementu do miejsca z którego wzięliśmy
			numbers[r] = numbers[n - 1];
			n--;
		}
			//Debug.Log("-----------------");
		return order;
	}

}
