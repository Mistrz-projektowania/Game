using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WitchController : MonoBehaviour {

	private Image systemInfo;
	private Vector3 startPos;
	private Vector3 destinationPos;
	private Quaternion rotation;
	private Quaternion nextRotation;

	float speed = 2;
	float rotateSpeed = 1.0f;
	float xScale = 0.1f;
	float yScale = 0.1f;

	float animationTime;
	bool keyWPressed;
	float lastKeyWPressedTime;
	int swapNr;

	float t;
	float timeToReachDestination;
	int flyingTime = 3;

	setRockRandomPlaces rockController;
	GameController gameController;
	ParticleSystem ps;
	AudioSource sound;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		systemInfo = gameController.systemInfo;
		rockController = GameObject.Find("Rocks").GetComponent<setRockRandomPlaces>();
		swapNr = 3;
		animationTime = 2.0f;
		lastKeyWPressedTime = Time.time - animationTime * swapNr;
		startPos = destinationPos = transform.position;
		rotation = nextRotation = transform.rotation;
		ps = GameObject.Find ("WitchSpell").GetComponent<ParticleSystem> ();
		ps.Stop ();
		sound = GameObject.Find ("witchSound").GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		fly ();
		//Debug.Log (transform.position);
	}

	public void runWitch(){
		StateMachine.witchRunning = true;
		if (Time.time - lastKeyWPressedTime > animationTime * swapNr + 4 * flyingTime) {
			
			sound.Play ();
			// info message
			systemInfo.GetComponentInChildren<Text>().text = "Czarownica";
			StartCoroutine (gameController.fadeMessage (systemInfo, true, 0.5f));
			// witch animation
			setDestination(new Vector3(52.0f, 1.5f, 12.0f), new Vector3(15,150,0), flyingTime); // czarownica leci do przodu
			StartCoroutine (waitForAndStartSwapingRocks (flyingTime));

			lastKeyWPressedTime = Time.time;
		}
	}

	IEnumerator waitForAndStartSwapingRocks(float seconds){
		yield return new WaitForSeconds (seconds);
		setDestination(new Vector3(52.0f, 1.5f, 12.0f), new Vector3(0,180,0), flyingTime);
		yield return new WaitForSeconds (flyingTime - 1);
		ps.Play (); // włączenie "czarowania"
		yield return new WaitForSeconds (1);
		swapRocksFewTimes (swapNr); // mieszanie kamieni
		yield return new WaitForSeconds (animationTime * swapNr);
		ps.Stop ();
		setDestination(new Vector3(50.0f, 1.2f, 14.0f), new Vector3(0,-20,-30), flyingTime);// czarownica leci do tyłu
		yield return new WaitForSeconds (flyingTime);
		setDestination(new Vector3(51.0f, 1.8f, 16.0f), new Vector3(0,100,0), flyingTime);// czarownica leci do tyłu
		StartCoroutine (AudioFadeOut(sound, 2));
		StartCoroutine (gameController.fadeMessage (systemInfo, false, 0.5f));
		StateMachine.setState (0);
	}
	void swapRocksFewTimes(int times){
		for (int i = 0; i < times; i++) {
			int[] randomIndexes = GameController.drawTheOrder (7, 2);

			StartCoroutine (waitAndSwap (i*animationTime, randomIndexes[0],randomIndexes[1],animationTime));	
		}
	}
	IEnumerator waitAndSwap(float seconds, int index1, int index2, float animationTime){
		yield return new WaitForSeconds (seconds);
		rockController.swapRocks (index1,index2,animationTime);
	}

	void fly(){
		t += Time.deltaTime / timeToReachDestination;
		transform.localRotation = Quaternion.Slerp(rotation, nextRotation, t * rotateSpeed);

		transform.position = Vector3.Lerp (startPos, destinationPos + (Vector3.right * Mathf.Sin (Time.timeSinceLevelLoad / 2 * speed) * xScale - Vector3.up * Mathf.Sin (Time.timeSinceLevelLoad * speed) * yScale), t);
		if (transform.position == destinationPos) {
			//transform.Rotate (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad/2*speed)*xScale - Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * speed)*yScale);
			transform.position = startPos + (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad/2*speed)*xScale - Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * speed)*yScale);
		}
	}

	public void setDestination(Vector3 destination, Vector3 rot, float time){
		t = 0;
		startPos = transform.position;
		timeToReachDestination = time;
		destinationPos = destination;
		//Debug.Log ("startPos: " + startPos);
		//Debug.Log ("destinationPos: " + destinationPos);

		rotation = transform.localRotation;
		nextRotation = Quaternion.Euler(rot.x,rot.y,rot.z);
	}

	public static IEnumerator AudioFadeOut(AudioSource audioSource, float FadeTime)
	{
		float startVolume = audioSource.volume;

		while (audioSource.volume > 0)
		{
			audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

			yield return null;
		}

		audioSource.Stop();
		audioSource.volume = startVolume;
	}
}
