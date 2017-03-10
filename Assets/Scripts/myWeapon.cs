using UnityEngine;
using System.Collections;

public class myWeapon : MonoBehaviour {
	public float damageMin;
	public float damageMax;
	float damage;
	public float range = 1.2f;
	public float totarget;
	public float speed = 1f;
	private float nextHit;
	//AudioSource swish;
	//AudioSource stab;
	public CanvasGroup canvasgroupInv;

	void Start(){
	//	swish = GameObject.Find ("Swish").GetComponent<AudioSource> ();
	//	stab = GameObject.Find ("Stab").GetComponent<AudioSource> ();
	}

	public void Update() {
		damage = Random.Range (damageMin, damageMax);
		if (Input.GetButtonDown("Attack") && canvasgroupInv.alpha == 0f) {
			Swing();
		}
	}
	
	public void Swing() {

		RaycastHit hit;

		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));
		if (Physics.Raycast (ray, out hit, range)) {
			totarget = hit.distance;
			if (totarget < range && Time.time >= nextHit) {
		//		stab.Play ();
				nextHit = Time.time + speed;
				hit.transform.SendMessage ("ApplyDamageOnMob", damage, SendMessageOptions.DontRequireReceiver);
			}
		} else if (Time.time >= nextHit){
			nextHit = Time.time + speed;
	//		swish.Play ();
		}
	}
}