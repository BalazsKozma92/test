using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
	
	private Item item;
	private string data;
	private GameObject tooltip;
	private Inventory inv;

	void Start(){
		inv = GameObject.Find ("Inventory").GetComponent<Inventory> ();
		tooltip = GameObject.Find ("Tooltip");
		tooltip.SetActive (false);
	}

	void Update(){
		if(tooltip.activeSelf){
			tooltip.transform.position = Input.mousePosition;
		}
	}

	public void Activate(Item item){
		this.item = item;
		ConstructDataString ();
		tooltip.SetActive (true);
	}

	public void Deactivate(){
		tooltip.SetActive (false);
	}

	public void ConstructDataString(){
		if (item.Stamina == 0 && item.Strength == 0 && item.CritChance == 0 && item.Intellect == 0 && item.Armor == 0) {
			data = "<color=#f2f2f2><b>" + item.Title + "</b></color>\n" + item.Type + "\n\n" + item.Description + "\n\nValue: " + item.Value + " silver";
			tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		} else if (item.Rarity == 1 && item.Damage == "0"){
			data = "<color=#f2f2f2><b>" + item.Title + "</b></color>\n" + item.Type + "\n\n" + item.Description + "\n\nArmor:      " + item.Armor + "\nStamina:      " + item.Stamina + "\nStrength:     " + item.Strength + "\nIntellect:     " + item.Intellect + "\nCrit. Chance: " + item.CritChance + "\n\nValue: " + item.Value + " silver";
				tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		} else if (item.Rarity == 1 && item.Damage != "0"){
			data = "<color=#f2f2f2><b>" + item.Title + "</b></color>\n" + item.Type + "\n\n" + item.Description + "\n\nDamage:      " + item.Damage +  "\nStamina:      " + item.Stamina + "\nStrength:     " + item.Strength + "\nIntellect:     " + item.Intellect + "\nCrit. Chance: " + item.CritChance + "\n\nValue: " + item.Value + " silver";
			tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		} else if (item.Rarity == 2 && item.Damage == "0") {
			data = "<color=#66ff66><b>" + item.Title + "</b></color>\n" + item.Type + "\n\n" + item.Description + "\n\nArmor:      " + item.Armor + "\nStamina:      " + item.Stamina + "\nStrength:     " + item.Strength + "\nIntellect:     " + item.Intellect + "\nCrit. Chance: " + item.CritChance + "\n\nValue: " + item.Value + " silver";
			tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		} else if (item.Rarity == 2 && item.Damage != "0"){
			data = "<color=#66ff66><b>" + item.Title + "</b></color>\n" + item.Type + "\n\n" + item.Description + "\n\nDamage:      " + item.Damage +  "\nStamina:      " + item.Stamina + "\nStrength:     " + item.Strength + "\nIntellect:     " + item.Intellect + "\nCrit. Chance: " + item.CritChance + "\n\nValue: " + item.Value + " silver";
			tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		} else if (item.Rarity == 3 && item.Damage == "0") {
			data = "<color=#0066ff><b>" + item.Title + "</b></color>\n" + item.Type + "\n\n" + item.Description + "\n\nArmor:      " + item.Armor + "\nStamina:      " + item.Stamina + "\nStrength:     " + item.Strength + "\nIntellect:     " + item.Intellect + "\nCrit. Chance: " + item.CritChance + "\n\nValue: " + item.Value + " silver";
			tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		} else if (item.Rarity == 3 && item.Damage != "0"){
			data = "<color=#0066ff><b>" + item.Title + "</b></color>\n" + item.Type + "\n\n" + item.Description + "\n\nDamage:      " + item.Damage +  "\nStamina:      " + item.Stamina + "\nStrength:     " + item.Strength + "\nIntellect:     " + item.Intellect + "\nCrit. Chance: " + item.CritChance + "\n\nValue: " + item.Value + " silver";
			tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		} else if (item.Rarity == 4 && item.Damage == "0") {
			data = "<color=#ff00ff><b>" + item.Title + "</b></color>\n" + item.Type + "\n\n" + item.Description + "\n\nArmor:      " + item.Armor + "\nStamina:      " + item.Stamina + "\nStrength:     " + item.Strength + "\nIntellect:     " + item.Intellect + "\nCrit. Chance: " + item.CritChance + "\n\nValue: " + item.Value + " silver";
			tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		} else if (item.Rarity == 4 && item.Damage != "0"){
			data = "<color=#ff00ff><b>" + item.Title + "</b></color>\n" + item.Type + "\n\n" + item.Description + "\n\nDamage:      " + item.Damage +  "\nStamina:      " + item.Stamina + "\nStrength:     " + item.Strength + "\nIntellect:     " + item.Intellect + "\nCrit. Chance: " + item.CritChance + "\n\nValue: " + item.Value + " silver";
			tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		} else if (item.Rarity == 5 && item.Damage == "0") {
			data = "<color=#ff6600><b>" + item.Title + "</b></color>\n" + item.Type + "\n\n" + item.Description + "\n\nArmor:      " + item.Armor + "\nStamina:      " + item.Stamina + "\nStrength:     " + item.Strength + "\nIntellect:     " + item.Intellect + "\nCrit. Chance: " + item.CritChance + "\n\nValue: " + item.Value + " silver";
			tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;	
		} else if (item.Rarity == 5 && item.Damage != "0"){
			data = "<color=#ff6600><b>" + item.Title + "</b></color>\n" + item.Type + "\n\n" + item.Description + "\n\nDamage:      " + item.Damage +  "\nStamina:      " + item.Stamina + "\nStrength:     " + item.Strength + "\nIntellect:     " + item.Intellect + "\nCrit. Chance: " + item.CritChance + "\n\nValue: " + item.Value + " silver";
			tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		} 
	}
}