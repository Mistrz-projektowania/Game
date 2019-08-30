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

    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
	public GameObject AnswerPanel;
    public GameObject questionDisplay;
    public GameObject roundGoodEndDisplay;
    public GameObject roundBadEndDisplay;
    public GameObject RoundBadOverNoPointsPanel;
    public GameObject RoundBadOverNoQuestions;
    private DataController dataController;
    private Quiz currentRoundData;

    private Question[] questionPool;
    public int number;
    private bool isRoundActive;
    private float addedTime;
    private int questionIndex;
    private int roundIndex;
    public Quiz[] allLevels;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();
    public GameController gameController;
    

    void Start()
    {

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        



        //Losowanie (10, 10);

        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentLevel();
        questionPool = currentRoundData.questions;
        //timeCounter addTimeUI = new timeCounter();
        //  addedTime.secondsCount += Question.timeAddedForBadAnswer;

        questionIndex = 0;
        number = 0;
        ShowQuestion();
        isRoundActive = true;
    }

    private void ShowQuestion()
    {
         
		AnswerPanel.SetActive (true);

        Question question = questionPool[questionIndex];
        questionDisplayText.text = question.textQuestion;
		Debug.Log (question.answers.Length);
        for (int i = 0; i < question.answers.Length; i++)
        {
			
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);


            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(question.answers[i]);
        }
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool correctAnswer)
    {
		AnswerPanel.SetActive (false);
       

		if (!correctAnswer)
        {
            int i = questionIndex;
			int a = 0;
				roundBadEndDisplay.SetActive(true);
                gameController.subtractPoints(a);
            if (gameController.getPoints() < questionIndex)
            {
                RoundBadOverNoPointsPanel.SetActive(true);
            }

            if (questionPool.Length > questionIndex + 1)
            {
                roundBadEndDisplay.SetActive(true);
                questionIndex++;
                ShowQuestion();
               
            }
           else {
                RoundBadOverNoQuestions.SetActive(true);
                
			} a++;
        }
      
        else
        {

            questionIndex++;
            ShowQuestion();
            roundGoodEndDisplay.SetActive(true);
        }

    }
    public void EndRound2()
    {
        isRoundActive = true;
        roundBadEndDisplay.SetActive(true);
        
        questionIndex++;
        ShowQuestion();

    }

    public void EndRound3()
    {
        isRoundActive = false;
        questionIndex++;
        roundBadEndDisplay.SetActive(true);
       
         

    }

    public void EndRound()
    {
        isRoundActive = true;
        questionIndex++;

        roundGoodEndDisplay.SetActive(true);
     
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("questions");
    }


    // Update is called once per frame
    void Update()
    {

        if (isRoundActive)
        {
            //  timeCounter Time = new timeCounter();
            //   Time.UpdateTimerUI();
        }

    }



    public int getPoints()
    {
        return points;
    }


}
