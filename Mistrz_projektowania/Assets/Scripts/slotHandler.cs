using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class slotHandler : MonoBehaviour , IDropHandler
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
			Debug.Log (DragHandler.item.GetComponentsInChildren<Text> ()[0].text);
			Debug.Log (DragHandler.item.GetComponentsInChildren<Text> ()[1].text);
			GameObject parentObject = this.transform.parent.gameObject;
			Debug.Log (parentObject);
			Text textObject = parentObject.GetComponentInChildren<Text>();
			Debug.Log (textObject.text);
			//Debug.Log (textObject);
			DragHandler.item.transform.SetParent(transform);
		}
	}
	#endregion
}﻿