using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{

    public Text textAnswer;
    private Answer answer;
    private GameControll gameControll;

    // Use this for initialization
    void Start()
    {
        gameControll = FindObjectOfType<GameControll>();
    }

    public void Setup(Answer data)
    {
        answer = data;
		textAnswer.text = answer.textAnswer;
    }


    public void HandleClick()
    {
		gameControll.AnswerButtonClicked(answer.correctAnswer);
    }
}