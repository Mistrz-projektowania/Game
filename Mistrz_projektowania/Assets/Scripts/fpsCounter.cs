using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsCounter : MonoBehaviour {

	float deltaTime = 0.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;	
	}
	void OnGUI(){
		float msec = deltaTime * 1000.0f;
		float FPS = Mathf.Floor(1.0f / deltaTime);

		createCounter (FPS, msec);
	}

	void createCounter(float fps, float msec){
		int w = Screen.width, h = Screen.height;

		GUIStyle style = new GUIStyle();
		Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 100;
		style.normal.textColor = new Color (1.0f, 0.0f, 0.0f, 1.0f);
		string text = string.Format("{1:0.} fps ({0:0.0} ms)", msec, fps);
		GUI.Label(rect, text, style);
	}
}
