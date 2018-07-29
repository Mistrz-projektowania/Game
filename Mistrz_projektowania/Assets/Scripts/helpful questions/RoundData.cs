using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoundData {

    public int number;
    public int timeAddedForBadAnswer;
    public int pointsDeductedForBadAnswer;
    public QuestionData[] questions;
}
