using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	// speedを制御する
	float speed = 50f;


	void Update ()
	{
		float x =  Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Rigidbody rigidbody = GetComponent<Rigidbody>();

		// xとyにspeedを掛ける
		rigidbody.AddForce(x * speed, 0, z * speed);

	}

	void FixedUpdate () {
		if (Input.GetKey (KeyCode.C)) {
			this.transform.localScale = new Vector3 (1f, 0.5f, 1f);
			speed = 20f;
		} 

		else if(Input.GetKeyUp(KeyCode.C)) {
			this.transform.localScale = new Vector3 (1f, 1f, 1f);
			speed = 50f;
		}

	}  
}
