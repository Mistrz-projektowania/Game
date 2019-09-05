using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;


public class GameControll : MonoBehaviour
{

    private int points;


    //for helpful questions
    public Text questionDisplayText;

	public ObjectsPrefabsPool answerButtonsPool;
    public Transform answerButtonParent;
	public GameObject AnswerPanel;
    public GameObject questionDisplay;
    public GameObject roundGoodEndDisplay;
    public GameObject roundBadEndDisplay;
    public GameObject RoundBadOverNoPointsPanel;
    public GameObject RoundBadOverNoQuestions;
	private JsonLoader jsonLoader;
    private Quiz currentRoundData;

    private Question[] questionPool;
    public int number;
    private bool isRoundActive;
    private float addedTime;
    private int questionIndex;
    private int roundIndex;
    public Quiz[] allLevels;
    private List<GameObject> answerButtons = new List<GameObject>();
    public GameController gameController;
	public timeCounter timeCount; 
	public Button sunMopOn;

   public void Start()
    {
		StateMachine.setState (6); 
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        

		jsonLoader = FindObjectOfType<JsonLoader>();
		currentRoundData = jsonLoader.GetCurrentLevel();
        questionPool = currentRoundData.questions;
		timeCounter timeCount = new timeCounter();
        questionIndex = 0;
        number = 0;
        ShowQuestion();
        isRoundActive = true;
    }

    private void ShowQuestion()
    {
		RemoveAnswerButtons ();
		AnswerPanel.SetActive (true);

        Question question = questionPool[questionIndex];
        questionDisplayText.text = question.textQuestion;

        for (int i = 0; i < question.answers.Length; i++)
        {
			GameObject answerButtonGameObject = answerButtonsPool.GetObject();
            answerButtons.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(question.answers[i]);
        }
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtons.Count > 0)
        {
			answerButtonsPool.ReturnPrefabInstance(answerButtons[0]);
            answerButtons.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool correctAnswer)
    {
		AnswerPanel.SetActive (false);
       
		int pointsSubtract = questionIndex;
		int timeAddedForBadAnsw;
		if (!correctAnswer)
        {
            int i = questionIndex;

			int a = 1;
			if (questionIndex > 0) {
				timeAddedForBadAnsw = 10;
			} timeAddedForBadAnsw = 30;

				roundBadEndDisplay.SetActive(true);
				gameController.subtractPoints(pointsSubtract+1);
				timeCount.addTimeUI (timeAddedForBadAnsw);

            if (gameController.getPoints() < questionIndex)
            {
				pointsSubtract = 0;
				RoundBadOverNoPointsPanel.SetActive(true);
            }

            if (questionPool.Length > questionIndex )
            {
				i++;
                roundBadEndDisplay.SetActive(true);
                questionIndex++;
                ShowQuestion();
            }

			if (questionPool.Length == questionIndex + 1 ) {
				pointsSubtract = 0;
                RoundBadOverNoQuestions.SetActive(true);
                
			} a++;
        }
      
        else
		{
			pointsSubtract = 0;  
            questionIndex++;
            ShowQuestion();
            roundGoodEndDisplay.SetActive(true);
        }

    }

	public void SubtractTwoPoints() {
		gameController.subtractPoints(2);
	}
		
    // Update is called once per frame
    void Update()
    {
		
    }
		
    public int getPoints()
    {
        return points;
    }
}
