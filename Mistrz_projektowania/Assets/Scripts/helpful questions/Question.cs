using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{

	public string textQuestion;
    public int timeAddedForBadAnswer;
    public int pointsDeductedForBadAnswer;
    public Answer[] answers;
}
