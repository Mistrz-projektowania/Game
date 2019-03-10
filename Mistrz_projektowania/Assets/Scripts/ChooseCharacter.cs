using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseCharacter : MonoBehaviour
{

    private int person;
    private GameObject[] characters;

    private void Start()
    {

        characters = new GameObject[transform.childCount];
		Debug.Log (characters.Length);
        person = PlayerPrefs.GetInt("Selected");
		Debug.Log (person);
        for (int i = 0; i < transform.childCount; i++)
            characters[i] = transform.GetChild(i).gameObject;

        foreach (GameObject all in characters)
            all.SetActive(false);
		
		if (characters [person])
			characters [person].SetActive (true);
		else {
			person = 0;
			characters [person].SetActive (true);
		}

    }

    public void ChooseNatalia()
    {
        characters[person].SetActive(false);
      	person = 1;
        characters[person].SetActive(true);
    }

    public void ChooseŁukasz()
    {
        characters[person].SetActive(false);
        person = 0;
        characters[person].SetActive(true);
    }


    public void SelectButton()
    {
        PlayerPrefs.SetInt("Selected", person);
        SceneManager.LoadScene("Level1");
    }
}
