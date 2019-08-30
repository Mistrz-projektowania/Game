using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    
    public void Play()
    {
        SceneManager.LoadScene("Select Level");
    }

	public void GoToTutorial()
	{
		SceneManager.LoadScene("Tutorial");
	}

    public void Quit()
    {
        Application.Quit();
    }

    
}
