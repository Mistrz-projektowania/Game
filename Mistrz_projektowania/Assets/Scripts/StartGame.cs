using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
	public void StartGameplay(){
		GameObject panel = GameObject.Find("Intro");
		panel.SetActive (false);
		StateMachine.setState (0);
	}
}
