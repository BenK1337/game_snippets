using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	NavMeshAgent navAgent;
	Animation anim;
	
	public AnimationClip idleAnimation;
	public AnimationClip walkAnimation;
	public AnimationClip runAnimation;

	bool isWalking;

	void Start () {
	
		navAgent = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animation> ();
	}

	void Update () {

		Animate ();
		Move ();
		Walk ();
	}

	void Move() {

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		if (Input.GetMouseButton (1)) {
			
			if (Physics.Raycast (ray, out hit, 100)) {
				
				navAgent.SetDestination(hit.point);
			}
		}
	}

	void Walk() {

		if (Input.GetKey (KeyCode.LeftShift)) {

			navAgent.speed = 1.5f;
			isWalking = true;
		}

		else {

			navAgent.speed = 3.5f;
			isWalking = false;
		}
	}

	void Animate() {

		if (!Player.isAttacking) {

			if (isWalking) {

				anim.CrossFade (walkAnimation.name);
			} else if (navAgent.velocity.magnitude > 3f) {
			
				anim.CrossFade (runAnimation.name);
			} else {

				anim.CrossFade (idleAnimation.name);
			}
		}
	}
}