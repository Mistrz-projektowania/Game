﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour {

    public void selectLevel() {
        switch (this.gameObject.name) {
		case "Level1Button":
				GameplayModel.gameLevel = 1;
				SceneManager.LoadScene("Select Character");
                break;
            case "Level2Button":
				GameplayModel.gameLevel = 2;
                SceneManager.LoadScene("Level2");
                break;

        }


      



    }
}
