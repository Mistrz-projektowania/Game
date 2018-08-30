﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeCounter : MonoBehaviour {

	public Text timerText;
	public float secondsCount;
	private int minuteCount;
	private int hourCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTimerUI();
	}
	public void UpdateTimerUI(){
		secondsCount += Time.deltaTime;
		timerText.text = "Czas: " + hourCount + ":" + minuteCount.ToString("00") + ":" + ((int)secondsCount).ToString("00");
		if(secondsCount >= 60){
			minuteCount++;
			secondsCount = 0;
		}else if(minuteCount >= 60){
			hourCount++;
			minuteCount = 0;
		}    
	}
	public string getTimerValue(){
		return(hourCount + ":" + minuteCount.ToString ("00") + ":" + ((int)secondsCount).ToString ("00"));
	}
}
