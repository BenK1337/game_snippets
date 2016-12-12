using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	public float m_speed = 0.2f;
	public Transform target;

	float camScale = 1f;
	float minCamScale = 1f;
	float maxCamScale = 3f;
	Camera cam;

	void Start () {
	
		cam = GetComponent<Camera> ();
	}

	void Update () {

		// Zoom via MouseWheel
		if (Input.GetButton ("Shift Left")) {

			if (Input.GetAxis ("Mouse ScrollWheel") > 0) {

				camScale += 1f;
			}

			if (Input.GetAxis ("Mouse ScrollWheel") < 0) {

				camScale -= 1f;
			}

			if (camScale > maxCamScale) {

				camScale = maxCamScale;
			}

			if (camScale < minCamScale) {

				camScale = minCamScale;
			}
		}
	}

	void FixedUpdate () {

		// Fix Scale on alle Resolutions
		cam.orthographicSize = (Screen.height / 100f) / camScale;

		// Smooth Camera Follow
		if (target) {

			transform.position = Vector3.Lerp(transform.position, target.position + new Vector3(0, 0, -10), m_speed);
		}
	}
}