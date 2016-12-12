using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	public float m_speed = 0.1f;
	public Transform target;

	Camera cam;

	void Start () {
	
		cam = GetComponent<Camera> ();
	}
	
	void FixedUpdate () {
		
		cam.orthographicSize = (Screen.height / 100f) / 3f;

		if (target) {

			transform.position = Vector3.Lerp(transform.position, target.position + new Vector3(0, 0, -10), m_speed);
		}
	}
}