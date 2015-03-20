using UnityEngine;
using System.Collections;

public class PlayerShip {
   public string name, startCoords;
   public int size;
   public float rotation;
   public bool isSunk;

   public PlayerShip ( string name, int size ) : this(name, "", size, 0.0f ) {}

   public PlayerShip ( string name, string startCoords, int size, float rotation ) {
	 this.name = name;
	 this.startCoords = startCoords;
	 this.size = size;
	 this.rotation = rotation;
   }
}
