using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class updateStats : MonoBehaviour {

	public Slider healthbar;
	public Slider manabar;
	public Slider xpbar;
	myWeapon myweapon;
	playerDatas playerdata;
	float damageFromStrength;
	float xpNeeded = 400f;
	int level = 1;
	[HideInInspector] public int strengthFromWeapon;
	[HideInInspector] public int staminaFromWeapon;
	[HideInInspector] public int critChanceFromWeapon;
	[HideInInspector] public int intellectFromWeapon;
	[HideInInspector] public int armorFromWeapon;
	[HideInInspector] public int strengthFromHead;
	[HideInInspector] public int staminaFromHead;
	[HideInInspector] public int critChanceFromHead;
	[HideInInspector] public int intellectFromHead;
	[HideInInspector] public int armorFromHead;
	[HideInInspector] public int strengthFromChest;
	[HideInInspector] public int staminaFromChest;
	[HideInInspector] public int critChanceFromChest;
	[HideInInspector] public int intellectFromChest;
	[HideInInspector] public int armorFromChest;
	[HideInInspector] public int strengthFromWaist;
	[HideInInspector] public int staminaFromWaist;
	[HideInInspector] public int critChanceFromWaist;
	[HideInInspector] public int intellectFromWaist;
	[HideInInspector] public int armorFromWaist;
	[HideInInspector] public int strengthFromLegs;
	[HideInInspector] public int staminaFromLegs;
	[HideInInspector] public int critChanceFromLegs;
	[HideInInspector] public int intellectFromLegs;
	[HideInInspector] public int armorFromLegs;
	[HideInInspector] public int strengthFromBoots;
	[HideInInspector] public int staminaFromBoots;
	[HideInInspector] public int critChanceFromBoots;
	[HideInInspector] public int intellectFromBoots;
	[HideInInspector] public int armorFromBoots;
	[HideInInspector] public int strengthFromWrist;
	[HideInInspector] public int staminaFromWrist;
	[HideInInspector] public int critChanceFromWrist;
	[HideInInspector] public int intellectFromWrist;
	[HideInInspector] public int armorFromWrist;
	[HideInInspector] public int strengthFromAmulet;
	[HideInInspector] public int staminaFromAmulet;
	[HideInInspector] public int critChanceFromAmulet;
	[HideInInspector] public int intellectFromAmulet;
	[HideInInspector] public int armorFromAmulet;
	[HideInInspector] public int strengthFromHands;
	[HideInInspector] public int staminaFromHands;
	[HideInInspector] public int critChanceFromHands;
	[HideInInspector] public int intellectFromHands;
	[HideInInspector] public int armorFromHands;
	[HideInInspector] public int strengthFromRing;
	[HideInInspector] public int staminaFromRing;
	[HideInInspector] public int critChanceFromRing;
	[HideInInspector] public int intellectFromRing;
	[HideInInspector] public int armorFromRing;
	[HideInInspector] public int strengthFromCharm;
	[HideInInspector] public int staminaFromCharm;
	[HideInInspector] public int critChanceFromCharm;
	[HideInInspector] public int intellectFromCharm;
	[HideInInspector] public int armorFromCharm;

	void Start () {
		playerdata = GameObject.Find ("Player").GetComponent<playerDatas> ();
		myweapon = GameObject.Find ("weapon").GetComponent<myWeapon> ();
	}

	void Update () {

		playerdata.strength3 = (2 + strengthFromWeapon + strengthFromHead + strengthFromChest + strengthFromWaist + strengthFromLegs + strengthFromBoots + strengthFromWrist + strengthFromAmulet + strengthFromHands + strengthFromRing + strengthFromCharm);
		playerdata.stamina3 = (5 + staminaFromWeapon + staminaFromHead + staminaFromChest + staminaFromWaist + staminaFromLegs + staminaFromBoots + staminaFromWrist + staminaFromAmulet + staminaFromHands + staminaFromRing + staminaFromCharm);
		playerdata.critChance3 = (1 + critChanceFromWeapon + critChanceFromHead + critChanceFromChest + critChanceFromWaist + critChanceFromLegs + critChanceFromBoots + critChanceFromWrist + critChanceFromAmulet + critChanceFromHands + critChanceFromRing + strengthFromCharm);
		playerdata.intellect3 = (2 + intellectFromWeapon + intellectFromHead + intellectFromChest + intellectFromWaist + intellectFromLegs + intellectFromBoots + intellectFromWrist + intellectFromAmulet + intellectFromHands + intellectFromRing + intellectFromCharm);
		playerdata.armor3 = (0 + armorFromWeapon + armorFromHead + armorFromChest + armorFromWaist + armorFromLegs + armorFromBoots + armorFromWrist + armorFromAmulet + armorFromHands + armorFromRing + armorFromCharm);
		playerdata.strength = playerdata.strength2 + playerdata.strength3;
		playerdata.stamina = playerdata.stamina2 + playerdata.stamina3;
		playerdata.critChance = playerdata.critChance2 + playerdata.critChance3;
		playerdata.intellect = playerdata.intellect2 + playerdata.intellect3;
		playerdata.armor = playerdata.armor2 + playerdata.armor3;

		updateStatValues ();

		if (xpbar.value == xpNeeded && xpbar.maxValue == xpNeeded) {
			xpNeeded += xpNeeded / 1.6f;
			xpbar.value = 0;
			xpbar.maxValue = xpNeeded;
			onLevelUp ();
		}

	}

	public void onLevelUp (){
		level += 1;
		playerdata.strength2 += 1;
		playerdata.intellect2 += 1;
		playerdata.stamina2 += 1;
		playerdata.critChance2 += 1;
		healthbar.maxValue = playerdata.stamina * 4.4f;
		manabar.maxValue = playerdata.intellect * 5.2f;
		Invoke ("onLevelUpHealthMana", 0.1f);
	}

	void updateStatValues(){
		damageFromStrength = playerdata.strength / 2.76f;
		if (healthbar.maxValue != playerdata.stamina * 4.4f || manabar.maxValue != playerdata.intellect * 5.2f || myweapon.damageMin != (playerdata.damageMin + damageFromStrength) || myweapon.damageMax != (playerdata.damageMax + damageFromStrength)) {
			healthbar.maxValue = playerdata.stamina * 4.4f;
			manabar.maxValue = playerdata.intellect * 5.2f;
			myweapon.damageMin = (playerdata.damageMin + damageFromStrength);
			myweapon.damageMax = (playerdata.damageMax + damageFromStrength);
		}
	}

	void OnGUI(){
		GUIStyle style = new GUIStyle ();
		style.fontSize = 24;
		style.normal.textColor = Color.white;
		Font font = (Font)Resources.Load ("Fonts/VecnaBold", typeof(Font));
		style.font = font;
		style.padding = new RectOffset (15, 0, 20, 0); // left, right, top, bottom
		GUILayout.Label ("Level: " + level.ToString(), style);
	}

	void onLevelUpHealthMana(){
		healthbar.value = healthbar.maxValue;
		manabar.value = manabar.maxValue;
	}
}
