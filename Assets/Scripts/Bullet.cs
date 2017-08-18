using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject effectObj;


	// Use this for initialization
	void Start () {
		//弾を5秒後に削除する
		Destroy (this.gameObject, 2);
	}

	void Update(){
		
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Stage") {
			GameObject effect = Instantiate (effectObj, gameObject.transform.position, effectObj.transform.rotation);
			effect.transform.parent = gameObject.transform;

			print ("aa");
		}
	}
}