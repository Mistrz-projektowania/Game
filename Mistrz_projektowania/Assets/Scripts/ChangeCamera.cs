using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject puzzleCamera;
    public GameObject leftGUI;
    public GameObject Game;
    public GameObject rockLabels;
    public GameObject noPointMessage;
    public GameObject wrongInputMEssage;


    public void ShowMainView()
    {
        mainCamera.SetActive(true);
        puzzleCamera.SetActive(false);
        leftGUI.SetActive(true);
        Game.SetActive(true);
        rockLabels.SetActive(true);
    }

    public void ShowPuzzleView()
    {
        leftGUI.SetActive(false);
        Game.SetActive(false);
        mainCamera.SetActive(false);
        rockLabels.SetActive(false);
        noPointMessage.SetActive(false);
        wrongInputMEssage.SetActive(false);
        puzzleCamera.SetActive(true);
    }
}

 
 

    

