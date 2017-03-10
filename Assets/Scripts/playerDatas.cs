using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerDatas : MonoBehaviour { 

	public Slider healthbar;
	public Slider manabar;
	[HideInInspector] public float damageMin = 1;
	[HideInInspector] public float damageMax = 2;
	[HideInInspector] public int strength = 0;
	[HideInInspector] public int stamina = 0;
	[HideInInspector] public float critChance = 0;
	[HideInInspector] public int intellect = 0;
	[HideInInspector] public int armor = 0;
	[HideInInspector] public int strength2;
	[HideInInspector] public int stamina2;
	[HideInInspector] public float critChance2;
	[HideInInspector] public int intellect2;
	[HideInInspector] public int armor2;
	[HideInInspector] public int strength3;
	[HideInInspector] public int stamina3;
	[HideInInspector] public float critChance3;
	[HideInInspector] public int intellect3;
	[HideInInspector] public int armor3;
	[HideInInspector] public int silver = 0;
	public Text healthText;
	public Text manaText;
	string word;
	string[] arr;
	Inventory inv;
	updateStats update;

	void Start () {
		inv = GameObject.Find ("Inventory").GetComponent<Inventory>();
		update = GameObject.Find ("Inventory").GetComponent<updateStats> ();	
		InvokeRepeating ("healthManaRegen", 1, 3);
	}

	void healthManaRegen(){
		healthbar.value += (healthbar.maxValue / 80f);
		manabar.value += (manabar.maxValue / 10f);
	}

	void Update(){
		healthText.text = healthbar.value.ToString ("F0");
		manaText.text = manabar.value.ToString ("F0");
		if (inv.slots [0].transform.childCount >= 1) {
			ItemData weapon = inv.slots [0].transform.GetChild (0).GetComponent<ItemData> ();
			if (weapon.item.Type == "One-handed mace" || weapon.item.Type == "One-handed sword" || weapon.item.Type == "One-handed hammer" || weapon.item.Type == "One-handed axe" || weapon.item.Type == "Magic orb") {
				word = weapon.item.Damage;
				arr = word.Split ("-" [0]);
				damageMin = float.Parse (arr [0]);
				damageMax = float.Parse (arr [1]);
				update.strengthFromWeapon = weapon.item.Strength;
				update.staminaFromWeapon = weapon.item.Stamina;
				update.critChanceFromWeapon = weapon.item.CritChance;
				update.intellectFromWeapon = weapon.item.Intellect;
				update.armorFromWeapon = weapon.item.Armor;
			} else {
				update.strengthFromWeapon = 0;
				update.staminaFromWeapon = 0;
				update.critChanceFromWeapon = 0;
				update.intellectFromWeapon = 0;
				update.armorFromWeapon = 0;
				damageMin = 2;
				damageMax = 4;
			} 
		} else {
			update.strengthFromWeapon = 0;
			update.staminaFromWeapon = 0;
			update.critChanceFromWeapon = 0;
			update.intellectFromWeapon = 0;
			update.armorFromWeapon = 0;
			damageMin = 2;
			damageMax = 4;
		}
		if (inv.slots [1].transform.childCount >= 1) {
			ItemData head =  inv.slots [1].transform.GetChild (0).GetComponent<ItemData> ();
			if (head.item.Type == "Head") {
				update.strengthFromHead = head.item.Strength;
				update.staminaFromHead = head.item.Stamina;
				update.critChanceFromHead = head.item.CritChance;
				update.intellectFromHead = head.item.Intellect;
				update.armorFromHead = head.item.Armor;
			} else {
				update.strengthFromHead = 0;
				update.staminaFromHead = 0;
				update.critChanceFromHead = 0;
				update.intellectFromHead = 0;
				update.armorFromHead = 0;
			}
		} else {
			update.strengthFromHead = 0;
			update.staminaFromHead = 0;
			update.critChanceFromHead = 0;
			update.intellectFromHead = 0;
			update.armorFromHead = 0;
		}
		if (inv.slots [2].transform.childCount >= 1) {
			ItemData chest =  inv.slots [2].transform.GetChild (0).GetComponent<ItemData> ();
			if (chest.item.Type == "Chest") {
				update.strengthFromChest = chest.item.Strength;
				update.staminaFromChest = chest.item.Stamina;
				update.critChanceFromChest = chest.item.CritChance;
				update.intellectFromChest = chest.item.Intellect;
				update.armorFromChest = chest.item.Armor;
			} else {
				update.strengthFromChest = 0;
				update.staminaFromChest = 0;
				update.critChanceFromChest = 0;
				update.intellectFromChest = 0;
				update.armorFromChest = 0;
			}
		} else {
			update.strengthFromChest = 0;
			update.staminaFromChest = 0;
			update.critChanceFromChest = 0;
			update.intellectFromChest = 0;
			update.armorFromChest = 0;
		}
		if (inv.slots [3].transform.childCount >= 1) {
			ItemData waist =  inv.slots [3].transform.GetChild (0).GetComponent<ItemData> ();
			if (waist.item.Type == "Belt") {
				update.strengthFromWaist = waist.item.Strength;
				update.staminaFromWaist = waist.item.Stamina;
				update.critChanceFromWaist = waist.item.CritChance;
				update.intellectFromWaist = waist.item.Intellect;
				update.armorFromWaist = waist.item.Armor;
			} else {
				update.strengthFromWaist = 0;
				update.staminaFromWaist = 0;
				update.critChanceFromWaist = 0;
				update.intellectFromWaist = 0;
				update.armorFromWaist = 0;
			}
		} else {
			update.strengthFromWaist = 0;
			update.staminaFromWaist = 0;
			update.critChanceFromWaist = 0;
			update.intellectFromWaist = 0;
			update.armorFromWaist = 0;
		}
		if (inv.slots [4].transform.childCount >= 1) {
			ItemData legs =  inv.slots [4].transform.GetChild (0).GetComponent<ItemData> ();
			if (legs.item.Type == "Legs") {
				update.strengthFromLegs = legs.item.Strength;
				update.staminaFromLegs = legs.item.Stamina;
				update.critChanceFromLegs = legs.item.CritChance;
				update.intellectFromLegs = legs.item.Intellect;
				update.armorFromLegs = legs.item.Armor;
			} else {
				update.strengthFromLegs = 0;
				update.staminaFromLegs = 0;
				update.critChanceFromLegs = 0;
				update.intellectFromLegs = 0;
				update.armorFromLegs = 0;
			}
		} else {
			update.strengthFromLegs = 0;
			update.staminaFromLegs = 0;
			update.critChanceFromLegs = 0;
			update.intellectFromLegs = 0;
			update.armorFromLegs = 0;
		}
		if (inv.slots [5].transform.childCount >= 1) {
			ItemData boots =  inv.slots [5].transform.GetChild (0).GetComponent<ItemData> ();
			if (boots.item.Type == "Boots") {
				update.strengthFromBoots = boots.item.Strength;
				update.staminaFromBoots = boots.item.Stamina;
				update.critChanceFromBoots= boots.item.CritChance;
				update.intellectFromBoots = boots.item.Intellect;
				update.armorFromBoots= boots.item.Armor;
			} else {
				update.strengthFromBoots = 0;
				update.staminaFromBoots = 0;
				update.critChanceFromBoots = 0;
				update.intellectFromBoots = 0;
				update.armorFromBoots= 0;
			}
		} else {
			update.strengthFromBoots = 0;
			update.staminaFromBoots = 0;
			update.critChanceFromBoots = 0;
			update.intellectFromBoots = 0;
			update.armorFromBoots= 0;
		}
		if (inv.slots [6].transform.childCount >= 1) {
			ItemData wrist =  inv.slots [6].transform.GetChild (0).GetComponent<ItemData> ();
			if (wrist.item.Type == "Wrist") {
				update.strengthFromWrist = wrist.item.Strength;
				update.staminaFromWrist = wrist.item.Stamina;
				update.critChanceFromWrist = wrist.item.CritChance;
				update.intellectFromWrist = wrist.item.Intellect;
				update.armorFromWrist = wrist.item.Armor;
			} else {
				update.strengthFromWrist = 0;
				update.staminaFromWrist = 0;
				update.critChanceFromWrist = 0;
				update.intellectFromWrist = 0;
				update.armorFromWrist = 0;
			}
		} else {
			update.strengthFromWrist = 0;
			update.staminaFromWrist = 0;
			update.critChanceFromWrist = 0;
			update.intellectFromWrist = 0;
			update.armorFromWrist = 0;
		}
		if (inv.slots [7].transform.childCount >= 1) {
			ItemData amulet =  inv.slots [7].transform.GetChild (0).GetComponent<ItemData> ();
			if (amulet.item.Type == "Amulet" || amulet.item.Type == "Necklace") {
				update.strengthFromAmulet = amulet.item.Strength;
				update.staminaFromAmulet = amulet.item.Stamina;
				update.critChanceFromAmulet = amulet.item.CritChance;
				update.intellectFromAmulet = amulet.item.Intellect;
				update.armorFromAmulet = amulet.item.Armor;
			} else {
				update.strengthFromAmulet = 0;
				update.staminaFromAmulet = 0;
				update.critChanceFromAmulet = 0;
				update.intellectFromAmulet = 0;
				update.armorFromAmulet = 0;
			}
		} else {
			update.strengthFromAmulet = 0;
			update.staminaFromAmulet = 0;
			update.critChanceFromAmulet = 0;
			update.intellectFromAmulet = 0;
			update.armorFromAmulet = 0;
		}
		if (inv.slots [8].transform.childCount >= 1) {
			ItemData hands =  inv.slots [8].transform.GetChild (0).GetComponent<ItemData> ();
			if (hands.item.Type == "Hands") {
				update.strengthFromHands = hands.item.Strength;
				update.staminaFromHands = hands.item.Stamina;
				update.critChanceFromHands = hands.item.CritChance;
				update.intellectFromHands = hands.item.Intellect;
				update.armorFromHands = hands.item.Armor;
			} else {
				update.strengthFromHands = 0;
				update.staminaFromHands = 0;
				update.critChanceFromHands = 0;
				update.intellectFromHands = 0;
				update.armorFromHands = 0;
			}
		} else {
			update.strengthFromHands = 0;
			update.staminaFromHands = 0;
			update.critChanceFromHands = 0;
			update.intellectFromHands = 0;
			update.armorFromHands = 0;
		}
		if (inv.slots [9].transform.childCount >= 1) {
			ItemData ring = inv.slots [9].transform.GetChild (0).GetComponent<ItemData> ();
			if (ring.item.Type == "Ring") {
				update.strengthFromRing = ring.item.Strength;
				update.staminaFromRing = ring.item.Stamina;
				update.critChanceFromRing = ring.item.CritChance;
				update.intellectFromRing = ring.item.Intellect;
				update.armorFromRing = ring.item.Armor;
			} else {
				update.strengthFromRing = 0;
				update.staminaFromRing = 0;
				update.critChanceFromRing = 0;
				update.intellectFromRing = 0;
				update.armorFromRing = 0;
			}
		} else {
			update.strengthFromRing = 0;
			update.staminaFromRing = 0;
			update.critChanceFromRing = 0;
			update.intellectFromRing = 0;
			update.armorFromRing = 0;
		}
		if (inv.slots [10].transform.childCount >= 1) {
			ItemData charm = inv.slots [10].transform.GetChild (0).GetComponent<ItemData> ();
			if (charm.item.Type == "Charm") {
				update.strengthFromCharm = charm.item.Strength;
				update.staminaFromCharm = charm.item.Stamina;
				update.critChanceFromCharm = charm.item.CritChance;
				update.intellectFromCharm = charm.item.Intellect;
				update.armorFromCharm = charm.item.Armor;
			} else {
				update.strengthFromCharm = 0;
				update.staminaFromCharm = 0;
				update.critChanceFromCharm = 0;
				update.intellectFromCharm = 0;
				update.armorFromCharm = 0;
			}
		} else {
			update.strengthFromCharm = 0;
			update.staminaFromCharm = 0;
			update.critChanceFromCharm = 0;
			update.intellectFromCharm = 0;
			update.armorFromCharm = 0;
		}
	}
		
	public void ApplyDamage(float DamageAmount) {

		healthbar.value -= DamageAmount;

		if (healthbar.value <= 0f) {
			Debug.Log ("You're dead.");
		}
	}
}
