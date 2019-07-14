using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePictures : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject Puzzle;
	public GameObject PuzzleMenu;

	private void OnMouseDown() {
		GameManager.Catalog = gameObject.name;
		Puzzle.SetActive(true);

	}
}
