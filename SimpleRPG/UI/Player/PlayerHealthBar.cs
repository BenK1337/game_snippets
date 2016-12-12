using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {

	Player player;
	Image healthBar;

	void Start () {

		player = Player.player;
		healthBar = GetComponent<Image> ();
	}

	void Update () {
	
		healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, player.health / player.maxHealth, 0.1f);
	}
}
