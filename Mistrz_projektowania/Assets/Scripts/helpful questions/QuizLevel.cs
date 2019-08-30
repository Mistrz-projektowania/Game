using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuizLevel : MonoBehaviour {

	public string name;
	public int timeLimitInSeconds;
	public int pointsAddedForCorrectAnswer;
	public Question[] questions;

}
