using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4 : MonoBehaviour {

	public GameManager gameManager;

		void  OnTriggerEnter (Collider other){
			if(other.gameObject.tag == "Bullet"){
		gameManager.score += 100;
			print ("hit4");
	}
}
}