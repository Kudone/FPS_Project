using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1 : MonoBehaviour {

	public GameManager gameManager;

	void  OnTriggerEnter (Collider other){
		if(other.gameObject.tag == "Bullet"){
		gameManager.score += 20;
			print ("hit1");
	}
}
}