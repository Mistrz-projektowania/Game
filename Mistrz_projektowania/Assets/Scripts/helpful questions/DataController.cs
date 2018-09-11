using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{

    public Quiz[] allRoundData;
    public GameObject QuestionPanel;


    void Start()
    {
        DontDestroyOnLoad(gameObject);

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
