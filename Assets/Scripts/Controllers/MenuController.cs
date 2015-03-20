using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {
   public Slider boardSize, shipTotal;
   public InputField player1Name, player2Name;
   // Use this for initialization
   void Start () {
	
   }
	
   // Update is called once per frame
   void Update () {
	
   }
   public void StartGame () {
	 PlayerPrefs.SetInt("Board Size", (int)boardSize.value);
	 PlayerPrefs.SetInt("Ship Total", (int)shipTotal.value);
	 PlayerPrefs.SetString("Player 1 Name", player1Name.text);
	 PlayerPrefs.SetString("Player 2 Name", player2Name.text);
	 PlayerPrefs.Save();
	 Application.LoadLevel(1);
   }
}
