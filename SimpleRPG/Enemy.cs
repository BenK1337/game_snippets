using UnityEngine;
using System.Collections;

public class Enemy : BaseCreatures {

	Animation anim;
	public AnimationClip idleAnimation;
	public AnimationClip runAnimation;
	public AnimationClip attackAnimation;

	Player player;
	NavMeshAgent navAgent;
	Vector3 spawnPosition;
	public static bool isAttacking;
	
	public float chasingRange;
	public float attackImpact;

	public LevelSystem playerLevel;

	void Start () {
	
		player = Player.player;
		navAgent = GetComponent<NavMeshAgent> ();
		AnimationInit ();
		spawnPosition = transform.position;
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

		if (IsInRange (mainAttackRange)) {
		player.GetHit (mainAttackDamage);
		}
	}

	void Update () {

		Animate ();
		ChasingPlayer ();
		Attack ();
		Die ();
	}

	void OnMouseOver() {

		Player.opponent = transform;
	}

	void Animate() {
		
		if (!Enemy.isAttacking) {
			
			if (navAgent.velocity.magnitude > 1f) {
				
				anim.CrossFade (runAnimation.name);
			} else {
				
				anim.CrossFade (idleAnimation.name);
			}
		}
	}

	void ChasingPlayer () {

		if (IsInRange (chasingRange)) {

			navAgent.SetDestination (player.transform.position);
		}

		else {

			navAgent.SetDestination(spawnPosition);
		}
	}

	protected override void Attack() {

		if (IsInRange (mainAttackRange)) {

			isAttacking = true;
			anim.CrossFade(attackAnimation.name);
		}

		
		if (!anim.IsPlaying (attackAnimation.name)) {
			
			isAttacking = false;
		}
	}

	void Die () {

		if (health <= 0) {
			playerLevel.exp = playerLevel.exp + 200;
			Destroy (gameObject);
		}
	}

	bool IsInRange (float range) {

		if (Vector3.Distance (player.transform.position, transform.position) < range) {

			return true;
		}

		else {

			return false;
		}
	}
}