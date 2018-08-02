using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{

    public Quiz[] allRoundData;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene("Helpful_questions");
    }

    public Quiz GetCurrentRoundData()
    {
        return allRoundData[0];
    }


    void Update()
    {

    }
}
