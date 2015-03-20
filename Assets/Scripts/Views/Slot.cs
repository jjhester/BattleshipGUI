using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {
   [SerializeField] 
   private SlotMark
	 type;
   public SlotMark Type {
	 get{ return type;}
	 set {
	    type = value;
	    UpdateSlotType();
	 }
   }
  
   private void UpdateSlotType () {
	 switch (type) {
	    case SlotMark.Hit:
		  this.gameObject.GetComponent<Renderer>().material.color = Color.red;
		  break;
	    case SlotMark.None:
		  this.gameObject.GetComponent<Renderer>().material.color = Color.white;
		  break;
	    default:
		  break;
	 }
   }
   //Check for ship or peg
   void OnTriggerEnter ( Collider other ) {
		//Debug.Log(this.name + "-" + other.tag);
		switch (other.tag) {
			case "Peg":
				this.Type = SlotMark.Hit;
				break;
			default:
				if (this.Type != SlotMark.None) { //Default value
					this.Type = SlotMark.None;
				}
				break;
		}
	}
   // Use this for initialization
   void Start () {
		UpdateSlotType();
   }
   // Update is called once per frame
   void Update () {
	
   }
}
