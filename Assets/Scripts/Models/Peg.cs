using UnityEngine;
using System.Collections;

public class Peg : MonoBehaviour {
   [SerializeField] 
   private PegMark
	 type;

   public PegMark Type {
	 get{ return type;}
	 set {
	    type = value;
	    UpdatePegType();
	 }
   }
	
   private void UpdatePegType () {
	 switch (type) {
	    case PegMark.Hit:
		  this.gameObject.renderer.material.color = Color.red;
		  break;
	    case PegMark.Miss:
		  this.gameObject.renderer.material.color = Color.white;
		  break;
	    default:
		  break;
	 }
   }
   //Check for hit or miss
   void OnTriggerEnter ( Collider other ) {
		Debug.Log(this.name + "-" + other.tag);
	 switch (other.tag) {
	    case "Slot":
		  this.Type = PegMark.Hit;
		  other.gameObject.GetComponent<Slot>().Type = SlotMark.Hit;
		  break;
	    default:
		  if (this.Type != PegMark.Miss) { //Default value
			this.Type = PegMark.Miss;
		  }
		  break;
	 }
   }
	void OnTriggerExit ( Collider other ) {
		Debug.Log(this.name + "-" + other.tag);
		switch (other.tag) {
			case "Slot":
				other.gameObject.GetComponent<Slot>().Type = SlotMark.None;
				break;
			case "Tile":
				Tile currentTile = other.gameObject.GetComponent<Tile>();
				 if (currentTile.Type == TileMark.Pegged) 
					currentTile.Type = TileMark.Unoccupied;
				else 
					currentTile.Type = TileMark.Occupied;
				break;
		}
	}

   // Use this for initialization
   void Start () {
		UpdatePegType ();
   }
	
   // Update is called once per frame
   void Update () {
	
   }
}
