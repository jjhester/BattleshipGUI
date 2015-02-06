using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
   public Coordinates slotObject;
   [SerializeField]
   private byte
	 size, rotation;
   private Coordinates[] slots;
   
   public byte Size {
	 get{ return size;}
	 set { 
	    size = value;
	    Resize();
		
	 }
   }

   public byte Rotation {
	 get{ return rotation;}
	 set {
	    rotation = value;
	    Rotate();
	 }
   }
   private void Rotate () {
	 this.transform.RotateAround(this.transform.position, Vector3.up, rotation);
   }
   private void Resize () {
	 //Create the ship slots
	 this.slots = new Coordinates[size];
		
	 for (byte i = 0; i < size; i++) {
	    Vector3 position = new Vector3(this.transform.position.x, 0, i + this.transform.position.z);
	    Coordinates curSection = Instantiate(slotObject, position, Quaternion.identity) as Coordinates;
	    curSection.transform.parent = this.transform;
	    curSection.SetName("Slot", i);
	    this.slots [i] = slotObject;
	 }
	 //Rotate after layout
	 Rotate();
   }
  
   // Use this for initialization
   void Start () {
	 
   }
  
	
   // Update is called once per frame
   void Update () {
	
   }
}
