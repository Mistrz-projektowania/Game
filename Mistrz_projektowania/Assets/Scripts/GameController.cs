using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

	private int points;
	public Canvas noPointMessagePanel;
	public Image noPointsMessage;
	private bool noPointsMessageDisplay;

  

	// Use this for initialization
	void Start () {
		StartCoroutine(fadeMessage(noPointsMessage, false, 0.0000001f));
		noPointsMessageDisplay = false;
		points = 4; /// trzeba połączyć to z pkt uzyskanymi z wypełnienia formularza przed grą

        //Losowanie (10, 10);

    }

    
  
  

   
   


	// Update is called once per frame
	void Update () {

      
	}

	public void changePoints(int value){
		points += value;
		Debug.Log (points);
		if (points < 0) {
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
			message.transform.position = new Vector3 (Screen.width / 2, Screen.height / 2,0.0f);
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
		if (fadeIn == false) {
			message.transform.position = new Vector3 (-message.GetComponent<RectTransform>().rect.width, message.GetComponent<RectTransform>().rect.height,0.0f);
		}
	}

	static void Losowanie(int n,int k)
	{
		// wypełnianie tablicy liczbami 1,2...n
		int[] numbers = new int[n];
		for (int i = 0; i < n; i++)
			numbers[i] = i + 1;
		// losowanie k liczb
		for (int i = 0; i < k; i++)
		{
			// tworzenie losowego indeksu pomiędzy 0 i n - 1
			int r = Random.Range(0, n);

			// wybieramy element z losowego miejsca
			Debug.Log(numbers[r]);

			// przeniesienia ostatniego elementu do miejsca z którego wzięliśmy
			numbers[r] = numbers[n - 1];
			n--;
		}
	}
}
