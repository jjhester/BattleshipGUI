using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {
   public Coordinates tileObject;
   public byte width, height;
   public float columnSpace, rowSpace;
   private Coordinates[,] tiles;
   

   // Use this for initialization
   void Start () {
	 //Create the board table
	 this.tiles = new Coordinates[height, width];
	 for (byte r = 0; r < height; r++) {
	    for (byte c = 0; c < width; c++) {
		  Vector3 position = new Vector3(r * (1 + rowSpace), 0, (width - 1 - c) * (1 + columnSpace));
		  Coordinates curTile = Instantiate(tileObject, position, Quaternion.identity) as Coordinates;
		  curTile.gameObject.transform.parent = this.gameObject.transform;
		  curTile.SetName(r, c);
		  
		  this.tiles [r, c] = curTile;
//		  Debug.Log(this.tiles [r, c]);
	    }
	 }
   }
	
   // Update is called once per frame
   void Update () {
	
   }
}
