using UnityEngine;
using System.Collections;

public class TurnController : MonoBehaviour {
   //Prefabs
   public Board boardObject;
   public Ship shipObject;
   public Peg pegObject;
	
   public byte boardWidth, boardHeight, shipTotal;
	
   //Private references
   private Ship[] ships;
   private Board playerBoard;
	
	
   // Use this for initialization
   void Start () {
	 SetupPhase();
	 ShotPhase();
   }

   //*****SETUP PHASE*****//
   private void SetupPhase () {
	 LoadBoard();
	 CreateShips();
	 PlaceShips();
   }
   private void LoadBoard () {
	 playerBoard = Instantiate(boardObject, Vector3.zero, Quaternion.identity) as Board;
	 playerBoard.width = boardWidth;
	 playerBoard.height = boardHeight;
	 playerBoard.LoadTiles();
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

   //*****TURN PHASES*****//
   private void ShotPhase ( ) {
	 //Results in hit or miss
	TakeShot("A1");
		TakeShot("A9");
		TakeShot("I5");
		TakeShot("C6");

   }
   private void TakeShot(string address) {
		Transform tilePos;
		if((tilePos = playerBoard.transform.Find(address)) != null) {
			Debug.Log("Shot -" + tilePos);
			Peg curPeg = Instantiate(pegObject, Vector3.zero, Quaternion.identity) as Peg;
			curPeg.transform.position = tilePos.position;
		}
	}
   private void QuestionPhase ( Question question ) {   //Educational component
	 //Display question

	 //If answer is correct, get points
   }
   private void SpecialWeaponPhase ( Weapon weapon ) {	//Optional phase

   }




}
