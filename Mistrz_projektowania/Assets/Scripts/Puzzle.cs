using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {

    [HideInInspector]
    public bool clicked = false;

    [HideInInspector]
    public bool go_left;
    [HideInInspector]
    public bool go_right;
    [HideInInspector]
    public bool go_up;
    [HideInInspector]
    public bool go_down;
    [HideInInspector]
    public Vector2 move_amount;

    [HideInInspector] 
	public Vector3 completedPos;
    // Use this for initialization

    void Start () {
		completedPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        MovePuzzle();

    }

	private void OnMouseUp()
	{
		clicked = false;
	}

    private void OnMouseDown() //preimplemented by unity
    {
        clicked = true;
    }
   

    void MovePuzzle()
    {
        if (go_left == true)
        {
            transform.position = new Vector3(transform.position.x - 3.0f, transform.position.y, transform.position.z);
            go_left = false; 
        }
        if (go_right == true)
        {
			transform.position = new Vector3(transform.position.x + 3.0f, transform.position.y, transform.position.z);
            go_right = false; 
        }
        if (go_up == true)
        {
			transform.position = new Vector3(transform.position.x, transform.position.y + 2.2f, transform.position.z);
            go_up = false; 
        }
        if (go_down == true)
        {
			transform.position = new Vector3(transform.position.x, transform.position.y - 2.2f, transform.position.z);
            go_down = false; 
        }
    }
}
