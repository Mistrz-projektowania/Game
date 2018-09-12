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
    public GameObject questionDisplay;
    public GameObject roundGoodEndDisplay;
    public GameObject roundBadEndDisplay;
    public GameObject RoundBadOverNoPointsPanel;
    public GameObject RoundBadOverNoQuestions;
    private DataController dataController;
    private Quiz currentRoundData;

    private QuestionData[] questionPool;
    public int number;
    private bool isRoundActive;
    private float addedTime;
    private int questionIndex;
    private int roundIndex;
    public Quiz[] allRoundData;
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
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        //timeCounter addTimeUI = new timeCounter();
        //  addedTime.secondsCount += QuestionData.timeAddedForBadAnswer;

        questionIndex = 0;
        number = 0;
        ShowQuestion();
        isRoundActive = true;
    }

    private void ShowQuestion()
    {
        RemoveAnswerButtons();


        QuestionData questionData = questionPool[questionIndex];
        questionDisplayText.text = questionData.questionText;

        for (int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);


            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
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

    public void AnswerButtonClicked(bool isCorrect)
    {
       

        if (!isCorrect)
        {   
            gameController.subtractPoints(2);

            if (questionPool.Length > questionIndex + 1)
            {
                roundBadEndDisplay.SetActive(true);
                questionIndex++;
                ShowQuestion();



            }
           else {
                RoundBadOverNoQuestions.SetActive(true);
            }
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
        gameController.subtractPoints(2);
        questionIndex++;
        ShowQuestion();

    }

    public void EndRound3()
    {
        isRoundActive = false;
        questionIndex++;
        roundBadEndDisplay.SetActive(true);
        gameController.subtractPoints(2);
         

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
