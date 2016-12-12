using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	BoxCollider2D bc2d;

	void Start() {

		bc2d = GetComponent<BoxCollider2D> ();
		StartCoroutine(Selfdestruction());
	}

	void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.tag != "Player"){

			Destroy(gameObject);
		}
	}

	IEnumerator Selfdestruction() {

		yield return new WaitForSeconds(0.02f);
		bc2d.enabled = true;
		yield return new WaitForSeconds(1.5f);
		Destroy (gameObject);
	}
}