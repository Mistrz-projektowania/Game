using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public LayerMask collisionMask;
    public Puzzle puzzlePrefab;
    private List<Puzzle> puzzleParts = new List<Puzzle>();
    //public Transform PuzzlePanel; 

    private Vector2 startPos = new Vector2(-5.55f, 2.0f);
    private Vector2 offset = new Vector2(3f, 2.2f);
	private List<int> randomPositions = new List<int>();
	private List<Vector3> partsPosition = new List<Vector3>();



    Ray ray_up, ray_down, ray_left, ray_right;
    RaycastHit hit;
    private BoxCollider collider;
    private Vector3 collider_size;
    private Vector3 collider_centre; //the center point of the collider form which we gonna fire the rays

	public static string Catalog;
	public GameObject Picture;

    // Use this for initialization
    void Start()
    {
        PuzzleGame(8);
        StartPosition();
        ApplyPictures();
		EntryRandomPositions();

    }

    // Update is called once per frame
    void Update()
    {
        MovePuzzle();
    }

    private void PuzzleGame(int parts)
    {
        for (int i = 0; i < parts; i++)
        {
            puzzleParts.Add(Instantiate(puzzlePrefab, new Vector3(0.0f, 0.0f, 0.0f), new Quaternion(0.0f, 0.0f, 180.0f, 0.0f)) as Puzzle);
        }
    }

    void StartPosition()
    {
        puzzleParts[0].transform.position = new Vector3(startPos.x, startPos.y, 0.0f);
        puzzleParts[1].transform.position = new Vector3(startPos.x + offset.x, startPos.y, 0.0f);

        puzzleParts[2].transform.position = new Vector3(startPos.x, startPos.y - offset.y, 0.0f);
        puzzleParts[3].transform.position = new Vector3(startPos.x + offset.x, startPos.y - offset.y, 0.0f);
        puzzleParts[4].transform.position = new Vector3(startPos.x + (2 * offset.x), startPos.y - offset.y, 0.0f);

        puzzleParts[5].transform.position = new Vector3(startPos.x, startPos.y - (2 * offset.y), 0.0f);
        puzzleParts[6].transform.position = new Vector3(startPos.x + offset.x, startPos.y - (2 * offset.y), 0.0f);
        puzzleParts[7].transform.position = new Vector3(startPos.x + (2 * offset.x), startPos.y - (2 * offset.y), 0.0f);
    }

    void MovePuzzle()
    {
        foreach (Puzzle puzzle in puzzleParts)
        {
            puzzle.move_amount = offset;

            if (puzzle.clicked)
            {
                collider = puzzle.GetComponent<BoxCollider>(); 

				float direction = Mathf.Sign(offset.x);
                float x = (puzzle.transform.position.x + collider.center.x - collider.size.x / 2) + collider.size.x / 2;
				float y = (puzzle.transform.position.y + collider.center.y - collider.size.y / 2) + collider.size.y / 2;
				float x_right = puzzle.transform.position.x + collider.center.x + collider.size.x / 2 * direction;
				float x_left = puzzle.transform.position.x + collider.center.x + collider.size.x / 2 * -direction;
                float y_up = puzzle.transform.position.y + collider.center.y + collider.size.y / 2 * direction;
                float y_down = puzzle.transform.position.y + collider.center.y + collider.size.y / 2 * -direction;

				ray_left = new Ray(new Vector2(x_left, y), new Vector2(-direction, 0f));
				ray_right = new Ray(new Vector2(x_right, y), new Vector2(direction, 0f));
                ray_up = new Ray(new Vector2(x, y_up), new Vector2(0f, direction));
                ray_down = new Ray(new Vector2(x, y_down), new Vector2(0f, -direction));

				float maxDistanceToCheck = 2.0f;

				if ((puzzle.transform.position.y < startPos.y) && (Physics.Raycast(ray_up, out hit, maxDistanceToCheck, collisionMask) == false) )
                {
                    puzzle.go_up = true;
                }
				if ((puzzle.transform.position.y > (startPos.y -2 * offset.y)) && (Physics.Raycast(ray_down, out hit, maxDistanceToCheck, collisionMask) == false))
                {
                    puzzle.go_down = true;
                }
				if ((puzzle.transform.position.x > startPos.x) && (Physics.Raycast(ray_left, out hit, maxDistanceToCheck, collisionMask) == false))
                {
                    puzzle.go_left = true;
                }
				if ((puzzle.transform.position.x < (startPos.x +2 * offset.x)) && (Physics.Raycast(ray_right, out hit, maxDistanceToCheck, collisionMask) == false))
                {
                    puzzle.go_right = true;
                }
            }
        }
    }

	void EntryRandomPositions () {
		int randomPart;

		foreach (Puzzle p in puzzleParts) {
			partsPosition.Add (p.transform.position);
		}

		foreach (Puzzle p in puzzleParts) {
			randomPart = Random.Range (0, puzzleParts.Count);

			while (randomPositions.Contains (randomPart)) {
				randomPart = Random.Range (0, puzzleParts.Count);
			}
			randomPositions.Add (randomPart);
			p.transform.position = partsPosition [randomPart];

		}

	}

   public void ApplyPictures() {
        string filePath;

        for (int i = 1; i <= puzzleParts.Count; i++) {
            if (i > 3)
                filePath = "Puzzles/" + Catalog + "/Part" + (i + 1);
            else
				filePath = "Puzzles/" + Catalog + "/Part" + i;

            Texture2D mat = Resources.Load(filePath, typeof(Texture2D)) as Texture2D;
            puzzleParts[i - 1].GetComponent<Renderer>().material.mainTexture = mat;

        }
		filePath = "Puzzles/" + Catalog + "/picture";
        Texture2D mat1 = Resources.Load(filePath, typeof(Texture2D)) as Texture2D;
        Picture.GetComponent<Renderer>().material.mainTexture = mat1;

    }
}