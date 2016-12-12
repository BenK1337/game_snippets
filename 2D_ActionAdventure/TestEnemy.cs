using UnityEngine;
using System.Collections;

public class TestEnemy : BaseCreatures {

	Vector3 spawnPos;
	Vector3 playerDistance;

	Player player;

	void Start () {

		spawnPos = transform.position;
		health = maxHealth;
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void FixedUpdate () {

		// Chasing the Player

		Vector3 playerDistance = transform.position - player.transform.position; // Calculate the Distance

		if (inCombat || Mathf.Abs (playerDistance.x) <= chasingRange && Mathf.Abs (playerDistance.y) <= chasingRange) {

			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, moveSpeed);
			inCombat = true;

			Debug.DrawLine(transform.position, player.transform.position, Color.red);
		}

		// If the Enemy is out of combat and Player is not in chasingRange go back in the hole where you came from!

		if (!inCombat && transform.position != spawnPos) {

			transform.position = Vector3.MoveTowards (transform.position, spawnPos, moveSpeed * 2);
		}

		// Out of range, think about going back

		if (inCombat && Mathf.Abs (playerDistance.x) > chasingRange * 2 || inCombat && Mathf.Abs (playerDistance.y) > chasingRange * 2) {

			StartCoroutine(OutOfRange());

			Debug.DrawLine(transform.position, player.transform.position, Color.green);
		}
	}

	// If still out of range after 2 seconds, we realy go back now, were obviously not fighting

	IEnumerator OutOfRange () {

		yield return new WaitForSeconds (2);

		playerDistance = transform.position - player.transform.position;

		if (Mathf.Abs (playerDistance.x) >= chasingRange * 2 || Mathf.Abs (playerDistance.y) >= chasingRange * 2) {

			inCombat = false;
		}
	}

	void Update () {

		if (!inCombat) {

			health = maxHealth;
		}

		if (health <= 0) {

			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
	
		// If Player touching

		if (col.gameObject.CompareTag ("Player")) {

			player.GetHit(damage);
			StartCoroutine(Knockback (col.gameObject.transform.position, 0.35f, false, true));
		}

		// If getting hit by an Sword

		if (col.gameObject.CompareTag ("Sword")) {

			inCombat = true;
			GetHit(player.swordDamage);
			StartCoroutine(Knockback (col.gameObject.transform.position, 0.35f, false, false));
		}

		// If getting hit by an Arrow

		if (col.gameObject.CompareTag ("Arrow")){

			inCombat = true;
			GetHit(player.bowDamage);
			StartCoroutine(Knockback (col.gameObject.transform.position, 0.5f, true, false));
		}
	}
	
	IEnumerator Knockback (Vector3 colObject, float knockbackPower, bool hitByArrow, bool isPlayer) {

		// Detect from wich side the collison is coming
		
		Vector3 dir = colObject - transform.position;
		
		dir.z = 0;

		// An Arrow should not Knockback diagonal, so remove the lower hitten Axis

		if (hitByArrow) {

			if (Mathf.Abs (dir.x) > Mathf.Abs (dir.y)) {
			
				dir.y = 0;
			}

			else {
			
				dir.x = 0;
			}
		}
		
		dir.Normalize();

		// Knockback delay for Sword and maybe other things so the Animation can hit (just a visual effect)

		if (!hitByArrow) {

			yield return new WaitForSeconds(0.15f);
		}

		// Do the Knockback

		if (isPlayer) {

			player.transform.position = player.transform.position + dir * knockbackPower;
		}

		else {
		
			transform.position = transform.position - dir * knockbackPower;
		}
	}
}
