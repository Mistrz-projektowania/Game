using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

	public GameObject Panel1;
	public GameObject Panel2;
	public GameObject Panel3;
	public GameObject Panel4;
	public GameObject Panel5;
	public GameObject Panel6;
	public GameObject Panel7;
	public GameObject Panel8;
	public GameObject Panel9;


	// Use this for initialization
	void Start () {
		Panel1.SetActive (true);
		Panel2.SetActive (false);
		Panel3.SetActive (false);
		Panel4.SetActive (false);
		Panel5.SetActive (false);
		Panel6.SetActive (false);
		Panel7.SetActive (false);
		Panel8.SetActive (false);
		Panel9.SetActive (false);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoTo2() {
		Panel1.SetActive (false);
		Panel2.SetActive (true);
		Panel3.SetActive (false);
		Panel4.SetActive (false);
		Panel5.SetActive (false);
		Panel6.SetActive (false);
		Panel7.SetActive (false);
		Panel8.SetActive (false);
		Panel9.SetActive (false);
	}

	public void GoTo3() {
		Panel1.SetActive (false);
		Panel2.SetActive (false);
		Panel3.SetActive (true);
		Panel4.SetActive (false);
		Panel5.SetActive (false);
		Panel6.SetActive (false);
		Panel7.SetActive (false);
		Panel8.SetActive (false);
		Panel9.SetActive (false);
	}

	public void GoTo4() {
		Panel1.SetActive (false);
		Panel2.SetActive (false);
		Panel3.SetActive (false);
		Panel4.SetActive (true);
		Panel5.SetActive (false);
		Panel6.SetActive (false);
		Panel7.SetActive (false);
		Panel8.SetActive (false);
		Panel9.SetActive (false);
	}

	public void GoTo5() {
		Panel1.SetActive (false);
		Panel2.SetActive (true);
		Panel3.SetActive (false);
		Panel4.SetActive (false);
		Panel5.SetActive (true);
		Panel6.SetActive (false);
		Panel7.SetActive (false);
		Panel8.SetActive (false);
		Panel9.SetActive (false);
	}

	public void GoTo6() {
		Panel1.SetActive (false);
		Panel2.SetActive (false);
		Panel3.SetActive (false);
		Panel4.SetActive (false);
		Panel5.SetActive (false);
		Panel6.SetActive (true);
		Panel7.SetActive (false);
		Panel8.SetActive (false);
		Panel9.SetActive (false);
	}

	public void GoTo7() {
		Panel1.SetActive (false);
		Panel2.SetActive (false);
		Panel3.SetActive (false);
		Panel4.SetActive (false);
		Panel5.SetActive (false);
		Panel6.SetActive (false);
		Panel7.SetActive (true);
		Panel8.SetActive (false);
		Panel9.SetActive (false);
	}

	public void GoTo8() {
		Panel1.SetActive (false);
		Panel2.SetActive (false);
		Panel3.SetActive (false);
		Panel4.SetActive (false);
		Panel5.SetActive (false);
		Panel6.SetActive (false);
		Panel7.SetActive (false);
		Panel8.SetActive (true);
		Panel9.SetActive (false);
	}

	public void GoTo9() {
		SceneManager.LoadScene ("Select Level");
	}
}
