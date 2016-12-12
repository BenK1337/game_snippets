using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManaBar : MonoBehaviour {
	
	Player player;
	Image manaBar;
	
	void Start () {

		player = Player.player;
		manaBar = GetComponent<Image> ();
	}
	
	void Update () {
		
		manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount, player.mana / player.maxMana, 0.1f);
	}
}