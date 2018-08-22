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
	public Image wrongInputMessage;
	private int tripID;
  
	public XMLDataLoader dataLoader;
	public List<Dictionary<string,string>> thisLevelTrip;

	private int[] dataOrder;

	void Awake(){
		Application.targetFrameRate = 300;
	}
	// Use this for initialization
	void Start () {
		StartCoroutine(fadeMessage(noPointsMessage, false, 0.0000001f));
		StartCoroutine(fadeMessage(wrongInputMessage, false, 0.0000001f));
		noPointsMessageDisplay = false;
		points = 20; /// trzeba połączyć to z pkt uzyskanymi z wypełnienia formularza przed grą
		tripID = 1; // trzeba pobierać ID z ankiety przed rozpoczeciem gry


		dataLoader = GetComponent<XMLDataLoader> ();      
		dataLoader.GetData(tripID, "Plan");
		thisLevelTrip = dataLoader.getCurrentTripData();
		//Debug.Log ((thisLevelTrip [1]) ["Nr"]);
		//Debug.Log ((thisLevelTrip [2]) ["NazwaZleceniodawcy"]);
		//Debug.Log ((thisLevelTrip [0]) ["Nr"]);
		dataOrder = drawTheOrder(7, 7);
		dataLoader.setDataSlots (dataOrder);

		showFPS (true);
    }
		

	// Update is called once per frame
	void Update () {
		string dataOrderString = "";
		for (int i = 0; i < dataOrder.Length; i++) {
			dataOrderString += dataOrder [i];
			dataOrderString += ", ";
		}
		Debug.Log (dataOrderString);
      
	}

	public void showFPS(bool show){
		GameObject fpsCounter = GameObject.Find ("FPScounterController");
		fpsCounter.SetActive (show);
	}

	public int[] getDataOrder(){
		return dataOrder;
	}

	public void changePoints(int value){
		points += value;
		//Debug.Log (points);
		if (points <= 0) {
			points = 0;
			if (noPointsMessageDisplay == false) {
				StartCoroutine (fadeMessage (noPointsMessage, true, 0.5f));
				noPointsMessageDisplay = true;
				//StartCoroutine (closePointsMessage(10f));
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
			message.transform.position = new Vector3 (Screen.width / 2, 120,0.0f);
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

	public static int[] drawTheOrder(int n,int k)
	{
		int[] order = new int[k];
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
			//Debug.Log(numbers[r]);
			order [i] = numbers [r] - 1;

			// przeniesienie ostatniego elementu do miejsca z którego wzięliśmy
			numbers[r] = numbers[n - 1];
			n--;
		}
		return order;
	}
}
