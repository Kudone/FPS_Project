using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour {


	CharacterController eCon;
	Animator animator;
	Vector3 destination;	//目的地
	float speed;	//移動スピード
	Vector3 velocity;
	Vector3 direction;

	void Start () {
		//destination = Vector3(25, 0, 25);
		eCon = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		speed = 1.0f;
		velocity = Vector3.zero;
	}

	void Update () {
		if(eCon.isGrounded) {
			velocity = Vector3.zero;
			animator.SetFloat("Speed", 2.0f);
			direction = (destination - transform.position).normalized;
			//transform.LookAt(Vector3(destination.x, transform.position.y, destination.z));
			velocity = direction * speed;
			Debug.Log(destination);
		}
		velocity.y += Physics.gravity.y * Time.deltaTime;
		eCon.Move(velocity * Time.deltaTime);
	}
		
}
