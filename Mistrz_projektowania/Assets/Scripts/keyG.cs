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
	// Use this for initialization
	void Start () {
		//GameObject.Find ("Afterburner").SetActive (false);
		//GTSbutton = GetComponent<Button> ();
		ps = GameObject.Find ("Afterburner").GetComponent<ParticleSystem> ();
		ps.Stop ();
		GTSbutton.onClick.AddListener(GTSon);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			Debug.Log ("Kliknales G");
			GTSbutton.onClick.Invoke();		
		}
	}

	void GTSon(){
		Debug.Log ("GTS ON");
		CurrentFieldController checkFieldFillOutOrder = GameObject.Find ("GameController").GetComponent<CurrentFieldController> ();
		checkFieldFillOutOrder.checkIfEmpty ();

		int[] dataOrder = GameObject.Find ("GameController").GetComponent<GameController> ().getDataOrder();
		int minIndex = checkFieldFillOutOrder.getNextRockIndex();
		int minIndexPosition = dataOrder[minIndex];

		Debug.Log ("minIndex: " + minIndex);
		GTS.GetComponent<RockSort> ().sort ();
	}

	IEnumerator waitFor(int seconds){
		yield return new WaitForSeconds (seconds);
		ps.Play ();
	}
}
