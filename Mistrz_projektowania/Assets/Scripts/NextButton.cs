using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{

    public void Next()
    {
		GameplayModel.gameTripName = "Nazwa";
		print (GameplayModel.gameTripName);
        SceneManager.LoadScene("Select Character");
    }

    
}