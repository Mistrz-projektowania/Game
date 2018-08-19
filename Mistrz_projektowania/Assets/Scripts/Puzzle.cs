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
    public bool moved = false; //prevent  moving the puzel more than one
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MovePuzzle();

    }

    private void OnMouseDown() //preimplemented by unity
    {
        clicked = true;
    }
    private void OnMouseUp()
    {
        clicked = false;
    }

    void MovePuzzle()
    {
        if (go_left == true)
        {
            transform.position = new Vector3(transform.position.x - move_amount.x, transform.position.y, transform.position.z);
            go_left = false;
            moved = true;
        }
        if (go_right == true)
        {
            transform.position = new Vector3(transform.position.x + move_amount.x, transform.position.y, transform.position.z);
            go_right = false;
            moved = true;
        }
        if (go_up == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + move_amount.y, transform.position.z);
            go_up = false;
            moved = true;
        }
        if (go_down == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - move_amount.y, transform.position.z);
            go_down = false;
            moved = true;
        }
    }
}
