using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Death", 1f);
	}
	
	// Update is called once per frame
	void Death () {
		Destroy (gameObject);
	}
}
