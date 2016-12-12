using UnityEngine;
using System.Collections;

public class Shadow : MonoBehaviour {

	Player player;

	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void Update () {
	
		transform.position = player.transform.position + new Vector3 (0, 0.5f, 0);
	}
}
