using UnityEngine;
using System.Collections;

public class TurnController : MonoBehaviour {
   //Prefabs
   public Board boardObject;
   public Ship shipObject;
   public Peg pegObject;

   //HUD
   public PlayerUI playerUI;
	
   //Private references
   private Ship[] ships;
   private Board playerBoard;
   private Player[] players;

 
   //Main switcher
   public void TakeShot ( string address ) {
	 players[(int)PlayerType.Client].game.shots.Add(new PlayerShot(address));
	 DisplayBoard(players[(int)PlayerType.Opponent].game);
	 DisplayShot(address);
   }
	public void PlaceShips () {
	
	}
	public void SetPlayers(Player[] players) {
		this.players = players;
	}
   //Input Methods
	public void OnTileClick(Tile tile) {
		TakeShot(tile.name);
	}	
   //*****Display Methods*****//

	public void DisplayHUD() {
		UpdatePlayerInfo();
	}
	private void UpdatePlayerInfo() {
		playerUI.SetPlayerInfo(players[(int)PlayerType.Client]);
	}
   private void DisplayBoard (Game playerGame) {
	 playerBoard = Instantiate(boardObject, Vector3.zero, Quaternion.identity) as Board;
	 playerBoard.width = (byte) playerGame.boardSize;
	 playerBoard.height = (byte) playerGame.boardSize;
	 playerBoard.LoadTiles();
   }
  
   private void DisplayShip ( PlayerShip ship, bool visible ) {

		Transform startTilePos;
		if((startTilePos = playerBoard.transform.Find(ship.startCoords)) != null) {
			Ship shipGUI = Instantiate(shipObject, Vector3.zero, Quaternion.identity) as Ship;
			Debug.Log(startTilePos);
			shipGUI.Rotation = (byte) ship.rotation;
			shipGUI.transform.position = startTilePos.position;
			shipGUI.GetComponent<Renderer>().enabled = visible;
		}
	}
	
   private void DisplayShot(string address) {
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
