using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Game {
   public Guid id;
   public int boardSize;
   public PlayerShip[] ships;
   public List<PlayerShot> shots;

   public Game ( int boardSize, PlayerShip[] ships ): this(Guid.NewGuid(), boardSize, ships, new List<PlayerShot>()) {}
   public Game ( Guid id, int boardSize, PlayerShip[] ships, List<PlayerShot> shots ) {
		this.id = id;
		this.boardSize = boardSize;
		this.ships = ships;
		this.shots = shots;
	}
	public int ShipsAfloat() {
		int afloat = 0;
		foreach (var s in ships) {
			if (!s.isSunk) afloat++;
		}
		return afloat;
	}
}
