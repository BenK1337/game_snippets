using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveSpeed = 10f;
	public float maxMoveSpeed = 5f;

	public float health;
	public float maxHealth = 100;

	public float shield;
	public float maxShield = 100;

	public float laserPower;
	public float maxLaserPower = 100;


	Rigidbody2D rb;

	void Start () {
	
		rb = GetComponent<Rigidbody2D> ();

		laserPower = maxLaserPower;
		health = maxHealth;
		shield = maxShield;
	}

	void Update () {

		if (Input.GetButtonDown ("Speed Boost")) {

			rb.AddForce (transform.TransformDirection (Vector3.up) * moveSpeed * 150);
		}

		/*************** Natural Regeneration ***************/

		//Laser
		if (laserPower != maxLaserPower) {

			laserPower += 0.3f;
		}

		if (laserPower > maxLaserPower) {

			laserPower = maxLaserPower;
		}
	}

	void FixedUpdate () {

		/*************** Movement Section ***************/

		// Fake Friction
		rb.velocity = rb.velocity / 1.02f;
		rb.angularVelocity = rb.angularVelocity / 1.07f;

		// Throttle
		if (Input.GetAxisRaw ("Vertical") > 0) {
			
			rb.AddForce (transform.TransformDirection (Vector3.up) * moveSpeed);
		}

		// Break
		else if (Input.GetAxisRaw ("Vertical") < 0) {

			rb.velocity = rb.velocity / 1.05f;
		}

		// Strafe
		if (Input.GetAxisRaw("Strafe") > 0) {
			
			rb.AddForce (transform.TransformDirection (Vector3.right) * moveSpeed);
		}

		else if (Input.GetAxisRaw ("Strafe") < 0) {
			
			rb.AddForce (transform.TransformDirection (Vector3.left) * moveSpeed);
		}

		// Rotation
		if (Input.GetAxisRaw("Horizontal") > 0) {

			rb.AddTorque(-moveSpeed);
		}

		else if (Input.GetAxisRaw ("Horizontal") < 0) {
			
			rb.AddTorque (moveSpeed);
		}

		// Maximum Speed
		float veloX = Mathf.Abs (rb.velocity.x);
		float veloY = Mathf.Abs (rb.velocity.y);
		
		if (veloX > maxMoveSpeed) {
			
			veloX = maxMoveSpeed;
		}
		
		if (veloY > maxMoveSpeed) {
			
			veloY = maxMoveSpeed;
		}

		// Max Torque
		if (rb.angularVelocity > 60) {

			rb.angularVelocity = 60;
		}

		else if (rb.angularVelocity < -60) {
			
			rb.angularVelocity = -60;
		}
	}
}
