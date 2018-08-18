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
		Debug.Log ("Input dropped = " + inputDropped);
		if (!item) {
			//GameObject parentObject = this.transform.parent.gameObject;
			Text textObject = parentObject.GetComponentInChildren<Text> ();
			string dragType = DragHandler.item.GetComponentsInChildren<Text> () [1].text;
			Debug.Log ("Drag type = " + dragType);
			string inputType = parentObject.GetComponentInChildren<Text> ().text;
			Debug.Log ("Input type = " + inputType);
			if (dragType == inputType) {
				DragHandler.item.transform.SetParent (transform);
			} else {
				Debug.Log ("Nie to pole");
			
			}

		} else {
			Debug.Log ("Pole zajęte!");
		}
	}
	#endregion
}﻿