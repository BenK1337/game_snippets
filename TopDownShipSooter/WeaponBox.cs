using UnityEngine;
using System.Collections;

public class WeaponBox : MonoBehaviour {

	int type;

	SpriteRenderer rend;
	Player player;

	void Start () {
	
		rend = GetComponent<SpriteRenderer> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

		type = Random.Range (1, 3);

		switch (type) {

		case 2:
			rend.color = Color.blue;
			print ("Lightning Pulse spawned");
			break;

		case 1:
			rend.color = Color.green;
			print ("LaserPowerBox spawned");
			break;

		default:
			rend.color = Color.black;
			print ("Bug ahead! Garbage spawned");
			break;
		}
	}

	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.tag == "Player") {

			switch (type) {

			case 2:
				print ("Lightning Pulse coming soon!");
				break;

			case 1:
				player.maxLaserPower += 50;
				break;

			default:
				print ("Garbage is not good for you!");
				break;
			}

			Destroy(gameObject);
		}
	}
}