using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpfulQuestionsController : MonoBehaviour {

    public void StartHelpfulQuestions() {
        SceneManager.LoadScene("questions");
    }
}
