using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameScore {
	public string playerName;
	public int playerScore;
	public int gamePlayTime;
	public string realGamePlayTime;

	public GameScore (string playerName, int playerScore, int gamePlayTime, string realGamePlayTime) {
		this.playerName = playerName;
		this.playerScore = playerScore;
		this.gamePlayTime = gamePlayTime;
		this.realGamePlayTime = realGamePlayTime;
	}

	public string Row() {
		return playerName + "-" + playerScore + "-" + gamePlayTime + "-" + realGamePlayTime;
	}
}

public class Scoreboard : MonoBehaviour {

	public Text name;
	public Text time;
	public Text timeAsNumber;
	public GameObject scoreRow;
	public GameObject scoreObjectParent;
	public Text textName, textScore, textTime, realTextTime;
	public Text gamePlayScore;
	public int scoresNumber = 50;
	static Scoreboard scoreboard;
	string playerTime;
	string playerTimeAsNumber;
	static string divider = "-";

	// Use this for initialization
	public void Start () {
		name.text = GameplayModel.gamePlayerName;
		scoreboard = this;
		playerTime = GameObject.Find ("timerText").GetComponent<timeCounter> ().getTimerValue ();
		playerTimeAsNumber = GameObject.Find ("timerText").GetComponent<timeCounter> ().getTimerValueAsANumber ();
		time.text = playerTime.ToString();
		timeAsNumber.text = playerTimeAsNumber.ToString();
		print (playerTimeAsNumber);
	}
		

	public void ShowScoreOnScoreboard(){
		StartCoroutine (addScoreToScoreboard ());
	}

	IEnumerator addScoreToScoreboard() {
		while (scoreObjectParent.transform.childCount > 0) {
			Destroy (scoreObjectParent.transform.GetChild (0).gameObject);
			yield return null;
		}

		List<GameScore> playerScore = LoadScoreboard ();

		foreach (GameScore score in playerScore) {
			textName.text = score.playerName;
			textScore.text = score.playerScore.ToString();
			textTime.text = score.gamePlayTime.ToString();
			realTextTime.text = score.realGamePlayTime;

			GameObject templateRow = Instantiate (scoreRow);
			templateRow.SetActive (true);

			templateRow.transform.SetParent (scoreObjectParent.transform);
			print (textTime.text);
		}
	}

	public void ConfirmPlayerData() {
		AddScore (name.text, int.Parse (gamePlayScore.text), int.Parse (timeAsNumber.text), time.text);
	}


	public static void AddScore(string name, int score, int time, string realtime) {
		List<GameScore> gameScores = new List<GameScore>();

		for (int i = 0; i < scoreboard.scoresNumber; i++) {
			if (PlayerPrefs.HasKey("wynik" + i)) {
				string[] scoreFormat =  PlayerPrefs.GetString("wynik" + i).Split(new string[] {divider}, System.StringSplitOptions.RemoveEmptyEntries);
				gameScores.Add(new GameScore(scoreFormat[0], int.Parse(scoreFormat[1]), int.Parse(scoreFormat[2]), scoreFormat [3]));
			} else 
				{
					break;
				}
		}

		if (gameScores.Count <  1){
			PlayerPrefs.SetString("wynik0", name + divider + score + divider + time  + divider + realtime);
			return;
		}

		gameScores.Add (new GameScore (name, score, time, realtime));
		gameScores = gameScores.OrderByDescending (o => o.playerScore).ThenBy(o => o.gamePlayTime).ToList ();
	
		for (int i = 0; i < scoreboard.scoresNumber; i++) {
			if (i >=  gameScores.Count) {
				break;
			}
			PlayerPrefs.SetString("wynik" + i, gameScores[i].Row());

		}
	}

	public List<GameScore> LoadScoreboard() {
		
		List<GameScore> gameScores = new List<GameScore> ();
		for (int i = 0; i < scoreboard.scoresNumber; i++) {
			if (PlayerPrefs.HasKey ("wynik" + i)) {
				string[] scoreFormat = PlayerPrefs.GetString ("wynik" + i).Split (new string[] { divider }, System.StringSplitOptions.RemoveEmptyEntries);
				gameScores.Add (new GameScore (scoreFormat [0], int.Parse (scoreFormat [1]), int.Parse (scoreFormat [2]), scoreFormat [3]));
			} else {
				break;
			}
;
		}

		return gameScores;
	}



	// Update is called once per frame
	void Update () {
		 
		 

	}

				 
}
