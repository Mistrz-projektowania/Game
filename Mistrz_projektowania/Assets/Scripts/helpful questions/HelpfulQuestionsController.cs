using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpfulQuestionsController : MonoBehaviour {
     
    public GameObject QuestionPanel;
	public GameObject questions;
    public void StartHelpfulQuestions() {
        QuestionPanel.SetActive(false);
		questions.SetActive (true);
    }
}
