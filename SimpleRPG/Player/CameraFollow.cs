using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float height = 4;
	public float radius = 4;
	public float angle = 0;
	public float rotationalSpeed = 1;

	void Start () {
	
	}

	void Update () {
	
		float cameraX = target.position.x + (radius * Mathf.Cos (angle));
		float cameraY = target.position.y + height;
		float cameraZ = target.position.z + (radius * Mathf.Sin (angle));

		transform.position = new Vector3(cameraX, cameraY, cameraZ);

		if (Input.GetKey (KeyCode.A)) {

			angle -= rotationalSpeed * Time.deltaTime;
		}

		else if (Input.GetKey (KeyCode.D)) {
			
			angle += rotationalSpeed * Time.deltaTime;
		}

		transform.LookAt (target.position);
	}
}