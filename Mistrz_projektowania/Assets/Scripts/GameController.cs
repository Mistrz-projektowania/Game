using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private int points;
	public Image noPointsMessage;
	private bool noPointsMessageDisplay;

	// Use this for initialization
	void Start () {
		StartCoroutine(fadeMessage(noPointsMessage, false, 0.0000001f));
		noPointsMessageDisplay = false;
		points = 10;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void changePoints(int value){
		points += value;
		if (points <= 0) {
			points = 0;
			if (noPointsMessageDisplay == false) {
				StartCoroutine (fadeMessage (noPointsMessage, true, 0.5f));
				noPointsMessageDisplay = true;
				StartCoroutine (closePointsMessage(10f));
			}
		}
	}

	public int getPoints(){
		return points;
	}
	IEnumerator closePointsMessage(float seconds){
		yield return new WaitForSeconds (seconds);
		StartCoroutine (fadeMessage (noPointsMessage, false, 0.5f));
		noPointsMessageDisplay = false;
	}
	IEnumerator fadeMessage(Image message, bool fadeIn, float duration){
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

		CanvasGroup selectedMessage = message.GetComponent<CanvasGroup>();

		while (counter < duration)
		{
			counter += Time.deltaTime;
			float alpha = Mathf.Lerp(a, b, counter / duration);
			//Debug.Log(alpha);

			selectedMessage.alpha = alpha;

			yield return null;
		}
	}
}
