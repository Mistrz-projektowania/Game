using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour
{

    private Quiz[] allRoundData;
    public GameObject QuestionPanel;
    public GameObject questions;
    private string gameDataFileName = "data.json";

    public void Start()
    {
        // DontDestroyOnLoad(gameObject);
        LoadGameData();
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

    private void LoadGameData() {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);

            allRoundData = loadedData.allRoundData;
        }
        else
        {
            Debug.LogError("nie można załadować danych z pliku");
        }
    }
}
