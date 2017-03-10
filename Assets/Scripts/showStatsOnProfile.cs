using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class showStatsOnProfile : MonoBehaviour {

	playerDatas playerdata;
	public Text currHealthText;
	public Text maxHealthText;
	public Text currManaText;
	public Text maxManaText;
	public Text staminaText;
	public Text strengthText;
	public Text damageMinText;
	public Text damageMaxText;
	public Text critText;
	public Text silverText;
	public Text intellect;
	public Text armor;
	public Slider healthbar;
	public Slider manabar;
	myWeapon myweapon;

	void Start () {
		playerdata = GameObject.Find ("Player").GetComponent<playerDatas> ();
		myweapon = GameObject.Find ("weapon").GetComponent<myWeapon> ();
//		InvokeRepeating ("updateTexts", 1f, 0.2f);
	}

	/*void Update () {
		maxHealthText.text = healthbar.maxValue.ToString("F0");
		currHealthText.text = healthbar.value.ToString("F0");
		maxManaText.text = manabar.maxValue.ToString("F0");
		currManaText.text = manabar.value.ToString("F0");
		staminaText.text = playerdata.stamina.ToString();
		strengthText.text = playerdata.strength.ToString();
		critText.text = playerdata.critChance.ToString();
		intellect.text = playerdata.intellect.ToString ();
		armor.text = playerdata.armor.ToString ();
		damageMinText.text = myweapon.damageMin.ToString("F1");
		damageMaxText.text = myweapon.damageMax.ToString("F1");
		silverText.text = playerdata.silver.ToString();
	}*/

	//void updateTexts(){
	void FixedUpdate(){
		maxHealthText.text = healthbar.maxValue.ToString("F0");
		currHealthText.text = healthbar.value.ToString("F0");
		maxManaText.text = manabar.maxValue.ToString("F0");
		currManaText.text = manabar.value.ToString("F0");
		staminaText.text = playerdata.stamina.ToString();
		strengthText.text = playerdata.strength.ToString();
		critText.text = playerdata.critChance.ToString();
		intellect.text = playerdata.intellect.ToString ();
		armor.text = playerdata.armor.ToString ();
		damageMinText.text = myweapon.damageMin.ToString("F1");
		damageMaxText.text = myweapon.damageMax.ToString("F1");
		silverText.text = playerdata.silver.ToString();
	}
}
