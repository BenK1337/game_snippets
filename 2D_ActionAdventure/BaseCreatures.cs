using UnityEngine;
using System.Collections;

public abstract class BaseCreatures : MonoBehaviour {

	public string creatureName;

	public float health;
	public float maxHealth;
	public float damage;

	public float moveSpeed = 0.005f;
	public float chasingRange = 2f;

	public bool inCombat;


	public void GetHit (float playerDamage) {
		
		health -= playerDamage;
	}
}
