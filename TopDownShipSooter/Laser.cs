using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	
	public Rigidbody2D projectile; 
	public GameObject laserL;
	public GameObject laserR;
	public GameObject quadLaserL;
	public GameObject quadLaserR;
	public bool doubleLaser;
	public bool quadLaser;
	bool laserSwitch;

	Player player;

	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void Update () {

		if (Input.GetButtonDown ("Fire1")) {

			float laserSpeed = 45;
			Rigidbody2D laser;

			if (player.laserPower >= 10) {

				player.laserPower -= 10;

				if (quadLaser) {

					laser = Instantiate (projectile, laserL.transform.position, transform.rotation) as Rigidbody2D;
					laser.velocity = transform.TransformDirection (Vector3.up * laserSpeed);
					laser = Instantiate (projectile, laserR.transform.position, transform.rotation) as Rigidbody2D;
					laser.velocity = transform.TransformDirection (Vector3.up * laserSpeed);

					laser = Instantiate (projectile, quadLaserL.transform.position, quadLaserL.transform.rotation) as Rigidbody2D;
					laser.velocity = quadLaserL.transform.TransformDirection (Vector3.up * laserSpeed);
					laser = Instantiate (projectile, quadLaserR.transform.position, quadLaserR.transform.rotation) as Rigidbody2D;
					laser.velocity = quadLaserR.transform.TransformDirection (Vector3.up * laserSpeed);
				}

				else if (doubleLaser) {

					laser = Instantiate (projectile, laserL.transform.position, transform.rotation) as Rigidbody2D;
					laser.velocity = transform.TransformDirection (Vector3.up * laserSpeed);

					laser = Instantiate (projectile, laserR.transform.position, transform.rotation) as Rigidbody2D;
					laser.velocity = transform.TransformDirection (Vector3.up * laserSpeed);
				}

				else {

					laserSwitch = !laserSwitch;

					if (laserSwitch) {

						laser = Instantiate (projectile, laserL.transform.position, transform.rotation) as Rigidbody2D;
						laser.velocity = transform.TransformDirection (Vector3.up * laserSpeed);
					}

					else {

						laser = Instantiate (projectile, laserR.transform.position, transform.rotation) as Rigidbody2D;
						laser.velocity = transform.TransformDirection (Vector3.up * laserSpeed);
					}
				}
			}
		}
	}
}
