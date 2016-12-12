using UnityEngine;
using System.Collections;

public class LaserPrefab : MonoBehaviour {

	void Start() {

		StartCoroutine(Selfdestruction());
	}

	void OnCollisionEnter2D (Collision2D col) {
		
		if (!col.gameObject.CompareTag("Player")) {
			
			Destroy(gameObject);
		}
	}

	IEnumerator Selfdestruction() {

		yield return new WaitForSeconds(1.5f);
		Destroy (gameObject);
	}
}
