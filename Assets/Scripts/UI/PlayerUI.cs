using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerUI : MonoBehaviour {
   private Text playerName, playerPoints;
   // Use this for initialization
   void Start () {
	 playerName = transform.Find("PlayerName").gameObject.GetComponent<Text>();
	 playerPoints = transform.Find("PlayerPoints").gameObject.GetComponent<Text>();
   }
	
   public void SetPlayerInfo ( Player player ) {
	 playerName.text = player.username;
	 playerPoints.text = player.points.ToString();
   }
}
