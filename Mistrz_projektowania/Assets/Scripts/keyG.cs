using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyG : MonoBehaviour {

	public string inputKey;
	public Button GTSbutton;
	public GameObject GTS;
	public GameObject [] rocks;
	ParticleSystem ps;

	private StateMachine stateMachine;
	// Use this for initialization
	void Start () {
		//GameObject.Find ("Afterburner").SetActive (false);
		//GTSbutton = GetComponent<Button> ();
		ps = GameObject.Find ("Afterburner").GetComponent<ParticleSystem> ();
		ps.Stop ();
		GTSbutton.onClick.AddListener(GTSon);
		stateMachine = GameObject.Find ("StateMachine").GetComponent<StateMachine> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			Debug.Log ("Kliknales G");
			if (stateMachine.getState () == 0) {
				GTSbutton.onClick.Invoke ();		
			}
		}
	}

	void GTSon(){
		stateMachine.setState (4);
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
