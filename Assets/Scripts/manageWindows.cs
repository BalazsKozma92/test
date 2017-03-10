using UnityEngine;
using System.Collections;

public class manageWindows : MonoBehaviour {

	public CanvasGroup canvasgroupInv;
	//AudioSource invOpen;
	//AudioSource invClose;

	void Start () {
		//invOpen = GameObject.Find ("InventoryOpen").GetComponent<AudioSource>();
		//invClose = GameObject.Find ("InventoryClose").GetComponent<AudioSource>();
		canvasgroupInv.alpha = 0f;
	}

	void Update () {
		if (Input.GetButtonDown("I")) {
			InventoryOpen();
		}
		if (Input.GetButtonDown("Cancel")) {
			closeGroups();
		}
	}

	void InventoryOpen(){
		if (canvasgroupInv.alpha == 0f) {
			canvasgroupInv.alpha = canvasgroupInv.alpha + 1;
		//	invOpen.Play ();
			Time.timeScale = 0.5f;
		} else {
			canvasgroupInv.alpha = canvasgroupInv.alpha - 1;
		//	invClose.Play ();
			Time.timeScale = 1f;
		}
	}

	void closeGroups(){
		canvasgroupInv.alpha = canvasgroupInv.alpha - 1;
	//	invClose.Play ();
		Time.timeScale = 1f;
	}

}
