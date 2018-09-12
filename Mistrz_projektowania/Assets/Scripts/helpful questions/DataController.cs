using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{

    public Quiz[] allRoundData;
    public GameObject QuestionPanel;
    public GameObject questions;

    public void Start()
    {
       // DontDestroyOnLoad(gameObject);
       questions.SetActive(false);
        QuestionPanel.SetActive(true);

        //  SceneManager.LoadScene("Helpful_questions");
    }

    public Quiz GetCurrentRoundData()
    {
        return allRoundData[0];
    }


    void Update()
    {

    }
}
