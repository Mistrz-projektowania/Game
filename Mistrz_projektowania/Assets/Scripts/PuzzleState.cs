using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleState : MonoBehaviour {
	public GameObject PanelStart;

	public enum State {
		beforeStart,
		start,
		play,
		win,
	}

	public State state;
	public PuzzleState() {
		state = State.beforeStart;
	}


	public void StartGame() {
		//Destroy(PanelStart);
		PanelStart.SetActive(false);
		GameManager.puzzle_state.state = PuzzleState.State.start;
	}


}
