using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PlayerScore {
	public string playerName;
	public int playerScore;

	public PlayerScore (string playerName, int playerScore) {
		this.playerName = playerName;
		this.playerScore = playerScore;
	}

	public string GetFormat() {
		return playerName + "~S~" + playerScore;
	}
}

public class Scoreboard : MonoBehaviour {

	public InputField inputPlayerName;
	public Text name;
	public Text time;
	public Text inputPlayerScore;
	public int scoresNumber = 10;
	static Scoreboard scoreboard;
	static string separator = "~S~";

	// Use this for initialization
	void Start () {
		scoreboard = this;

		name.text = GameplayModel.gamePlayerName;
		time.text = GameObject.Find ("timerText").GetComponent<timeCounter> ().getTimerValue ();
	}



	public void SaveScore() {
		SaveScore (name.text, int.Parse (inputPlayerScore.text));
	}

	public static void SaveScore(string name, int score) {
		List<PlayerScore> playerScores = new List<PlayerScore>();

		for (int i = 0; i < scoreboard.scoresNumber; i++) {
			if (PlayerPrefs.HasKey("wynik" + i)) {
				string[] scoreFormat =  PlayerPrefs.GetString("wynik" + i).Split(new string[] {separator}, System.StringSplitOptions.RemoveEmptyEntries);
				playerScores.Add(new PlayerScore(scoreFormat[0], int.Parse(scoreFormat[1])));
			} else 
				{
					break;
				}
		}

		if (playerScores.Count <  1){
			PlayerPrefs.SetString("wynik1", name + separator + score);
			print("check");
			return;
		}

		playerScores.Add (new PlayerScore (name, score));
		playerScores = playerScores.OrderByDescending (o => o.playerScore).ToList ();
	
		for (int i = 0; i < scoreboard.scoresNumber; i++) {
			if (i >  playerScores.Count) {
				break;
			}
			PlayerPrefs.SetString("wynik" + i, playerScores[i].GetFormat());

		}
	}

	public List<PlayerScore> GetScore() {
		
		List<PlayerScore> playerScores = new List<PlayerScore> ();
		for (int i = 0; i < scoreboard.scoresNumber; i++) {
			if (PlayerPrefs.HasKey ("wynik" + i)) {
				string[] scoreFormat = PlayerPrefs.GetString ("wynik" + i).Split (new string[] { separator }, System.StringSplitOptions.RemoveEmptyEntries);
				playerScores.Add (new PlayerScore (scoreFormat [0], int.Parse (scoreFormat [1])));
			} else {
				break;
			}
;
		}

		return playerScores;
	}



	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.S)) {
			SaveScore ("aaa", 100);
			SaveScore ("dfgdfg", 40);
			SaveScore ("awwwaa", 30);
			SaveScore ("44444", 20);
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			List<PlayerScore> playerScores = GetScore ();

			foreach (PlayerScore p in playerScores) {
				print (p.playerName + "      " + p.playerScore);
			}
		}

	}

				 
}
