using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3 : MonoBehaviour {

	public GameManager gameManager;

	void  OnTriggerEnter (Collider other){
		if(other.gameObject.tag == "Bullet"){
		gameManager.score += 50;
			print ("hit3");
	}
}
}