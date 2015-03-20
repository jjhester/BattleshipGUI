using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
   private TurnController turn;
   private Player[] players;

   // Use this for initialization
   void Start () {
	 InitGame();
	 PlaceShips();
	 turn.DisplayHUD();
	 turn.TakeShot("A1");
	 turn.TakeShot("I8");
   }
   void InitGame () {
	 //Set turn controller
	 turn = GetComponent<TurnController>();

	 //Create ships
	 PlayerShip[] ships = new PlayerShip[PlayerPrefs.GetInt("Ship Total")];
	 for (int s = 0; s < ships.Length; s++) {
	    ships [s] = new PlayerShip("Ship " + s, s + 1);
	 }

	 //Create new game with no shots
	 Game game = new Game(PlayerPrefs.GetInt("Board Size"), ships);

	 //Create players
	 players = new Player[2];
	 for (int p = 0; p < 2; p++) {
	    players [p] = new Player(PlayerPrefs.GetString("Player " + (p + 1) + " Name"), game);
	 }
	 turn.SetPlayers(players);
   }
   void PlaceShips () {

   }
//   public Player GetPlayer ( int playerNum ) {
//	 if (playerNum < players.Length) {
//	    return this.players [playerNum];
//	 } else {
//	    return null;
//	 }
//   }

	
   // Update is called once per frame
   void Update () {
	
   }
}
