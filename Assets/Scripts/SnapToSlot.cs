using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class SnapToSlot : MonoBehaviour, IDropHandler {
	public int id;
	private Inventory inv;

	void Start(){
		inv = GameObject.Find ("Inventory").GetComponent<Inventory> ();
	}

	public void OnDrop(PointerEventData eventData){

		ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData> ();
	//	if (inv.items [id].ID == -1) {
		if (inv.slots [id].transform.childCount == 0) {
			inv.items [droppedItem.slot] = new Item ();
			inv.items [id] = droppedItem.item;
			droppedItem.slot = id;
		} else if (droppedItem.slot != id) {
			Transform item = this.transform.GetChild (0);
			ItemData currentItem = this.transform.GetChild (0).GetComponent<ItemData>();
			if (droppedItem.item.Stackable && currentItem.item.Stackable) {
				if (droppedItem.item.ID == currentItem.item.ID) {
					currentItem.amount += droppedItem.amount;
					Destroy (droppedItem.item.Sprite);
					currentItem.transform.GetChild (0).GetComponent<Text> ().text = currentItem.amount.ToString ();
				}
			} else {
				item.GetComponent<ItemData> ().slot = droppedItem.slot;
				item.transform.SetParent (inv.slots [droppedItem.slot].transform);
				item.transform.position = inv.slots [droppedItem.slot].transform.position;
				
				inv.items [droppedItem.slot] = item.GetComponent<ItemData> ().item;
				inv.items [id] = droppedItem.item;
				droppedItem.slot = id;
			}
		}
	}
}
