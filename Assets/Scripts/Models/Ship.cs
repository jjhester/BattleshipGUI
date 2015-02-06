using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
   public Coordinates slotObject;
   public byte size, rotation;
   private Coordinates[] slots;
   // Use this for initialization
   void Start () {
	 //Create the ship slots
	 this.slots = new Coordinates[size];
	
	 for (byte i = 0; i < size; i++) {
	    Vector3 position = new Vector3(0, 0, i);
	    Coordinates curSection = Instantiate(slotObject, position, Quaternion.identity) as Coordinates;
	    curSection.gameObject.transform.parent = this.gameObject.transform;
	    curSection.SetName("Slot", i);
	    this.slots [i] = slotObject;
//	    Debug.Log(this.slots [i]);
	 }
	 this.gameObject.transform.Rotate(Vector3.up, rotation); //Rotate after layout
   }
	
   // Update is called once per frame
   void Update () {
	
   }
}
