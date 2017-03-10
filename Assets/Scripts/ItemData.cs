using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerDownHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler{
	public Item item;
	public int amount;
	public int slot;
	playerDatas playerdata;

	private Inventory inv;
	private Tooltip tooltip;
	private Vector2 offset;

	//AudioSource dragStart;
	//AudioSource dragEnd;

	void Start(){
		playerdata = GameObject.Find ("Player").GetComponent<playerDatas> ();
		//dragStart = GameObject.Find ("InvObjectDragStart").GetComponent<AudioSource> ();
		//dragEnd = GameObject.Find ("InvObjectDragEnd").GetComponent<AudioSource> ();
		inv = GameObject.Find ("Inventory").GetComponent<Inventory> ();
		tooltip = inv.GetComponent<Tooltip> ();
	}

	public void OnBeginDrag(PointerEventData eventData){
		if(item != null){
			//dragStart.Play ();
			offset = eventData.position - new Vector2 (this.transform.position.x, this.transform.position.y);
			this.transform.SetParent (this.transform.parent.parent);
			this.transform.position = eventData.position - offset;
			GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
	}

	public void OnDrag(PointerEventData eventData){
		if(item != null){
			this.transform.position = eventData.position - offset;
		}
	}

	public void OnPointerDown(PointerEventData eventData){
		int i = eventData.clickCount;
		if (i == 2) {
			if (this.item.Type == "Food") {
				if (this.amount > 1) {
					this.amount -= 1;
					this.transform.GetChild (0).GetComponent<Text> ().text = this.amount.ToString ();
					playerdata.healthbar.value += 10;
				} else {
					Destroy (this.gameObject);
					playerdata.healthbar.value += 10;
				}
			} else {
				playerdata.silver += (this.item.Value * this.amount);
				Destroy (this.gameObject);
				tooltip.Deactivate ();
			}
		}
	}

	public void OnEndDrag(PointerEventData eventData){
		//dragEnd.Play ();
		this.transform.SetParent (inv.slots[slot].transform);
		this.transform.position = inv.slots[slot].transform.position;
		GetComponent<CanvasGroup> ().blocksRaycasts = true ;
	}

	public void OnPointerEnter(PointerEventData eventData){
		Debug.Log ("Pointer Enter");
		tooltip.Activate (item);
	}

	public void OnPointerExit(PointerEventData eventData){
		Debug.Log ("Pointer Exit");
		tooltip.Deactivate ();
	}

	void Update(){
//		Debug.Log (playerdata.silver);
	}
}
