using UnityEngine;
using System.Collections;

public class SetupController : MonoBehaviour {
   private Board playerBoard;
   public Ship shipObject;
   public byte shipTotal;
   private Ship[] ships;


// Use this for initialization
   void Start () {
	 GameObject boardObject = GameObject.Find("PlayerBoard");
	 if (boardObject != null) {
	    playerBoard = boardObject.GetComponent<Board>();
	    CreateShips();
	    Debug.Log(playerBoard.transform.childCount);
	    playerBoard.LoadTiles();
	    PlaceShips();
	 } else {
	    Debug.Log("Cannot find 'PlayerBoard' script");
	 }
   }
   private void CreateShips () {
	 ships = new Ship[shipTotal];
	 for (int i = 0; i < ships.Length; i++) {
	    ships [i] = CreateShip("Ship" + i, i + 2);
	 }
   }
   private Ship CreateShip ( string name, int size) {
		Ship curShip = Instantiate(shipObject, Vector3.zero, Quaternion.identity) as Ship;
		curShip.Size = (byte)size;
		curShip.name = name;
		return curShip;
  }
  private void PlaceShips () {
		ships[1].Rotation = 45;
		ships[2].Rotation = 90;
		ships[3].Rotation = 90;

		PlaceShip(ships[0], "A9");
		PlaceShip(ships[1], "C8");
		PlaceShip(ships[2], "D1");
		PlaceShip(ships[3], "D4");
		PlaceShip(ships[4], "I6");

   }
   private void PlaceShip ( Ship ship, string address ) {
		Transform startTilePos;
		Debug.Log(playerBoard.transform.childCount);
		if((startTilePos = playerBoard.transform.Find(address)) != null) {
			Debug.Log(startTilePos);
			ship.transform.position = startTilePos.position;
		}
   }
}
