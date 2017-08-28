using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damages : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Damage(){
		Destroy (this.gameObject);
	}
}
