using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHP : MonoBehaviour {

	public int HP;
	Animator anim;

	// Use this for initialization
	void Start () {
		HP = 5;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	/*void  OnTriggerEnter (Collider other)
	{
			HP--;
			if (HP == 0) {
				anim.SetBool ("deathToIdole0", true);
				Invoke ("Destroy", 2f);
			}
		}
	}*/

	void Die(){
		if (HP == 0) {
			anim.SetBool ("deathToIdole0", true);
			Invoke ("Destroy", 2f);
		}
	
	}

}
