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
    private string gameDataFileName = "data.json";

    public void Start()
    {
      //  DontDestroyOnLoad(gameObject);
		SceneManager.LoadScene("Helpful_questions");
	//	LoadFromFile();
       //questions.SetActive(false);
       // QuestionPanel.SetActive(true);

          
    }

    public Quiz GetCurrentLevel()
    {
		return allLevels[0];
    }


    void Update()
    {

    }

    private void LoadFromFile() {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);

			allLevels = loadedData.allLevels;
        }
        else
        {
            Debug.LogError("nie można załadować danych z pliku");
        }
    }
}
