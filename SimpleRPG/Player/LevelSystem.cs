using UnityEngine;
using System.Collections;

public class LevelSystem : MonoBehaviour {

	public int level;
	public int exp;
	public Player player;

	void Start () {
	
	}

	void Update () {

		LevelUp ();
	}

	void LevelUp() {

		if (exp >= level*200) {

			level = level +1;
			exp = 0;
			LevelEffect();
		}
	}

	void LevelEffect() {

		player.maxHealth += 100;
		player.mainAttackDamage += 50;
	}
}
















































