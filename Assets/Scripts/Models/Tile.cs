using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
   [SerializeField] 
   private TileMark
	 type;
   public TileMark Type {
	 get{ return type;}
	 set {
	    type = value;
	    UpdateTileType();
	 }
   }
	
   private void UpdateTileType () {
	 switch (type) {
	    case TileMark.Occupied:
		  this.gameObject.renderer.material.color = Color.green;
		  break;
	    case TileMark.Pegged:
		  this.gameObject.renderer.material.color = Color.white;
		  break;
	    case TileMark.Unoccupied:
		  this.gameObject.renderer.material.color = Color.blue;
		  break;
	    default:
		  break;
	 }
   }
   //Check for ship or peg
   void OnTriggerEnter ( Collider other ) {
		Debug.Log(this.name + "-" + other.tag);
		switch (other.tag) {
			case "Slot":
				this.Type = TileMark.Occupied;
				break;
			case "Peg":
				if (this.type == TileMark.Unoccupied)
					this.Type = TileMark.Pegged;
				break;
			default:
				if (this.Type != TileMark.Unoccupied) { //Default value
					this.Type = TileMark.Unoccupied;
				}
				break;
		}
	}

   void Start () {
		UpdateTileType ();
   }
	
   // Update is called once per frame
   void Update () {
	
   }
}
