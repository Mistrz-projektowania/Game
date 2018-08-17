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
		if (!item) {
			GameObject parentObject = this.transform.parent.gameObject;
			Text textObject = parentObject.GetComponentInChildren<Text>();
			string dragType = DragHandler.item.GetComponentsInChildren<Text> ()[1].text;
			string inputType = parentObject.GetComponentInChildren<Text>().text;
			if (dragType == inputType) {
				DragHandler.item.transform.SetParent (transform);
			} else {
				Debug.Log ("Nie to pole");
			
			}

		}
	}
	#endregion
}﻿