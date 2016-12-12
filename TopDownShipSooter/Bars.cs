using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bars : MonoBehaviour {

	Player player;

	public Image laserBar;
	public Image healthBar;
	public Image shieldBar;

	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void Update () {
	
		laserBar.fillAmount = Mathf.Lerp(laserBar.fillAmount, player.laserPower / player.maxLaserPower, 0.1f);
		healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, player.health / player.maxHealth, 0.1f);
		shieldBar.fillAmount = Mathf.Lerp(shieldBar.fillAmount, player.shield / player.maxShield, 0.1f);
	}
}
