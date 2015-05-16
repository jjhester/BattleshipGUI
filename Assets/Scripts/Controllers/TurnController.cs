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
   private GameController gameController;
   private Board currentBoard;
   private Player currentPlayer;
   private int shots;

 
   //Main switcher
   public void TakeShot ( string address) {
	 ShowShotBoard();
	 PlayerShot currentShot = new PlayerShot(address);
	 currentPlayer.game.shots.Add(currentShot);
	 DisplayShot(currentShot);
   }
	public void PlaceShip (int index, string startCoords, int rotation) {
		ShowShipBoard();
		PlayerShip ship = currentPlayer.game.ships[index];
		ship.startCoords = startCoords;
		ship.rotation = rotation;
		DisplayShip(ship, true);
	}
	public void SetPlayer(Player currentPlayer) {
		this.currentPlayer = currentPlayer;
		DisplayHUD();
		initBoard();
	}

   //Input Methods
	public void OnTileClick(Tile tile) {
		if (shots++ < currentPlayer.game.ShipsAfloat())
			TakeShot(tile.name);
		else
			gameController.EndTurn();
	}

    //*****Init Methods*****//
	void Start() {
		this.gameController = GameObject.FindObjectOfType<GameController>();
	}
	private void initBoard() {
		currentBoard = Instantiate(boardObject, Vector3.zero, Quaternion.identity) as Board;
		currentBoard.width = (byte) currentPlayer.game.boardSize;
		currentBoard.height = (byte) currentPlayer.game.boardSize;
		currentBoard.LoadTiles();
	}

   //*****Display Methods*****//

	public void DisplayHUD() {
		playerUI.SetPlayerInfo(currentPlayer);
	}
	public void ShowShotBoard() {
		DisplayBoard(currentPlayer, gameController.GetOpponentInfo(), false);
	}
	public void ShowShipBoard() {
		DisplayBoard(gameController.GetOpponentInfo(), currentPlayer, true);
	}
	private void DisplayBoard(Player shotPlayer, Player shipPlayer, bool displayShips) {
		for (int shot = 0; shot < shotPlayer.game.shots.Count; shot++) {
			DisplayShot(shotPlayer.game.shots[shot]);
		}
		for (int ship = 0; ship < shipPlayer.game.ships.Length; ship++) {
			DisplayShip(shipPlayer.game.ships[ship], displayShips);
		}
	}
     public void OnShotBoardToggle(bool playerShotBoard) {
		if (playerShotBoard)
			ShowShotBoard();
		else
			ShowShipBoard();
	}
   private void DisplayShip ( PlayerShip ship, bool visible ) {

		Transform startTilePos;
		if((startTilePos = currentBoard.transform.Find(ship.startCoords)) != null) {
			Ship shipGUI = Instantiate(shipObject, Vector3.zero, Quaternion.identity) as Ship;
			Debug.Log(startTilePos);
			shipGUI.Rotation = (byte) ship.rotation;
			shipGUI.transform.position = startTilePos.position;
			//shipGUI.GetComponent<Renderer>().enabled = visible;
		}
	}
	
   private void DisplayShot(PlayerShot shot) {
		Transform tilePos;
		if((tilePos = currentBoard.transform.Find(shot.coords)) != null) {
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
