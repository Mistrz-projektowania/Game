using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockTextController : MonoBehaviour {

	public string myString;
	public Text myText;
	public float fadeTime;
	public bool displayInfo;
	public bool infoUsed;
	public GameObject buttonOb;
	public Button button;
	public GameObject[] otherButtons;
	private GameObject[] allButtons;
	private GameController gameController;

	// Use this for initialization
	void Start () {
		infoUsed = false;
		allButtons = GameObject.FindGameObjectsWithTag ("rockInfo");
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
			//displayInfo = !displayInfo;

			if (displayInfo == false) {
				AudioSource sound = GameObject.Find ("onClickSound").GetComponent<AudioSource> ();
				sound.Play ();
				StartCoroutine (fadeButton (button, true, fadeTime));
				displayInfo = true;
				gameController.changePoints (-2);

				for (int i = 0; i < otherButtons.Length; i++) {
					StartCoroutine(fadeButton(otherButtons [i].GetComponent<Button> (), false, 1.0f));
				}
			} else {
				// StartCoroutine (fadeButton (button, false, fadeTime));
				//myText.color = Color.Lerp (myText.color, Color.clear, fadeTime * Time.deltaTime);
			}
		} else {
			if (displayInfo) {
				//StartCoroutine (fadeButton (button, false, fadeTime));
				//displayInfo = false;
			}
		}

	}

	void OnMouseExit() {
		
	}

	IEnumerator fadeButton(Button button, bool fadeIn, float duration){
		//Debug.Log (button.enabled);
		float counter = 0f;

		float a, b;
		if (fadeIn)
		{
			button.enabled = true;
			buttonOb.AddComponent<DragHandler> ();
			a = 0;
			b = 1;
			displayInfo = true;
		}
		else
		{
			displayInfo = false;
			button.enabled = false;
			Destroy (button.GetComponent<DragHandler> ());
			a = 1;
			b = 0;
		}

		if (button.GetComponent<CanvasGroup> () != null) {
			CanvasGroup selectedButton = button.GetComponent<CanvasGroup> ();

			while (counter < duration) {
				if (selectedButton.alpha == 0 && fadeIn == false) {
					break;
				}
				counter += Time.deltaTime;
				float alpha = Mathf.Lerp (a, b, counter / duration);
				//Debug.Log(alpha);

				selectedButton.alpha = alpha;

				yield return null;
			}
		}
	}
}
