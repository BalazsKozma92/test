using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class itemLooks : MonoBehaviour {

	GameObject axe;
	GameObject axe2;
	GameObject hammer;
	GameObject mace;
	GameObject sword;
	Inventory inv;
	myWeapon myweapon;
	IList<GameObject> weaponList = new List<GameObject>();

	void Start () {
		axe = GameObject.Find ("axe");
		axe2 = GameObject.Find ("axe2");
		hammer = GameObject.Find ("hammer");
		mace = GameObject.Find ("mace");
		sword = GameObject.Find ("sword");
		inv = GameObject.Find ("Inventory").GetComponent<Inventory>();
		myweapon = GameObject.Find ("weapon").GetComponent<myWeapon> ();
		axe.SetActive (true);
		axe2.SetActive (false);
		mace.SetActive (false);
		sword.SetActive (false);
		hammer.SetActive (false);
		weaponList.Add (axe);
		weaponList.Add (axe2);
		weaponList.Add (mace);
		weaponList.Add (sword);
		weaponList.Add (hammer);
	}

	void Update () {
		if (inv.slots [0].transform.childCount >= 1) {
			ItemData weapon = inv.slots [0].transform.GetChild (0).GetComponent<ItemData> ();
			if (weapon.item.Type == "One-handed hammer") {
				for (int i = 0; i < 5; i++) {
					if (weaponList [i] == hammer) {
						hammer.SetActive (true);
						myweapon.speed = 0.595f;
					} else {
						weaponList [i].SetActive (false);
					}
				}
			} else if (weapon.item.Type == "One-handed axe") {
				for (int i = 0; i < 5; i++) {
					if (weaponList [i] == axe2) {
						axe2.SetActive (true);
						myweapon.speed = 0.464f;
					} else {
						weaponList [i].SetActive (false);
					}
				}
			} else if (weapon.item.Type == "One-handed mace") {
				for (int i = 0; i < 5; i++) {
					if (weaponList [i] == mace) {
						mace.SetActive (true);
						myweapon.speed = 0.595f;
					} else {
						weaponList [i].SetActive (false);
					}
				}
			} else if (weapon.item.Type == "One-handed sword") {
				for (int i = 0; i < 5; i++) {
					if (weaponList [i] == sword) {
						sword.SetActive (true);
						myweapon.speed = 0.464f;
					} else {
						weaponList [i].SetActive (false);
					}
				}
			} else {
				for (int i = 0; i < 4; i++) {
					if (weaponList [i] == axe) {
						axe.SetActive (true);
						myweapon.speed = 0.425f;
					} else {
						weaponList [i].SetActive (false);
					}
				}
			}
		}
	}
}
