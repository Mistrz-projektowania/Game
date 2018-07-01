using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockTextController : MonoBehaviour {

	public string myString;
	public Text myText;
	public float fadeTime;
	public bool displayInfo;
	public Button button;
	private GameController gameController;

	// Use this for initialization
	void Start () {

		//button = GameObject.Find ("RockButton").GetComponent<Button> ();
		//myText.color = Color.clear;
		//Screen.showCursor = false;
		//Screen.lockCursor = true;
		StartCoroutine(fadeButton(button, false, 0.0000001f));

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if(gameControllerObject != null){
			gameController = gameControllerObject.GetComponent<GameController>();	
		}

		if(gameControllerObject == null){
			Debug.Log ("Nie działa :<");
		}
	}

	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetKeyDown (KeyCode.Escape)) 
                {
                        Screen.lockCursor = false;
                }
          */      
	}

	void OnMouseDown() {
		if (gameController.getPoints () > 0) {
			displayInfo = !displayInfo;
			if (displayInfo) {
				gameController.changePoints (-2);

				//myText.text = myString;
				//myText.color = Color.Lerp (myText.color, Color.white, fadeTime * Time.deltaTime);
				StartCoroutine (fadeButton (button, true, fadeTime));
			} else {
				StartCoroutine (fadeButton (button, false, fadeTime));
				//myText.color = Color.Lerp (myText.color, Color.clear, fadeTime * Time.deltaTime);
			}
		} else {
			if (displayInfo) {
				StartCoroutine (fadeButton (button, false, fadeTime));
				displayInfo = false;
			}
		}

	}

	void OnMouseExit() {
		//displayInfo = false;
	}

	IEnumerator fadeButton(Button button, bool fadeIn, float duration){
		float counter = 0f;

		float a, b;
		if (fadeIn)
		{
			a = 0;
			b = 1;
		}
		else
		{
			a = 1;
			b = 0;
		}
			
		if (!button.enabled)
			button.enabled = true;

		CanvasGroup selectedButton = button.GetComponent<CanvasGroup>();

		while (counter < duration)
		{
			counter += Time.deltaTime;
			float alpha = Mathf.Lerp(a, b, counter / duration);
			//Debug.Log(alpha);

			selectedButton.alpha = alpha;

			yield return null;
		}

		if (!fadeIn)
		{
			button.enabled = false;
		}
	}
}
