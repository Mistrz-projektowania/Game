using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyG : MonoBehaviour {

	public string inputKey;
	public Button GTSbutton;
	public GameObject GTS;
	public GameObject [] rocks;
	public ParticleSystem ps;
	 

	// Use this for initialization
	public void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			Debug.Log ("Kliknales G");
			if (StateMachine.getState () == 0) {
				GTSbutton.onClick.Invoke ();		
			}
		}
	}

	public void GTSon(){
		StateMachine.GTSrunning = true;
		Debug.Log ("GTS ON");
		CurrentFieldController checkFieldFillOutOrder = GameObject.Find ("GameController").GetComponent<CurrentFieldController> ();
		checkFieldFillOutOrder.checkIfEmpty ();

		GTS.GetComponent<RockSort> ().sort ();
	}

	IEnumerator waitFor(int seconds){
		yield return new WaitForSeconds (seconds);
		ps.Play ();
	}
}
