using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseCharacter : MonoBehaviour
{
    private int person;
    private GameObject[] characters;
	private GameObject[] buttons;
	public Text nameText;

    private void Start()
    {
        characters = new GameObject[transform.childCount];
		if(SceneManager.GetActiveScene ().name == "Select Character") initializeButtons ();
		initializeCharacters ();
    }

	private void initializeButtons(){
		buttons = new GameObject[4];
		buttons[0] = GameObject.Find("Button-Łukasz");
		buttons[1] = GameObject.Find("Button-Natalia");
		buttons[2] = GameObject.Find("Button-Urszula");
		buttons[3] = GameObject.Find("Button-Andrzej");
		foreach (GameObject btn in buttons) btn.SetActive(false);
		if (GameplayModel.gameLevel == 1) {
			buttons [0].SetActive (true);
			buttons [1].SetActive (true);
		} else {
			buttons [2].SetActive (true);
			buttons [3].SetActive (true);
		}
	}
	private void initializeCharacters(){
		if (GameplayModel.gameLevel == 1) 
			person = PlayerPrefs.GetInt("Selected_1");
		else
			person = PlayerPrefs.GetInt("Selected_2");
		for (int i = 0; i < transform.childCount; i++)
			characters[i] = transform.GetChild(i).gameObject;

		foreach (GameObject all in characters)
			all.SetActive(false);

		if (characters [person])
			characters [person].SetActive (true);
		else {
			if (GameplayModel.gameLevel == 1) {
				person = 0;
			} else {
				person = 2;
			}
			characters [person].SetActive (true);
		}
		setName (person);
	}

	private void setName(int id){
		if (nameText != null) {
			switch (id) {
			case 0:
				nameText.text = "Łukasz";
				break;
			case 1:
				nameText.text = "Natalia";
				break;
			case 2:
				nameText.text = "Urszula";
				break;
			case 3:
				nameText.text = "Andrzej";
				break;
			}
		}
	}
		
    public void ChooseŁukasz()
    {
        characters[person].SetActive(false);
        person = 0;
        characters[person].SetActive(true);
		setName (person);
    }

	public void ChooseNatalia()
	{
		characters[person].SetActive(false);
		person = 1;
		characters[person].SetActive(true);
		setName (person);
	}
		
	public void ChooseUrszula()
	{
		characters[person].SetActive(false);
		person = 2;
		characters[person].SetActive(true);
		setName (person);
	}


	public void ChooseAndrzej()
	{
		characters[person].SetActive(false);
		person = 3;
		characters[person].SetActive(true);
		setName (person);
	}

    public void SelectButton()
    {
		if (GameplayModel.gameLevel == 1)
			PlayerPrefs.SetInt ("Selected_1", person);
		 else
			PlayerPrefs.SetInt ("Selected_2", person);
		if(getPlayerName() != "") 
			GameplayModel.gamePlayerName = getPlayerName ();
		SceneManager.LoadScene("Entry_questions_Level1");
    }

	private string getPlayerName(){
		InputField playerName = GameObject.Find ("PlayerNameInput").GetComponent<InputField>();
		return playerName.text.ToString();
	}
}
