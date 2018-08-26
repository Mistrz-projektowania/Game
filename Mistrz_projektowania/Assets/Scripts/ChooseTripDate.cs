﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseTripDate : MonoBehaviour {

	int tripLength;

	GameObject calendarMonth;
	GameObject calendarYear;
	GameObject calendarButtonText;
	private DateTime chosenDate;
	private DateTime chosenEndDate;
	// Use this for initialization
	void Start () {
		tripLength = 3;

		
		this.GetComponent<Button> ().onClick.AddListener (getDate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void getDate(){
		calendarMonth = GameObject.Find ("CalendarMonth");
		calendarYear = GameObject.Find ("CalendarYear");
		calendarButtonText = GameObject.Find ("CalendarButtonText");
		Text day = this.GetComponentInChildren<Text> ();
		//Debug.Log (this.GetComponentInChildren<Text> ().text);
		if(day.text != ""){
			int d = int.Parse(day.text);
			int m = int.Parse(calendarMonth.GetComponent<Text>().text);
			int y = int.Parse(calendarYear.GetComponent<Text>().text);
			chosenDate = new DateTime (y, m, d);
			chosenEndDate = chosenDate.AddDays(tripLength);
			calendarButtonText.GetComponent<Text>().text = chosenDate.Day + "/" + chosenDate.Month + "/" + chosenDate.Year + " - " + chosenEndDate.Day + "/" + chosenEndDate.Month + "/" + chosenEndDate.Year ;
		}
	}
}
