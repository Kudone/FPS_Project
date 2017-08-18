using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour {

	const int SphereBulletFrequency = 3;
	//const int MaxshotPower = 30;
	const int RecoverySeconds = 3;
	const int BulletBox = 150;
	public int bulletbox = BulletBox;


	int sampleBulletCount;
	public int shotPower; //= MaxshotPower;
	AudioSource shotSound;

	public GameObject bullets;
	public BulletHolder bulletHolder;

	public Camera playerCamera;
	float speed = 50;


	void Start ()
	{
		shotSound = GetComponent<AudioSource> ();
	}

	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) Shot (); RecoverPower ();  
	}


	public void Shot()
	{
		if (bulletHolder.GetBulletAmount () <= 0)
			return;
		/*if (shotPower <= 0)
			return;*/

		GameObject effectObj = Resources.Load<GameObject> ("Effects/shotEffect");
		GameObject effect = Instantiate(effectObj, gameObject.transform.position, effectObj.transform.rotation);
		effect.transform.parent = gameObject.transform;

			GameObject bullet2 = (GameObject)Instantiate (bullets, playerCamera.transform.position, Quaternion.identity);
		    Ray rayOrigin = playerCamera.ScreenPointToRay (new Vector3(Screen.width / 2, Screen.height / 2, 0));
			Vector3 direction = rayOrigin.direction; 
			//掛けている20はBulletのスピードなので好きな数値を入力
			bullet2.GetComponent<Rigidbody> ().velocity = direction * speed; 
		

		bulletHolder.ConsumeBullet ();
		ConsumePower ();

		shotSound.Play ();
	}
		

	/*void OnGUI ()
	{
		GUI.color = Color.red;

		string label = "BulletBox:" + bulletbox;


		GUI.Label (new Rect (850, 395, 150, 80), label);
	}*/

	void ConsumePower ()
	{
		shotPower++;
	}

	void RecoverPower ()
	{
		if (Input.GetKey (KeyCode.R)) {

			if (bulletbox >= shotPower) {
				bulletbox = bulletbox - shotPower;
				shotPower = 0;
			} else if (bulletbox < shotPower) {
				bulletbox = 0;
				shotPower = 0;
			} 
	}
}
}
