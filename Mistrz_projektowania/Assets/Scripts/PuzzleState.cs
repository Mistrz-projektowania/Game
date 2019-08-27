using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleState : MonoBehaviour {
	public GameObject PanelStart; 
	public GameObject Flashcard;

	public enum State {
		beforeStart,
		start,
		play,
		win,
		afterWin,
	}



	public State state;
	public PuzzleState() {
		state = State.beforeStart;
	}


	public void StartGame() {
		//Destroy(PanelStart);
		GameManager.puzzle_state.state = PuzzleState.State.start;
		PanelStart.SetActive(false);
		Flashcard.SetActive (false);

	}


}
