using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour {

    public void selectLevel() {
        switch (this.gameObject.name) {
            case "Level1Button":
                SceneManager.LoadScene("Level1");
                break;
            case "Level2Button":
                SceneManager.LoadScene("Level2");
                break;

        }


      



    }
}
