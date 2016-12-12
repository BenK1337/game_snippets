using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Player Stats

	public float health;
	public float maxHealth = 10;

	public float moveSpeed = 150;
	public bool canWalk = true;

	public float swordDamage = 1;
	public float bowDamage = 1.5f;

	Vector3 lookDirection; // Look Direction


	// References

	Rigidbody2D rbody;
	Animator anim;

	// Child References

	GameObject swordTrigger;

	// Public References
	
	public Rigidbody2D projectile; // Arrow Prefab, for the Bow

	/************************************************************/

	void Awake () {
	
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		swordTrigger = GameObject.Find ("SwordTrigger");
		swordTrigger.SetActive (false);
	}

	void Start () {

		health = maxHealth;
	}

	void Update () {

		// Movement

		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (movement_vector != Vector2.zero && canWalk) {

			anim.SetBool ("isWalking", true);
			anim.SetFloat ("input_x", movement_vector.x);
			anim.SetFloat ("input_y", movement_vector.y);
			rbody.MovePosition (rbody.position + movement_vector * moveSpeed * Time.deltaTime);
		}

		else {

			anim.SetBool ("isWalking", false);
			rbody.MovePosition (rbody.position);
		}

		// Look Direction

		if (canWalk) {

			if (movement_vector == new Vector2 (0, 1) || movement_vector == new Vector2 (1, 1) || movement_vector == new Vector2 (-1, 1)) {
			
				lookDirection = new Vector3 (0, 0, 0); // Looking up
			}
		
			if (movement_vector == new Vector2 (0, -1) || movement_vector == new Vector2 (1, -1) || movement_vector == new Vector2 (-1, -1)) {
			
				lookDirection = new Vector3 (0, 0, 180); // Looking down
			}
		
			if (movement_vector == new Vector2 (-1, 0)) {
			
				lookDirection = new Vector3 (0, 0, 90); // Looking left
			}
		
			if (movement_vector == new Vector2 (1, 0)) {

				lookDirection = new Vector3 (0, 0, -90); // Looking right
			}
		}


		// Swing Sword

		if (Input.GetButtonDown ("Fire1") && canWalk) {
			
			canWalk = false;
			anim.SetBool ("isSwingSword", true);
			swordTrigger.SetActive(true);

			StartCoroutine(SwingSword());
		}


		// Shooting Bow

		if (Input.GetButtonDown ("Fire2") && canWalk) {

			canWalk = false;
			anim.SetBool ("isShootBow", true);

			StartCoroutine(ShootBow());
		}
	}

	IEnumerator SwingSword () {

		yield return new WaitForSeconds (0.25f);
		
		canWalk = true;
		anim.SetBool ("isSwingSword", false);
		swordTrigger.SetActive (false);
	}

	IEnumerator ShootBow () {

		float arrowSpeed = 200;
		Rigidbody2D arrow;

		yield return new WaitForSeconds (0.5f);

		if (lookDirection == new Vector3(0, 0, 0)) { // Up
			
			arrow = Instantiate (projectile, transform.position + new Vector3(0, 0.1f, 0), Quaternion.Euler(lookDirection)) as Rigidbody2D;
			arrow.velocity = transform.TransformDirection (Vector3.up * arrowSpeed * Time.deltaTime);
			arrow.GetComponentInParent<SpriteRenderer>().sortingOrder = 45;
		}
		
		if (lookDirection == new Vector3(0, 0, 180)) { // Down
			
			arrow = Instantiate (projectile, transform.position + new Vector3(0, -0.15f, 0), Quaternion.Euler(lookDirection)) as Rigidbody2D;
			arrow.velocity = transform.TransformDirection (Vector3.down * arrowSpeed * Time.deltaTime);
		}
		
		if (lookDirection == new Vector3(0, 0, 90)) { // Left
			
			arrow = Instantiate (projectile, transform.position + new Vector3(-0.1f, -0.05f, 0), Quaternion.Euler(lookDirection)) as Rigidbody2D;
			arrow.velocity = transform.TransformDirection (Vector3.left * arrowSpeed * Time.deltaTime);
		}
		
		if (lookDirection == new Vector3(0, 0, -90)) { // Right
			
			arrow = Instantiate (projectile, transform.position + new Vector3(0.1f, -0.05f, 0), Quaternion.Euler(lookDirection)) as Rigidbody2D;
			arrow.velocity = transform.TransformDirection (Vector3.right * arrowSpeed * Time.deltaTime);
		}

		yield return new WaitForSeconds (0.2f); // Animation restarts (looks like he puts weapon back)

		canWalk = true;
		anim.SetBool ("isShootBow", false);
	}

	// Getting Damage

	public void GetHit (float enemyDamage) {

		health -= enemyDamage;
	}
}