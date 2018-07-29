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
    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    public int number;
    private bool isRoundActive;
    private float addedTime;
    private int questionIndex;
    private int roundIndex;
    public RoundData[] allRoundData;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();
     
    void Start()
    {
       
        points = 4; /// trzeba połączyć to z pkt uzyskanymi z wypełnienia formularza przed grą

        //Losowanie (10, 10);

        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeCounter addedTime = new timeCounter();
        addedTime.secondsCount += currentRoundData.timeAddedForBadAnswer;

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

             
            // points += 3;
             points -= currentRoundData.pointsDeductedForBadAnswer;
           
            ShowQuestion();

        }

        
        else
        {
            EndRound();
        }
    }
   

    public void EndRound()
    {
        isRoundActive = false;

        questionDisplay.SetActive(false);
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
