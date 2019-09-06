using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour {

	public static int currentState;
	public static int previousState;
	public Button buttonHelp;

	WitchController witchCtrl;
	SunMopController sunMopCtrl;
	RockSort sorting;
	keyG gts;


	// Use this for initialization
	void Start () {
		/*
		 * 0 - nic sie nie dzieje
		 * 1 - gracz odkrył głaz
		 * 2 - czarownica miesza głazy
		 * 3 - gracz podaje krzemień / sunMop
		 * 4 - gracz używa GTS / sortowanie
		 * 5 - blok GTS
		 * 6 - gracz odpowiada na pytania Quizu
		 * 7 - koniec gry
		 * 8 - pauza
		 * 9 - wybór podpowiedzi
		 * 10 - przegrana
		 */
		currentState = 8;
		previousState = 8;
		witchCtrl = GameObject.Find ("Witch").GetComponent<WitchController> ();
		sunMopCtrl = GameObject.Find ("SunMop").GetComponent<SunMopController> ();
		buttonHelp = GameObject.Find ("HelpfulQuestionsButton").GetComponent<Button> ();
		gts = GameObject.Find("GameController").GetComponent<keyG>();
		witchStateControl ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Previous State: " + previousState);
		//Debug.Log ("Current State: " + currentState);
		/*
		if (Input.GetKeyDown (KeyCode.W)){
			if (currentState == 0) {
				setState (2);
			}
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			Debug.Log ("Kliknales S");
			if (currentState == 0) {
				setState (3);
			}
		}
		*/
		if (currentState != 0) {
			buttonHelp.interactable = false;
		} else
			buttonHelp.interactable = true;
		
		if (currentState == 8) {
			soundController.pauseAmbientGameplaySound ();
		} else soundController.playAmbientGameplaySound ();

		if(currentState == 2 && currentState != 5 && currentState != 6 && currentState != 4 && currentState != 7){
			witchCtrl.runWitch ();

		}

		if (currentState == 4) {
			gts.GTSon ();
		}

	}

	public static void setState(int state){
		previousState = currentState;
		currentState = state;
		Debug.Log ("Current State: " + currentState);
	}

	public static int getState(){
		return currentState;
	}
	public static int getPreviousState(){
		return previousState;
	}
	IEnumerator waitForAndDraw(int seconds){
		yield return new WaitForSeconds (seconds);
		if (currentState == 0) {
			int r = Random.Range (0, 2);
			if (r == 1) {
				setState (2);
			}
		}
		witchStateControl ();
	}

	void witchStateControl(){
		if (GameObject.Find ("Witch") != null) {
			if (GameObject.Find ("Witch").activeSelf == true) {
				StartCoroutine (waitForAndDraw (15));
			}
		}

	}
}
