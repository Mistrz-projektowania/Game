using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{

    public Text answerText;

    private AnswerData answerData;
    private GameControll gameControll;

    // Use this for initialization
    void Start()
    {
        gameControll = FindObjectOfType<GameControll>();
    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }


    public void HandleClick()
    {
        gameControll.AnswerButtonClicked(answerData.isCorrect);
    }
}