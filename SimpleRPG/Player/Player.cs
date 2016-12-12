using UnityEngine;
using System.Collections;

public class Player : BaseCreatures {

	Animation anim;

	public AnimationClip attackAnimation;
	public static Transform opponent;
	public static Player player;
	public static bool isAttacking;
	public float attackImpact;

	void Awake () {
		player = this;
		AnimationInit ();
		isAttacking = false;
		health = maxHealth;
		mana = maxMana;
	}

	void AnimationInit() {

		anim = GetComponent<Animation> ();
		AnimationEvent attackEvent = new AnimationEvent();
		attackEvent.time = attackImpact;
		attackEvent.functionName = "Impact";
		attackAnimation.AddEvent (attackEvent);
	}

	void Impact() {

		mana -= 10;
		opponent.GetComponent<Enemy>().GetHit(mainAttackDamage);
	}
	
	void Update () {

		Attack ();
		NaturalRegeneration ();
	}

	protected override void Attack () {

		if (Input.GetMouseButtonDown (0)) {

			if(opponent != null && Vector3.Distance(opponent.position, transform.position) < mainAttackRange){

				isAttacking = true;
				anim.CrossFade(attackAnimation.name);
			}
		}

		if (!anim.IsPlaying (attackAnimation.name)) {

			isAttacking = false;
		}
	}

	void NaturalRegeneration () {

		if (health < maxHealth) {
			health += 1f * Time.deltaTime;
			if (health > maxHealth) health = maxHealth;
		}

		if (mana < maxMana) {
			mana += 1f * Time.deltaTime;
			if (mana > maxMana) mana = maxMana;
		}
	}
}