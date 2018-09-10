using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanelController : MonoBehaviour {

	public GameObject infoPanel;
	public Button openInfo;
	public Button closeInfo;
	// Use this for initialization
	void Start () {
		infoPanel.SetActive (false);
		openInfo.onClick.AddListener (panelShow);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void panelShow(){
		infoPanel.SetActive (true);
		closeInfo.onClick.AddListener (panelHide);
	}
	void panelHide(){
		infoPanel.SetActive (false);
	}

}
