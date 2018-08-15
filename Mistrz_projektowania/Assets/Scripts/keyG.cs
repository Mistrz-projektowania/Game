using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyG : MonoBehaviour {

	public string inputKey;
	public Button GTSbutton;
	public GameObject GTS;
	public GameObject [] rocks;
	// Use this for initialization
	void Start () {
		//GTSbutton = GetComponent<Button> ();
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
		int[] dataOrder = GameObject.Find ("GameController").GetComponent<GameController> ().getDataOrder();
		int minIndex = 0;
		int minIndexPosition = dataOrder[0];

		Debug.Log (minIndexPosition);
		Debug.Log (GTS.transform.position);
		Vector3 newPos = rocks [minIndexPosition].transform.position;
		GameObject.Find ("Frisbee").GetComponent<GTSRotation> ().setNewStartPos(new Vector3(newPos.x, newPos.y + 2, newPos.z));
		//GameObject.Find ("Afterburner").SetActive (true);
		Debug.Log (GTS.transform.position);
	}
}
