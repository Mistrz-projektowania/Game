﻿using UnityEngine;
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
			//DragHandler.item.transform.SetParent(transform);
		}
	}
	#endregion
}﻿