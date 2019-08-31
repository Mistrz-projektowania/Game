using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour
{

    public Quiz[] allLevels;
    public GameObject QuestionPanel;
    public GameObject questions;
	private string fileWithData = "quiz_questions_and_answers.json";

    public void Start()
    {
      //  DontDestroyOnLoad(gameObject);
		//SceneManager.LoadScene("Helpful_questions");
		LoadFromFile();
       //questions.SetActive(false);
       // QuestionPanel.SetActive(true);

    }

	private void LoadFromFile() {
		string filePath = Path.Combine(Application.streamingAssetsPath, fileWithData);
		if (File.Exists(filePath))
		{
			string dataAsJson = File.ReadAllText(filePath);
			QuizData loadedData = JsonUtility.FromJson<QuizData>(dataAsJson);

			allLevels = loadedData.allLevels;
		}
		else
		{
			Debug.LogError("nie można załadować danych z pliku");
		}
	}

    public Quiz GetCurrentLevel()
    {
		return allLevels[0];
    }
}
