using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {

	public Camera firstPersonCamera;
	public Camera overheadCamera;

	void Update() {
		if (Input.GetButton ("Fire2")) {
			firstPersonCamera.enabled = false;
			overheadCamera.enabled = true;
		} else {
			firstPersonCamera.enabled = true;
			overheadCamera.enabled = false;
		}
	}
}

