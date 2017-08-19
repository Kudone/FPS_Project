using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.C)) {
			this.transform.localScale = new Vector3 (1f, 0.5f, 1f);
		} 

		else if(Input.GetKeyUp(KeyCode.C)) {
			this.transform.localScale = new Vector3 (1f, 1f, 1f);
		}

	}  
}
