using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Puzzle puzzlePrefab;
    private List<Puzzle> puzzleParts = new List<Puzzle>();
    //public Transform PuzzlePanel; 

    private Vector2 startPos = new Vector2(-5.55f, 2f);
    private Vector2 offset = new Vector2(2.6f, 1.8f);

    public LayerMask collisionMask;

    Ray ray_up, ray_down, ray_left, ray_right;
    RaycastHit hit;
    private BoxCollider collider;
    private Vector3 collider_size;
    private Vector3 collider_centre; //the center point of the collider form which we gonna fire the rays

    public string Catalog;
    public GameObject Picture;

    // Use this for initialization
    void Start()
    {
        PuzzleGame(15);
        StartPosition();
        ApplyMaterial();

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
            puzzleParts.Add(Instantiate(puzzlePrefab, new Vector3(0.0f, 0.0f, 0.0f), new Quaternion(0.0f, 0.0f, 190.0f, 0.0f)) as Puzzle);


        }
    }

    void StartPosition()
    {

        puzzleParts[0].transform.position = new Vector3(startPos.x, startPos.y, 0.0f);
        puzzleParts[1].transform.position = new Vector3(startPos.x + offset.x, startPos.y, 0.0f);
        puzzleParts[2].transform.position = new Vector3(startPos.x + (2* offset.x), startPos.y, 0.0f);

        puzzleParts[3].transform.position = new Vector3(startPos.x, startPos.y - offset.y, 0.0f);
        puzzleParts[4].transform.position = new Vector3(startPos.x + offset.x, startPos.y - offset.y, 0.0f);
        puzzleParts[5].transform.position = new Vector3(startPos.x + (2 * offset.x), startPos.y - offset.y, 0.0f);
		puzzleParts[6].transform.position = new Vector3(startPos.x + (3 * offset.x), startPos.y - offset.y, 0.0f);

        puzzleParts[7].transform.position = new Vector3(startPos.x, startPos.y - (2 * offset.y), 0.0f);
        puzzleParts[8].transform.position = new Vector3(startPos.x + offset.x, startPos.y - (2 * offset.y), 0.0f);
        puzzleParts[9].transform.position = new Vector3(startPos.x + (2 * offset.x), startPos.y - (2 * offset.y), 0.0f);
		puzzleParts[10].transform.position = new Vector3(startPos.x + (3 * offset.x), startPos.y - (2 * offset.y), 0.0f);

		puzzleParts[11].transform.position = new Vector3(startPos.x, startPos.y - (3 * offset.y), 0.0f);
		puzzleParts[12].transform.position = new Vector3(startPos.x + offset.x, startPos.y - (3 * offset.y), 0.0f);
		puzzleParts[13].transform.position = new Vector3(startPos.x + (2 * offset.x), startPos.y - (3 * offset.y), 0.0f);
		puzzleParts[14].transform.position = new Vector3(startPos.x + (3 * offset.x), startPos.y - (3 * offset.y), 0.0f);
    }

    void MovePuzzle()
    {
        foreach (Puzzle puzzle in puzzleParts)
        {
            puzzle.move_amount = offset;

            if (puzzle.clicked)
            {
                collider = puzzle.GetComponent<BoxCollider>();
                collider_size = collider.size;
                collider_centre = collider.center;

                float move_amount = offset.x;
                float direction = Mathf.Sign(move_amount);

                float x = (puzzle.transform.position.x + collider_centre.x - collider_size.x / 2) + collider_size.x / 2;
				float y = (puzzle.transform.position.y + collider_centre.y - collider_size.y / 2) + collider_size.y / 2;
				float x_right = puzzle.transform.position.x + collider_centre.x + collider_size.x / 2 * direction;
				float x_left = puzzle.transform.position.x + collider_centre.x + collider_size.x / 2 * -direction;
                float y_up = puzzle.transform.position.y + collider_centre.y + collider_size.y / 2 * direction;
                float y_down = puzzle.transform.position.y + collider_centre.y + collider_size.y / 2 * -direction;

				ray_left = new Ray(new Vector2(x_left, y), new Vector2(-direction, 0f));
				ray_right = new Ray(new Vector2(x_right, y), new Vector2(direction, 0f));
                ray_up = new Ray(new Vector2(x, y_up), new Vector2(0f, direction));
                ray_down = new Ray(new Vector2(x, y_down), new Vector2(0f, -direction));

                Debug.DrawRay(ray_up.origin, ray_up.direction);
                Debug.DrawRay(ray_down.origin, ray_down.direction);
                Debug.DrawRay(ray_left.origin, ray_left.direction);
                Debug.DrawRay(ray_right.origin, ray_right.direction);

                if ((Physics.Raycast(ray_up, out hit, 1.0f, collisionMask) == false) && (puzzle.moved == false) && (puzzle.transform.position.y < startPos.y))
                {
                    Debug.Log("Move Up Allowed");
                    puzzle.go_up = true;
                }
				if ((Physics.Raycast(ray_down, out hit, 1.0f, collisionMask) == false) && (puzzle.moved == false) && (puzzle.transform.position.y > (startPos.y - 3 * offset.y)))
                {
                    Debug.Log("Move Down Allowed");
                    puzzle.go_down = true;
                }
				if ((Physics.Raycast(ray_left, out hit, 1.0f, collisionMask) == false) && (puzzle.moved == false) && (puzzle.transform.position.x > startPos.x))
                {
                    Debug.Log("Move Left Allowed");
                    puzzle.go_left = true;
                }
                if ((Physics.Raycast(ray_right, out hit, 1.0f, collisionMask) == false) && (puzzle.moved == false) && (puzzle.transform.position.x < (startPos.x + 3 * offset.x)))
                {
                    Debug.Log("Move Right Allowed");
                    puzzle.go_right = true;
                }


            }
        }
    }

    void ApplyMaterial() {
        string filePath;

        for (int i = 1; i <= puzzleParts.Count; i++) {
            if (i > 3)
                filePath = "Puzzles/" + Catalog + "/Part" + (i + 1);
            else
				filePath = "Puzzles/" + Catalog + "/Part" + i ;

            Texture2D mat = Resources.Load(filePath, typeof(Texture2D)) as Texture2D;
            puzzleParts[i - 1].GetComponent<Renderer>().material.mainTexture = mat;

        }
		filePath = "Puzzles/" + Catalog + "/picture";
        Texture2D mat1 = Resources.Load(filePath, typeof(Texture2D)) as Texture2D;
        Picture.GetComponent<Renderer>().material.mainTexture = mat1;

    }
}