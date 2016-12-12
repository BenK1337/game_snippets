using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManaBarText : MonoBehaviour {

	Player player;
	Text manaBarText;
	
	void Start () {
		player = Player.player;
		manaBarText = GetComponent<Text> ();
	}
	
	void Update () {

		int intMana = (int) player.mana;
		manaBarText.text = intMana.ToString () + " / " + player.maxMana.ToString ();
	}
}