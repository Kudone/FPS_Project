using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerac : MonoBehaviour {

	private Camera cam;

	void Start () {
		cam = GetComponent<Camera>();
	}

	void Update() {
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		float view = cam.fieldOfView - scroll ;

		cam.fieldOfView = Mathf.Clamp(value : view, min : 0.1f, max : 45f);
	}
}