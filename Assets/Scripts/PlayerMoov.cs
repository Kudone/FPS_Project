using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoov : MonoBehaviour {

	public float speed;
		// Update is called once per frame
		void Update () {
			float x = Input.GetAxis("Horizontal");
			float z = Input.GetAxis("Vertical");
			Vector3 Direction = new Vector3(x, 0, z)*speed;
			GetComponent<Rigidbody>().AddForce(Direction, ForceMode.VelocityChange);
			Direction = Vector3.zero;
		}
	}