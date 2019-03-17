using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CalendarPopUp : MonoBehaviour {
	public GameObject Calendar;
	public GameObject calendarButton;
	public GameObject[] DayLabels; 
	public string[] Months;  
	public Text HeaderLabel;
	public Text calendarMonth;
	public Text calendarYear;

	bool showCalendar;

	public Button calendarBtn;
	public Button nextBtn;
	public Button prevBtn;

	Vector3 calendarPosition;
	RectTransform rt;

	[SerializeField]
	private int monthCounter = DateTime.Now.Month - 1;
	[SerializeField]
	private int yearCounter = 0;

	[SerializeField]
	private DateTime chosenMonth;
	[SerializeField]
	private DateTime currentDisplay;
	public int todayDate;

	// Use this for initialization
	void Start () {
		rt = (RectTransform)calendarButton.transform;

		showCalendar = false;
		Calendar.SetActive(showCalendar);
		clearLabels ();
		CreateMonths();
		CreateCalendar();
		todayDate = (DateTime.Now.Day);

		nextBtn.onClick.AddListener (nextMonth);
		prevBtn.onClick.AddListener (previousMonth);
		calendarBtn.onClick.AddListener (showCalendarPopUp);
	}
	
	// Update is called once per frame
	void Update () {
		setPosition ();
	}

	void CreateMonths()
	{
		chosenMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
		HeaderLabel.text = Months[DateTime.Now.Month - 1] + " " + DateTime.Now.Year;
		calendarMonth.text = (DateTime.Now.Month).ToString();
		calendarYear.text = DateTime.Now.Year.ToString();
	}


	void CreateCalendar()
	{
		int startWeekDay = 0;
		currentDisplay = chosenMonth;
		if (currentDisplay.DayOfWeek == DayOfWeek.Monday) {
		} else if(currentDisplay.DayOfWeek == DayOfWeek.Tuesday){
			startWeekDay = 1;
		} else if(currentDisplay.DayOfWeek == DayOfWeek.Wednesday){
			startWeekDay = 2;
		} else if(currentDisplay.DayOfWeek == DayOfWeek.Thursday){
			startWeekDay = 3;
		} else if(currentDisplay.DayOfWeek == DayOfWeek.Friday){
			startWeekDay = 4;
		} else if(currentDisplay.DayOfWeek == DayOfWeek.Saturday){
			startWeekDay = 5;
		} else if(currentDisplay.DayOfWeek == DayOfWeek.Sunday){
			startWeekDay = 6;
		}
		while (currentDisplay.Month == chosenMonth.Month)
		{
			//Debug.Log(currentDisplay.Day);
			
			DayLabels[currentDisplay.Day  + startWeekDay - 1].GetComponentInChildren<Text>().text = currentDisplay.Day.ToString();
			currentDisplay = currentDisplay.AddDays(1);
		}
	}


	public void nextMonth()
	{
		monthCounter++;
		if (monthCounter > 11)
		{
			monthCounter = 0;
			yearCounter++;
		}

		HeaderLabel.text = Months[monthCounter] + " " + (DateTime.Now.Year + yearCounter);
		calendarMonth.text = (monthCounter+1).ToString();
		calendarYear.text = (DateTime.Now.Year + yearCounter).ToString();
		clearLabels();
		chosenMonth = chosenMonth.AddMonths(1);
		CreateCalendar();
	}
		
	public void previousMonth()
	{
		monthCounter--;
		if (monthCounter < 0)
		{
			monthCounter = 11;
			yearCounter--;
		}

		HeaderLabel.text = Months[monthCounter] + " " + (DateTime.Now.Year + yearCounter);
		calendarMonth.text = (monthCounter+1).ToString();
		calendarYear.text = (DateTime.Now.Year + yearCounter).ToString();
		clearLabels();
		chosenMonth = chosenMonth.AddMonths(-1);
		CreateCalendar();
	}
	void showCalendarPopUp(){
		showCalendar = !showCalendar;
		Calendar.SetActive (showCalendar);
	}	
	void clearLabels()
	{
		for (int x = 0; x < DayLabels.Length; x++)
		{
			DayLabels[x].GetComponentInChildren<Text>().text = null;
		}
	}

	void setPosition(){
		calendarPosition = calendarButton.transform.position; //- new Vector3(calendarButton.transform.lossyScale.x,rt.rect.height,0);
		Calendar.transform.position = calendarPosition;
	}



}
