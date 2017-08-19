using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Param : MonoBehaviour {

	public GUIStyle guiStyle;
	public float timer;
	float time;

	void Update(){
		timer += Time.deltaTime; 
		time = 90 - timer;
	}


	void  OnGUI (){		
		GUI.color = Color.red;
		string label = "Time : " + time + "s";
		GUI.Label (new Rect (10, 395, 150, 80), label);

	}
}	