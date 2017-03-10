using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class cursorLock : MonoBehaviour {

	private bool isCursorLocked;

	void Start () {
		ToggleCursorState ();
	}

	void Update () {
		CheckForInput ();
		CheckIfCursorShouldBeLocked ();
		Debug.Log (Cursor.lockState);
	}

	void ToggleCursorState(){
		isCursorLocked = !isCursorLocked;
	}

	void CheckForInput(){
		if (Input.GetButtonDown("I") || Input.GetButtonDown("Cancel")) {
			ToggleCursorState ();
		}
	}

	void CheckIfCursorShouldBeLocked(){
		if (isCursorLocked) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		} else {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}
