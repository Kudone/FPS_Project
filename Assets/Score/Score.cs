using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {


	public GameManager gameManager;

	void  OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Bullet") {
			gameManager.score += 10;
			print ("hit");
		}
	}
}