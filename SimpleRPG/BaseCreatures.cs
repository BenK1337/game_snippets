using UnityEngine;
using System.Collections;

public abstract class BaseCreatures : MonoBehaviour {

	public string creatureName;
	public float maxHealth;
	public float health;
	public float maxMana;
	public float mana;
	public int mainAttackDamage;
	public float mainAttackRange;
	public float mainAttackSpeed;
	
	public void GetHit(int playerDamage) {
		
		health -= playerDamage;
	}

	protected abstract void Attack();
}