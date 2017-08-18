using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public int score = 0;
	public GUIStyle guiStyle;

	void  OnGUI (){	
	GUI.color = Color.red;
	Rect position2 = new Rect (10, 410, 150, 80);
	GUI.Label (position2, "Pt :" + score.ToString(), guiStyle);
	}
}