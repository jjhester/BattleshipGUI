using UnityEngine;
using System.Collections;

public class TurnController : MonoBehaviour {
   public Board playerBoard;



   //*****TURN PHASES*****//
   private void ShotPhase ( Coordinates[] coords ) {	//Array allows for special weapons
	 //Results in hit or miss
   }
   private void QuestionPhase ( Question question ) {   //Educational component
	 //Display question

	 //If answer is correct, get points
   }
   private void SpecialWeaponPhase ( Weapon weapon ) {	//Optional phase

   }



}
