using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.C)) {
			this.transform.localScale = new Vector3 (1f, 2f, 1f);

		} 

		else if(Input.GetKeyUp(KeyCode.C)) {
			this.transform.localScale = new Vector3 (1f, 1f, 1f);

		}
	}
}
