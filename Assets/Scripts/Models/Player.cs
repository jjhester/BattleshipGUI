using UnityEngine;
using System;
using System.Collections;

public class Player {
   public Guid id;
   public Game game;
   public string username ;
   public int points;
	
   public Player ( string username, Game game ) : this(Guid.NewGuid(), username, 0, game) {}

   public Player ( Guid id, string username, int points, Game game ) {
 	this.id = id;
	this.points = points;
	this.username = username;
	this.game = game;
   }
}
