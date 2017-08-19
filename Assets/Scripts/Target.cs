using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	int hp;
	BoxCollider boxCollider;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		hp = 5;
		boxCollider = GetComponent<BoxCollider> ();
		IsAttackingToTrue ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Bullet") {*/
			
		void  OnTriggerEnter (Collider other){
			if(other.gameObject.tag == "Bullet"){

		hp -= 1;
			print (hp);

			if (hp == 0) {
				anim.SetBool ("IsDie", true);
				boxCollider.enabled = false;
				Invoke ("IsAttackingToTrue",10f);
				hp = 5;
			}
		}
   } 
		
	void IsAttackingToTrue(){
		boxCollider.enabled = true;
		anim.SetBool ("IsDie", false);
	}
		
}

