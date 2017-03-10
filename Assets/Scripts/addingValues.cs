using UnityEngine;
using System.Collections;

public class addingValues : MonoBehaviour {

	Inventory inv;

	void Start(){
		inv = GameObject.Find ("Inventoy").GetComponent<Inventory> ();
	}

	void Update(){
		checkForStackable ();
	}

	void checkForStackable(){
		for (int i = 0; i < inv.items.Count; i++) {
			ItemData isStackable = inv.slots [i].transform.GetChild (0).GetComponent<ItemData> ();
			if (isStackable.item.Stackable) {
				isStackable.item.Value *= isStackable.amount;
			}
		}
	}
}
