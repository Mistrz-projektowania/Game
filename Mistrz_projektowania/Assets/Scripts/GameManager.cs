using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Puzzle puzzlePrefab;
    private List<Puzzle> puzzleParts = new List<Puzzle>();
    public Transform PuzzlePanel;
   
    private Vector2 position = new Vector2(80f,240f);
    private Vector2 space = new Vector2(2f, 1.42f);

    
    // Use this for initialization
	void Start () {
        PuzzleGame(8);
        StartPosition();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void PuzzleGame(int parts)
    {
        for (int i = 0; i < parts; i++)
        {
            puzzleParts.Add(Instantiate(puzzlePrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, PuzzlePanel) );
            

        }
    }

    void StartPosition()
    {

        puzzleParts[0].transform.position = new Vector3(position.x, position.y, 0.0f);
        puzzleParts[1].transform.position = new Vector3(162 + space.x, position.y, 0.0f);
      //  puzzleParts[2].transform.position = new Vector3(position.x + (2* offset.x), position.y, 0.0f);

        puzzleParts[2].transform.position = new Vector3(position.x, 183 - space.y, 0.0f);
        puzzleParts[3].transform.position = new Vector3(162 + space.x, 183 - space.y, 0.0f);
        puzzleParts[4].transform.position = new Vector3(244 + (2*space.x), 183 - space.y, 0.0f);

        puzzleParts[5].transform.position = new Vector3(position.x, 126 - (2 * space.y), 0.0f);
       puzzleParts[6].transform.position = new Vector3(162 + space.x, 126 - (2 * space.y), 0.0f);
        puzzleParts[7].transform.position = new Vector3(244 + (2 * space.x), 126 - (2 * space.y), 0.0f);
    }
}
