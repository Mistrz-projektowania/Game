using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoundData : MonoBehaviour {

	public string name;
	public int timeLimitInSeconds;
	public int pointsAddedForCorrectAnswer;
	public QuestionData[] questions;

}
