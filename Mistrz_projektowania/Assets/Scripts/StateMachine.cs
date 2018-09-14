using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

	public int currentState;
	public int previousState;

	WitchController witchCtrl;
	SunMopController sunMopCtrl;


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
		 */
		currentState = 0;
		previousState = 0;
		witchCtrl = GameObject.Find ("Witch").GetComponent<WitchController> ();
		sunMopCtrl = GameObject.Find ("SunMop").GetComponent<SunMopController> ();
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
		if(currentState == 2){
			witchCtrl.runWitch ();

		}
		if (currentState == 3) {
			sunMopCtrl.SunMopON ();
		}
	}

	public void setState(int state){
		previousState = currentState;
		currentState = state;
	}

	public int getState(){
		return currentState;
	}

	IEnumerator waitForAndDraw(int seconds){
		yield return new WaitForSeconds (seconds);
		if (currentState == 0) {
			int r = Random.Range (0, 2);
			//Debug.Log ("LOSUJEMY " + r);
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
