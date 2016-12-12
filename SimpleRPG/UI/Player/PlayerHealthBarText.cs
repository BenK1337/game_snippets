using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthBarText : MonoBehaviour {
	
	Player player;
	Text healthBarText;
	
	void Start () {
		player = Player.player;
		healthBarText = GetComponent<Text> ();
	}
	
	void Update () {

		int intHealth = (int) player.health;
		healthBarText.text = intHealth.ToString () + " / " + player.maxHealth.ToString ();
	}
}
