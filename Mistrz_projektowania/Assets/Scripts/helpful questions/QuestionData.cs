using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionData
{

    public string questionText;
    public int timeAddedForBadAnswer;
    public int pointsDeductedForBadAnswer;
    public AnswerData[] answers;
}
