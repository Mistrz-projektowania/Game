using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Slot : MonoBehaviour , IDropHandler
{
	public GameObject item
	{
		get {
			if (transform.childCount > 0) {
				return transform.GetChild(0).gameObject;
			} 

			return null;
		}
	}

	#region IdropHandler implementation
	public void OnDrop(PointerEventData eventData)
	{
		
		GameObject parentObject = this.transform.parent.gameObject;
		string inputDropped = parentObject.GetComponentInChildren<Text> ().text;
		//Debug.Log ("Input dropped = " + inputDropped);
		if (!item) {
			//GameObject parentObject = this.transform.parent.gameObject;
			Text textObject = parentObject.GetComponentInChildren<Text> ();
			string dragType = DragHandler.item.GetComponentsInChildren<Text> () [1].text;
			//Debug.Log ("Drag type = " + dragType);
			string inputType = parentObject.GetComponentInChildren<Text> ().text;
			//Debug.Log ("Input type = " + inputType);
			if (dragType == inputType) {
				DragHandler.item.transform.SetParent (transform);
				DragHandler.item.GetComponent<RockTextController> ().infoUsed = true;
			} else {
				//Debug.Log ("Nie to pole");
				StartCoroutine (handleWrongInputMessage (true, 0.5f));
				StartCoroutine (waitAndHideMessage());

			}

		} else {
			Debug.Log ("Pole zajęte!");
		}
	}
	#endregion
	IEnumerator waitAndHideMessage(){
		yield return new WaitForSeconds (5);
		StartCoroutine (handleWrongInputMessage (false, 0.5f));
	}
	IEnumerator handleWrongInputMessage(bool show, float duration){
		float counter = 0f;
		GameObject message = GameObject.Find ("WrongInputMessage");
		float a, b;
		if (show)
		{
			message.transform.position = new Vector3 (Screen.width / 2, 120,0.0f);
			a = 0;
			b = 1;
		}
		else
		{
			a = 1;
			b = 0;
		}

		CanvasGroup selectedMessage = message.GetComponent<CanvasGroup>();

		while (counter < duration)
		{
			counter += Time.deltaTime;
			float alpha = Mathf.Lerp(a, b, counter / duration);
			//Debug.Log(alpha);

			selectedMessage.alpha = alpha;

			yield return null;
		}
		if (show == false) {
			message.transform.position = new Vector3 (-message.GetComponent<RectTransform>().rect.width, message.GetComponent<RectTransform>().rect.height,0.0f);
		}
	}
}﻿