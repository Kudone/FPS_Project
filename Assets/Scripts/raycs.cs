using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class raycs : MonoBehaviour {


	public GameObject ak47;
	public float range = 100;　//rayの射程距離
	Ray ray;
	RaycastHit hit;
	public GameObject nozzle; //銃口
	Vector3 cameraCenter ; //銃の標準用
	public int bulletBox = 150;
	public int bullet = 30;
	int shotcount ;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Shottoku ();
		}

	}


	//攻撃(Raycast発射処理
	void Shottoku(){
		cameraCenter = new Vector3(Screen.width/2, Screen.height/2, 0);
		ray = Camera.main.ScreenPointToRay (cameraCenter);
		if (Physics.Raycast (ray, out hit, range)) {
			if (hit.collider) {
				GameObject effectobj = Resources.Load<GameObject> ("Effects/shotEffect");
				Instantiate (effectobj, hit.point, Quaternion.identity);
				Instantiate (effectobj, nozzle.transform.position, Quaternion.identity);

				//yield return new WaitForSeconds (0.1f);
				GameObject[] tagobjs = GameObject.FindGameObjectsWithTag ("Bullet");
				foreach (GameObject obj in tagobjs) {
					Destroy (obj);
				}
			}
		}
	}

}
