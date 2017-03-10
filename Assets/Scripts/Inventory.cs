using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	GameObject slotPanel;
	itemDataBase database;
	public GameObject inventorySlot;
	public GameObject inventoryItem;

	int slotAmount;
	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject>();

	void Start()
	{
		database = GetComponent<itemDataBase> ();

		slotAmount = 40;
		slotPanel = GameObject.Find ("Slot Panel");
		for (int i = 0; i < slotAmount; i++) 
		{
			items.Add (new Item ());
			slots.Add (Instantiate (inventorySlot));
			slots [i].GetComponent<SnapToSlot> ().id = i;
			slots [i].transform.SetParent (slotPanel.transform);
		}
	}
	public void AddItem(int id)
	{
		Item itemToAdd = database.FetchItemByID (id);

		if (itemToAdd.Stackable && IsInInventory (itemToAdd)) {
			for (int i = 0; i < items.Count; i++) {
				if (items [i].ID == id) {
					ItemData data = slots [i].transform.GetChild (0).GetComponent<ItemData> ();
					data.amount++;
					data.transform.GetChild (0).GetComponent<Text> ().text = data.amount.ToString ();
					break;
				}
			}
		} else {
			for (int j = 0; j < slotAmount; j++) {
			//	if (items [j].ID == -1) {
				if (slots [j].transform.childCount == 0) {
					//slots [j].transform.SetParent (slotPanel.transform);
					items [j] = itemToAdd;
					GameObject itemObj = Instantiate (inventoryItem);
					itemObj.transform.SetParent (slots [j].transform);
					itemObj.transform.localPosition = new Vector2 (0, 0);
					itemObj.GetComponent<ItemData> ().item = itemToAdd;
					itemObj.GetComponent<ItemData> ().amount = 1;
					itemObj.GetComponent<ItemData> ().slot = j;
					itemObj.GetComponent<Image> ().sprite = itemToAdd.Sprite;
					itemObj.name = itemToAdd.Title;
					break;	
				}
			}
		}
	}

	bool IsInInventory(Item item){
		for (int i = 0; i < items.Count; i++)
			if (items [i].ID == item.ID)
				return true;
		return false;
	}
}
