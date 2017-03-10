using UnityEngine;
using System.Collections;

public class facePlayerOnClick : MonoBehaviour {

	Transform player;

	void Start () {
		player = GameObject.Find("Player").transform;
	}

	void Update(){
		if (Input.GetButtonDown ("F")) {
			facePlayer ();
		}
	}

	void facePlayer () {
		if (Vector3.Distance (player.position, this.transform.position) < 4f) {
			Vector3 direction = (player.position - this.transform.position);
			direction.y = 0f;

			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 1f);
		}
	}
}
